using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YModemWin
{
    public partial class YModemTransmitter
    {
        /* 控制信号 */
        const byte SOH = 1;  // 128字节包开头
        const byte STX = 2;  // 1024字节包开头
        const byte EOT = 4;  // 传输结束
        const byte ACK = 6;  // 确认信号
        const byte NAK = 0x15;  // 否认信号
        const byte C = 0x43;   // 请求数据
        const byte CAN = 0x18; // 取消传输标识
        /* 尺寸 */
        public const int DataSize = 1024;
        public const int CrcSize = 2;  // CRC校验的大小
        SerialPort serialPort;
        string Path;
        int packagesent;
        int totalpackage;
        long status;
        double usedSeconds;
        bool isTramsitting;
        bool userCancel = false;

        //完成包号，总包号，文件名
        Action<long, long,long,long,long,string> RefreshSendUI=null;

        public YModemTransmitter(SerialPort sp,bool timeout, Action<long, long, long, long, long,string> action)
        {
            serialPort = sp;
            RefreshSendUI = action;
            if (timeout)
            {
                serialPort.ReadTimeout = 3000;
            }else
            {
                serialPort.ReadTimeout = 1000000;
            }
        }

        //支持多文件传输，如果是仅发送一个文件，或者是多个文件的最后一个文件，输入参数isLastFile默认为真
        public bool YmodemSendFile(string path, bool isLastFile = true)
        {
            userCancel = false;
            isTramsitting = true;
            Path = path;
            FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read);
            //计算总段长
            totalpackage = (int)(fileStream.Length - 1) / YModemTransmitter.DataSize + 1;
            Console.WriteLine("total section len=" + totalpackage.ToString());

            /* 数据包: 1029字节 */
            /* 头部: 3字节 */
            // STX

            int invertedPacketNumber = 255;
            /* 数据: 1024字节 */
            byte[] data = new byte[DataSize];
            /* 尾部: 2字节 */
            byte[] CRC = new byte[CrcSize];

            Crc16Ccitt crc16Ccitt = new Crc16Ccitt(InitialCrcValue.Zeros);
            int packetNumber = 0;
            DateTime dt = DateTime.Now;

            Thread.Sleep(1);

            try
            {
                /* 发送包含文件名和文件大小的初始数据包 */
                while (isTramsitting)
                {
                    int ret = -1;
                    try
                    {
                        ret = serialPort.ReadByte();
                    }
                    catch { }
                    if (ret == C) break;
                    Thread.Sleep(30);
                }

                sendYmodemInitialPacket(STX, packetNumber, invertedPacketNumber, data, DataSize, Path, fileStream, CRC, CrcSize);
                byte read =(byte) serialPort.ReadByte();
                if (read != ACK)
                {
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "发送初始数据包错误");
                    status = -1;
                    return false;
                }

                if (serialPort.ReadByte() != C)
                {
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "未接收到正确的接收请求");
                    status = -1;
                    return false;
                }
                /* 循环发送数据包，直到发送完最后一个字节 */
                int packageReadCount;
                do
                {
                    /* 如果这是最后一个数据包，用0填充剩余字节 */
                    packageReadCount = fileStream.Read(data, 0, DataSize);
                    if (packageReadCount == 0) break;
                    if (packageReadCount != DataSize)
                        for (int i = packageReadCount; i < DataSize; i++)
                            data[i] = 0x1A;

                    /* 计算数据包编号 */
                    packetNumber++;
                    packagesent++;
                    if (packetNumber > 255)
                        packetNumber -= 256;
                    string fileName = System.IO.Path.GetFileName(path);
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packagesent, totalpackage,status,"正在发送文件 "+ fileName);

                    Console.WriteLine(packetNumber);

                    /* 计算反转数据包编号 */
                    invertedPacketNumber = 255 - packetNumber;

                    /* 计算CRC校验码 */

                    CRC = crc16Ccitt.ComputeChecksumBytes(data);

                    /* 发送数据包 */
                    sendYmodemPacket(STX, packetNumber, invertedPacketNumber, data, DataSize, CRC, CrcSize);

                    /* 等待ACK信号 */
                    int signal = serialPort.ReadByte();
                    if (signal == ACK)
                    {
                        //System.Threading.Thread.Sleep(1);
                        status = 2;
                    }
                    //数传传输错误，重传数据
                    else if (signal == NAK)
                    {
                        /* 发送数据包 */
                        RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "数据传输错误，重发数据包。");
                        Console.WriteLine("数据传输错误，重发数据包。");
                        status = -1;
                        // 重置流的位置回到开始
                        fileStream.Position -= DataSize;
                        //重置包号
                        packagesent--;
                        packetNumber--;
                    }
                    else
                    {
                        RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "服务端未响应发送的数据包。");
                        Console.WriteLine("无法发送数据包。");
                        status = -1;
                        return false;
                    }
                    if (userCancel)
                    {
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                        serialPort.Write(new byte[] { CAN }, 0, 1);
                    }
                } while (DataSize == packageReadCount && isTramsitting);

                /* 发送EOT（通知接收方传输结束） */
                serialPort.Write(new byte[] { EOT }, 0, 1);

                /* 获取ACK（接收方确认EOT） */
                int act = serialPort.ReadByte();
                if ((act != ACK) && (act != NAK))
                {
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "客户端未正确响应结束请求。");
                    Console.WriteLine("无法完成传输。");
                    status = -1;
                    return false;
                }
                /* 获取NAK（发送方重新发送EOT） */
                if (act == NAK)
                {
                    serialPort.Write(new byte[] { EOT }, 0, 1);
                }
                /* 获取ACK（接收方确认EOT） */
                if (serialPort.ReadByte() != ACK)
                {
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "客户端未正确响应结束请求。");
                    Console.WriteLine("无法完成传输。");
                    status = -1;
                    return false;
                }
                //如果是最后一个文件发送文件组发送完成包
                if (isLastFile)
                {
                    /* 获取ACK（接收方确认C信号） */
                    if (serialPort.ReadByte() != C)
                    {
                        RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "客户端未正确响应结束请求。");
                        Console.WriteLine("无法完成传输。");
                        status = -1;
                        return false;
                    }

                    /* 发送关闭数据包 */
                    packetNumber = 0;
                    invertedPacketNumber = 255;
                    data = new byte[128];
                    data[0] = 0x00;
                    data[1] = data[3] = data[5] = 0x30;
                    data[2] = data[4] = 0x20;
                    CRC = new byte[CrcSize];
                    /* 计算CRC校验码 */
                    CRC = crc16Ccitt.ComputeChecksumBytes(data);

                    sendYmodemClosingPacket(SOH, packetNumber, invertedPacketNumber, data, 128, CRC, CrcSize);

                    /* 获取ACK（接收方确认下载完成） */
                    if (serialPort.ReadByte() != ACK)
                    {
                        Console.WriteLine("无法完成传输。");
                        RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "客户端未正确响应结束请求。");
                        status = -1;
                        return false;
                    }
                    Console.WriteLine("文件传输成功");
                    TimeSpan span = DateTime.Now - dt;
                    usedSeconds = span.TotalSeconds;
                    status = 1;
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packagesent, totalpackage, status, "发送成功，耗时:" + span.TotalSeconds.ToString() + "秒");
                    //MessageBox.Show("发送耗时:" + span.TotalMilliseconds.ToString() + "毫秒", "发送成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }

            catch (Exception ee)
            {
                //接收方超时
                Console.WriteLine("接收方超时");
                status = -1;
                RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "接收方超时");
                return false;
            }
            finally
            {
                if (status == -1)
                {
                    RefreshSendUI?.Invoke(fileStream.Position, fileStream.Length, packetNumber, totalpackage, status, "发送失败");
                }
                fileStream.Close();
            }


            return true;
        }
        public void StopTransmitting()
        {
            userCancel = true;
            isTramsitting = false;
        }
        /// <summary>
        /// 发送多个文件
        /// </summary>
        /// <param name="files"></param>
        public void YmodemSendFiles(List<string> files)
        {
            userCancel = false;
            for(int i= 0;i < files.Count;i++)
            {
                if (i != files.Count - 1)
                {
                    YmodemSendFile(files[i],false);
                }else
                {
                    YmodemSendFile(files[i]);
                }
                if (userCancel) break;
            }
        }
        private void sendYmodemInitialPacket(byte STX, int packetNumber, int invertedPacketNumber, byte[] data, int dataSize, string path, FileStream fileStream, byte[] CRC, int crcSize)
        {
            string fileName = System.IO.Path.GetFileName(path);
            // YModem协议不允许字符串中出现空格，将空格替换为下划线
            fileName = fileName.Replace(" ", "_");
            string fileSize = fileStream.Length.ToString();

            // 获取文件的最后修改时间
            DateTime lastWriteTime = File.GetLastWriteTime(path);

            // 手动计算Unix时间戳（从1970年1月1日到lastWriteTime的秒数）
            DateTimeOffset epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            long unixTime = (lastWriteTime.ToUniversalTime().Ticks - epoch.Ticks) / TimeSpan.TicksPerSecond;

            // 将Unix时间戳转换为八进制字符串
            string fileModTime = Convert.ToString(unixTime, 8);


            // 将包数转换为八进制字符串
            string packageCount = Convert.ToString(totalpackage, 8);

            // 使用 Encoding 类中的 GetBytes 方法将字符串转换为 GB2312 编码的字节数组
            byte[] gb2312Bytes = Encoding.GetEncoding("gb2312").GetBytes(fileName);

            /* 将文件名添加到数据中 */
            int i;
            for (i = 0; i < gb2312Bytes.Length && (gb2312Bytes[i] != 0); i++)
            {
                data[i] = (byte)gb2312Bytes[i];
            }
            data[i] = 0;
            /* 将文件大小添加到数据中 */
            int j;
            for (j = 0; j < fileSize.Length && (fileSize.ToCharArray()[j] != 0); j++)
            {
                data[i  + j + 1] = (byte)fileSize.ToCharArray()[j];
            }
            data[i  + j + 1] = (byte)(' ');
            /* 将文件修改时间添加到数据中 */
            int m;
            for (m = 0; m < fileModTime.Length && (fileModTime.ToCharArray()[m] != 0); m++)
            {
                data[i + j  + m + 2] = (byte)fileModTime.ToCharArray()[m];
            }
            data[i + j  + m + 2] = (byte)(' ');
            /* 将文件修改时间添加到数据中 */
            int n;
            for (n = 0; n < packageCount.Length && (packageCount.ToCharArray()[n] != 0); n++)
            {
                data[i + j  + n + m + 3] = (byte)packageCount.ToCharArray()[n];
            }
            data[i + j + m + n + 3] = (byte)(' ');
            /* 用0填充剩余的数据字节 */
            for (int k = (i + j + m + n + 4); k < dataSize; k++)
            {
                data[k] = 0;
            }

            /* 计算CRC校验码 */
            Crc16Ccitt crc16Ccitt = new Crc16Ccitt(InitialCrcValue.Zeros);
            CRC = crc16Ccitt.ComputeChecksumBytes(data);

            /* 发送数据包 */
            sendYmodemPacket(STX, packetNumber, invertedPacketNumber, data, dataSize, CRC, crcSize);
        }

        private void sendYmodemClosingPacket(byte SOH, int packetNumber, int invertedPacketNumber, byte[] data, int dataSize, byte[] CRC, int crcSize)
        {
            /* 计算CRC校验码 */
            Crc16Ccitt crc16Ccitt = new Crc16Ccitt(InitialCrcValue.Zeros);
            CRC = crc16Ccitt.ComputeChecksumBytes(data);

            /* 发送数据包 */
            sendYmodemPacket(SOH, packetNumber, invertedPacketNumber, data, dataSize, CRC, crcSize);
        }

        private void sendYmodemPacket(byte STX, int packetNumber, int invertedPacketNumber, byte[] data, int dataSize, byte[] CRC, int crcSize)
        {
            int packetSize = 1 + 1 + 1 + dataSize + crcSize; // 计算包的总大小

            // 创建一个足够大的字节数组来存储整个包
            byte[] packet = new byte[packetSize];

            // 填充包数据
            packet[0] = STX;  // STX
            packet[1] = (byte)packetNumber;  // Packet Number
            packet[2] = (byte)invertedPacketNumber;  // Inverted Packet Number
            Array.Copy(data, 0, packet, 3, dataSize);  // 复制数据到包中
            Array.Copy(CRC, 0, packet, 3 + dataSize, crcSize);  // 复制CRC到包中

            // 通过串口一次性发送整个包
            serialPort.Write(packet, 0, packet.Length);

        }

    }
}
