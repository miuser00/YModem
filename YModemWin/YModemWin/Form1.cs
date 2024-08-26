using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YModemWin
{
    public partial class Form1 : Form
    {
        YModemReceiver receiver;
        YModemTransmitter transmitter;
        public Form1()
        {
            InitializeComponent();
            //初始化调用
            EnumComportfromReg(comboBox1);
           // comboBox1.SelectedIndex = 2;
            cmb_baud.SelectedIndex = 5;
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
        }

        private void EnumComportfromReg(ComboBox Combobox)
        {
            Combobox.Items.Clear();
            ///定义注册表子Path
            string strRegPath = @"Hardware\\DeviceMap\\SerialComm";
            ///创建两个RegistryKey类，一个将指向Root Path，另一个将指向子Path
            RegistryKey regRootKey;
            RegistryKey regSubKey;
            ///定义Root指向注册表HKEY_LOCAL_MACHINE节点
            regRootKey = Registry.LocalMachine;
            regSubKey = regRootKey.OpenSubKey(strRegPath);
            if (regSubKey.GetValueNames() == null) return;
            string[] strCommList = regSubKey.GetValueNames();
            foreach (string VName in strCommList)
            {
                //向listbox1中添加字符串的名称和数据，数据是从rk对象中的GetValue(it)方法中得来的
                Combobox.Items.Add(regSubKey.GetValue(VName));
            }
            if (Combobox.Items.Count <= 0)
            { MessageBox.Show("Error Device Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); return; }
            else
            { Combobox.SelectedIndex = 0; }
            regSubKey.Close();
            regRootKey.Close();
        }


        private void btn_select_files_Click(object sender, EventArgs e)
        {      
            openFileDialog1.ShowDialog();
            cmb_uploadfileNames.Items.Clear();
            cmb_uploadfileNames.Text = openFileDialog1.FileName;
            cmb_uploadfileNames.Items.AddRange(openFileDialog1.FileNames);
            if (!string.IsNullOrEmpty(cmb_uploadfileNames.Text)) btn_Send.Enabled = true;
        }

     
      

        private void btn_port_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                btn_port.Text = "打开";

                try
                {
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭异常");
                    return;
                }
             
            }
            else
            {
                btn_port.Text = "关闭";
                int baud = int.Parse(cmb_baud.Text);
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = baud;

                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开错误"); 
                    return;
                }
              
            }
        }
        

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //当数据到达时，操作系统会将数据放入串口接收缓冲区。此时，如果 ReadByte() 正在阻塞等待，它可能会优先读取该字节，导致缓冲区中剩余的数据被传递给 serialPort1_DataReceived 事件处理程序。
            //另一方面，如果数据到达时缓冲区中有多个字节，而 ReadByte() 只读取一个字节，那么 serialPort1_DataReceived 事件处理程序会在下一个数据到达时触发，并处理缓冲区中的剩余数据。
            //string test=serialPort1.ReadExisting();
            //Console.WriteLine(test);
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (btn_Send.Text == "取消")
            {
                transmitter.StopTransmitting();
                btn_Send.Text = "发送";
            }
            else if (serialPort1.IsOpen)
            {
                if (receiver != null) receiver.StopReceiving();
                if (transmitter != null) transmitter.StopTransmitting();

                pgb_send.Value = 0;
                //btn_Send.Enabled = false;
                btn_Send.Text = "取消";
                transmitter = new YModemTransmitter(serialPort1,chb_SendTimeout.Checked, RefreshSendUI);
                pgb_send.Value = 0;
                string filename = cmb_uploadfileNames.Text;
                List<string> filenames = cmb_uploadfileNames.Items.Cast<string>().ToList();
                th = new Thread(() =>
                {
                    if (cmb_uploadfileNames.Items.Count == 1)
                    {
                        transmitter.YmodemSendFile(filename);
                    }else
                    {
                        transmitter.YmodemSendFiles(filenames);
                    }
                });
                th.Start();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txt_SaveDirectory.Text = Application.StartupPath;
        }

        private void btn_BrowserSaveDirectory_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();

            //txt_SaveDirectory.Text = folderBrowserDialog1.SelectedPath;
            Process.Start("explorer.exe", txt_SaveDirectory.Text);
        }

        private void RefreshSendUI(long sentlen, long totallen,long sendsection,long totalsection,long status,string msg)
        {

            this.BeginInvoke(new Action(() => {
                txt_AllSendByte.Text = totallen.ToString();
                txt_SendByte.Text = sentlen.ToString();
                txt_SendPackage.Text = sendsection.ToString();
                txt_SEND_TotalPackage.Text = totalsection.ToString();
                switch (status)
                {
                    case 0:
                        btn_SendStatus.Text = "";
                        break;
                    case 2:
                        btn_SendStatus.Text = "取消";
                        break;
                    case 1:
                        btn_SendStatus.Text = "成功";
                        btn_Send.Text = "发送";
                        //btn_Send.Enabled = true;
                        break;
                    case -1:
                        btn_SendStatus.Text = "错误";
                        btn_Send.Text = "发送";
                        //btn_Send.Enabled = true;
                        break;
                }
                toolStripStatusLabel1.Text = msg;
                try
                {
                    pgb_send.Value = (int)(((float)sentlen / (float)totallen) * 100);
                }
                catch
                { }
            }));
        }
        private void RefreshReceivedUI(long rsvbyte,long totalbyte,long rsvpackage,long totalpackage,long status,string msg,string filename,string modifydate)
        {
            this.Invoke(new Action(()=>{
                txt_FileName.Text = filename;
                txt_ModifyDate.Text = modifydate;
                if (rsvbyte!=0) txt_ReceiveByte.Text = rsvbyte.ToString();
                if (totalbyte != 0) txt_AllReceiveByte.Text = totalbyte.ToString();
                if (totalpackage != 0) txt_RSV_TotalPackage.Text = totalpackage.ToString();
                if (rsvpackage != 0) txt_ReceivePackage.Text = rsvpackage.ToString();

                switch (status)
                {
                    case 0:
                        btn_ReceiveStatus.Text = "";
                        break;
                    case 2:
                        btn_ReceiveStatus.Text = "取消";
                        break;
                    case 1:
                        btn_ReceiveStatus.Text = "成功";
                        btn_Receive.Text = "接收";

                        break;
                    case -1:
                        btn_ReceiveStatus.Text = "错误";
                        btn_Receive.Text = "接收";
                        break;
                }
                toolStripStatusLabel1.Text = msg;
                try
                {
                    if (rsvbyte != 0 && totalbyte != 0)
                    {
                        pgb_receive.Value = (int)((float)rsvbyte / (float)totalbyte * 100);
                    }                    
                }
                catch { }
            }));
        }
        Thread th;
        private void btn_Receive_Click(object sender, EventArgs e)
        {
            if (btn_Receive.Text=="取消")
            {
                receiver.StopReceiving();
                btn_Receive.Text = "接收";
            }
            else
            if (serialPort1.IsOpen)
            {
                if (receiver != null) receiver.StopReceiving();
                if (transmitter != null) transmitter.StopTransmitting();

                btn_Receive.Text = "取消";
                this.txt_ReceiveByte.Text = "0";
                receiver = new YModemReceiver(serialPort1,chb_ReceiveTimeout.Checked, txt_SaveDirectory.Text, RefreshReceivedUI);
                pgb_send.Value = 0;
                th = new Thread(() =>
                {
                    receiver.StartReceiving();
                });
                th.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receiver!=null) receiver.StopReceiving();
            if (transmitter!=null) transmitter.StopTransmitting();
        }
    }
}
