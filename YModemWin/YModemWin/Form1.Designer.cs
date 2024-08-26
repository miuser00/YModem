namespace YModemWin
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_port = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_BrowserFile = new System.Windows.Forms.Button();
            this.cmb_baud = new System.Windows.Forms.ComboBox();
            this.txt_SendByte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pgb_send = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AllSendByte = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_SendStatus = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_SEND_TotalPackage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_SendPackage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chb_SendTimeout = new System.Windows.Forms.CheckBox();
            this.cmb_uploadfileNames = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.pgb_receive = new System.Windows.Forms.ProgressBar();
            this.txt_AllReceiveByte = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Receive = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ReceiveByte = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_BrowserSaveDirectory = new System.Windows.Forms.Button();
            this.txt_SaveDirectory = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_ModifyDate = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chb_ReceiveTimeout = new System.Windows.Forms.CheckBox();
            this.txt_RSV_TotalPackage = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_ReceivePackage = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_ReceiveStatus = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btn_port
            // 
            this.btn_port.Location = new System.Drawing.Point(389, 23);
            this.btn_port.Name = "btn_port";
            this.btn_port.Size = new System.Drawing.Size(75, 23);
            this.btn_port.TabIndex = 0;
            this.btn_port.Text = "打开";
            this.btn_port.UseVisualStyleBackColor = true;
            this.btn_port.Click += new System.EventHandler(this.btn_port_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(66, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // btn_BrowserFile
            // 
            this.btn_BrowserFile.Location = new System.Drawing.Point(304, 24);
            this.btn_BrowserFile.Name = "btn_BrowserFile";
            this.btn_BrowserFile.Size = new System.Drawing.Size(66, 23);
            this.btn_BrowserFile.TabIndex = 2;
            this.btn_BrowserFile.Text = "浏览...";
            this.btn_BrowserFile.UseVisualStyleBackColor = true;
            this.btn_BrowserFile.Click += new System.EventHandler(this.btn_select_files_Click);
            // 
            // cmb_baud
            // 
            this.cmb_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_baud.FormattingEnabled = true;
            this.cmb_baud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "115200",
            "921600",
            "2000000",
            "3000000"});
            this.cmb_baud.Location = new System.Drawing.Point(277, 23);
            this.cmb_baud.Name = "cmb_baud";
            this.cmb_baud.Size = new System.Drawing.Size(93, 20);
            this.cmb_baud.TabIndex = 3;
            // 
            // txt_SendByte
            // 
            this.txt_SendByte.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_SendByte.Location = new System.Drawing.Point(262, 61);
            this.txt_SendByte.Name = "txt_SendByte";
            this.txt_SendByte.ReadOnly = true;
            this.txt_SendByte.Size = new System.Drawing.Size(74, 21);
            this.txt_SendByte.TabIndex = 5;
            this.txt_SendByte.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "发送字节";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "端口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "波特率";
            // 
            // pgb_send
            // 
            this.pgb_send.Location = new System.Drawing.Point(66, 60);
            this.pgb_send.Name = "pgb_send";
            this.pgb_send.Size = new System.Drawing.Size(119, 23);
            this.pgb_send.Step = 1;
            this.pgb_send.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "文件路径";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "总字节";
            // 
            // txt_AllSendByte
            // 
            this.txt_AllSendByte.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_AllSendByte.Location = new System.Drawing.Point(389, 60);
            this.txt_AllSendByte.Name = "txt_AllSendByte";
            this.txt_AllSendByte.ReadOnly = true;
            this.txt_AllSendByte.Size = new System.Drawing.Size(75, 21);
            this.txt_AllSendByte.TabIndex = 9;
            this.txt_AllSendByte.Text = "-";
            // 
            // btn_Send
            // 
            this.btn_Send.Enabled = false;
            this.btn_Send.Location = new System.Drawing.Point(389, 24);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 10;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "传输进度";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_port);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.cmb_baud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 58);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_SendStatus);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt_SEND_TotalPackage);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txt_SendPackage);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.chb_SendTimeout);
            this.groupBox2.Controls.Add(this.cmb_uploadfileNames);
            this.groupBox2.Controls.Add(this.btn_BrowserFile);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_SendByte);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_Send);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_AllSendByte);
            this.groupBox2.Controls.Add(this.pgb_send);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 130);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件发送";
            // 
            // btn_SendStatus
            // 
            this.btn_SendStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SendStatus.Font = new System.Drawing.Font("宋体", 8F);
            this.btn_SendStatus.Location = new System.Drawing.Point(115, 96);
            this.btn_SendStatus.Name = "btn_SendStatus";
            this.btn_SendStatus.Size = new System.Drawing.Size(70, 20);
            this.btn_SendStatus.TabIndex = 22;
            this.btn_SendStatus.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(80, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "状态";
            // 
            // txt_SEND_TotalPackage
            // 
            this.txt_SEND_TotalPackage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_SEND_TotalPackage.Location = new System.Drawing.Point(389, 94);
            this.txt_SEND_TotalPackage.Name = "txt_SEND_TotalPackage";
            this.txt_SEND_TotalPackage.ReadOnly = true;
            this.txt_SEND_TotalPackage.Size = new System.Drawing.Size(75, 21);
            this.txt_SEND_TotalPackage.TabIndex = 18;
            this.txt_SEND_TotalPackage.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(343, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "总包数";
            // 
            // txt_SendPackage
            // 
            this.txt_SendPackage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_SendPackage.Location = new System.Drawing.Point(262, 94);
            this.txt_SendPackage.Name = "txt_SendPackage";
            this.txt_SendPackage.ReadOnly = true;
            this.txt_SendPackage.Size = new System.Drawing.Size(75, 21);
            this.txt_SendPackage.TabIndex = 16;
            this.txt_SendPackage.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(215, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "包序号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "3秒超时";
            // 
            // chb_SendTimeout
            // 
            this.chb_SendTimeout.AutoSize = true;
            this.chb_SendTimeout.Checked = true;
            this.chb_SendTimeout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_SendTimeout.Location = new System.Drawing.Point(58, 98);
            this.chb_SendTimeout.Name = "chb_SendTimeout";
            this.chb_SendTimeout.Size = new System.Drawing.Size(15, 14);
            this.chb_SendTimeout.TabIndex = 14;
            this.chb_SendTimeout.UseVisualStyleBackColor = true;
            // 
            // cmb_uploadfileNames
            // 
            this.cmb_uploadfileNames.FormattingEnabled = true;
            this.cmb_uploadfileNames.Location = new System.Drawing.Point(66, 26);
            this.cmb_uploadfileNames.Name = "cmb_uploadfileNames";
            this.cmb_uploadfileNames.Size = new System.Drawing.Size(220, 20);
            this.cmb_uploadfileNames.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(343, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "总字节";
            // 
            // pgb_receive
            // 
            this.pgb_receive.Location = new System.Drawing.Point(66, 60);
            this.pgb_receive.Name = "pgb_receive";
            this.pgb_receive.Size = new System.Drawing.Size(120, 23);
            this.pgb_receive.Step = 1;
            this.pgb_receive.TabIndex = 7;
            // 
            // txt_AllReceiveByte
            // 
            this.txt_AllReceiveByte.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_AllReceiveByte.Location = new System.Drawing.Point(390, 60);
            this.txt_AllReceiveByte.Name = "txt_AllReceiveByte";
            this.txt_AllReceiveByte.ReadOnly = true;
            this.txt_AllReceiveByte.Size = new System.Drawing.Size(74, 21);
            this.txt_AllReceiveByte.TabIndex = 9;
            this.txt_AllReceiveByte.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "保存目录";
            // 
            // btn_Receive
            // 
            this.btn_Receive.Location = new System.Drawing.Point(390, 20);
            this.btn_Receive.Name = "btn_Receive";
            this.btn_Receive.Size = new System.Drawing.Size(75, 23);
            this.btn_Receive.TabIndex = 10;
            this.btn_Receive.Text = "接收";
            this.btn_Receive.UseVisualStyleBackColor = true;
            this.btn_Receive.Click += new System.EventHandler(this.btn_Receive_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "接收字节";
            // 
            // txt_ReceiveByte
            // 
            this.txt_ReceiveByte.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ReceiveByte.Location = new System.Drawing.Point(263, 61);
            this.txt_ReceiveByte.Name = "txt_ReceiveByte";
            this.txt_ReceiveByte.ReadOnly = true;
            this.txt_ReceiveByte.Size = new System.Drawing.Size(74, 21);
            this.txt_ReceiveByte.TabIndex = 5;
            this.txt_ReceiveByte.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "传输进度";
            // 
            // btn_BrowserSaveDirectory
            // 
            this.btn_BrowserSaveDirectory.Location = new System.Drawing.Point(305, 20);
            this.btn_BrowserSaveDirectory.Name = "btn_BrowserSaveDirectory";
            this.btn_BrowserSaveDirectory.Size = new System.Drawing.Size(66, 23);
            this.btn_BrowserSaveDirectory.TabIndex = 2;
            this.btn_BrowserSaveDirectory.Text = "浏览...";
            this.btn_BrowserSaveDirectory.UseVisualStyleBackColor = true;
            this.btn_BrowserSaveDirectory.Click += new System.EventHandler(this.btn_BrowserSaveDirectory_Click);
            // 
            // txt_SaveDirectory
            // 
            this.txt_SaveDirectory.Location = new System.Drawing.Point(66, 22);
            this.txt_SaveDirectory.Name = "txt_SaveDirectory";
            this.txt_SaveDirectory.Size = new System.Drawing.Size(221, 21);
            this.txt_SaveDirectory.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "文件名";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(67, 130);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.ReadOnly = true;
            this.txt_FileName.Size = new System.Drawing.Size(171, 21);
            this.txt_FileName.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(247, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "日期";
            // 
            // txt_ModifyDate
            // 
            this.txt_ModifyDate.Location = new System.Drawing.Point(294, 130);
            this.txt_ModifyDate.Name = "txt_ModifyDate";
            this.txt_ModifyDate.ReadOnly = true;
            this.txt_ModifyDate.Size = new System.Drawing.Size(171, 21);
            this.txt_ModifyDate.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.chb_ReceiveTimeout);
            this.groupBox3.Controls.Add(this.txt_RSV_TotalPackage);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txt_ReceivePackage);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.btn_ReceiveStatus);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txt_ModifyDate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txt_FileName);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txt_SaveDirectory);
            this.groupBox3.Controls.Add(this.btn_BrowserSaveDirectory);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txt_ReceiveByte);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btn_Receive);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_AllReceiveByte);
            this.groupBox3.Controls.Add(this.pgb_receive);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 166);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件接收";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 32;
            this.label18.Text = "3秒超时";
            // 
            // chb_ReceiveTimeout
            // 
            this.chb_ReceiveTimeout.AutoSize = true;
            this.chb_ReceiveTimeout.Checked = true;
            this.chb_ReceiveTimeout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_ReceiveTimeout.Location = new System.Drawing.Point(58, 99);
            this.chb_ReceiveTimeout.Name = "chb_ReceiveTimeout";
            this.chb_ReceiveTimeout.Size = new System.Drawing.Size(15, 14);
            this.chb_ReceiveTimeout.TabIndex = 31;
            this.chb_ReceiveTimeout.UseVisualStyleBackColor = true;
            // 
            // txt_RSV_TotalPackage
            // 
            this.txt_RSV_TotalPackage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_RSV_TotalPackage.Location = new System.Drawing.Point(390, 96);
            this.txt_RSV_TotalPackage.Name = "txt_RSV_TotalPackage";
            this.txt_RSV_TotalPackage.ReadOnly = true;
            this.txt_RSV_TotalPackage.Size = new System.Drawing.Size(75, 21);
            this.txt_RSV_TotalPackage.TabIndex = 29;
            this.txt_RSV_TotalPackage.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(344, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 30;
            this.label19.Text = "总包数";
            // 
            // txt_ReceivePackage
            // 
            this.txt_ReceivePackage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ReceivePackage.Location = new System.Drawing.Point(263, 96);
            this.txt_ReceivePackage.Name = "txt_ReceivePackage";
            this.txt_ReceivePackage.ReadOnly = true;
            this.txt_ReceivePackage.Size = new System.Drawing.Size(75, 21);
            this.txt_ReceivePackage.TabIndex = 27;
            this.txt_ReceivePackage.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(216, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 28;
            this.label20.Text = "包序号";
            // 
            // btn_ReceiveStatus
            // 
            this.btn_ReceiveStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReceiveStatus.Font = new System.Drawing.Font("宋体", 8F);
            this.btn_ReceiveStatus.Location = new System.Drawing.Point(116, 97);
            this.btn_ReceiveStatus.Name = "btn_ReceiveStatus";
            this.btn_ReceiveStatus.Size = new System.Drawing.Size(70, 20);
            this.btn_ReceiveStatus.TabIndex = 26;
            this.btn_ReceiveStatus.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(79, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "状态";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(511, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "                           ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 415);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(527, 454);
            this.MinimumSize = new System.Drawing.Size(527, 454);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YModem Transceiver V0.31";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_port;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_BrowserFile;
        private System.Windows.Forms.ComboBox cmb_baud;
        private System.Windows.Forms.TextBox txt_SendByte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pgb_send;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_AllSendByte;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cmb_uploadfileNames;
        private System.Windows.Forms.Button btn_SendStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_SEND_TotalPackage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_SendPackage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chb_SendTimeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar pgb_receive;
        private System.Windows.Forms.TextBox txt_AllReceiveByte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Receive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ReceiveByte;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_BrowserSaveDirectory;
        private System.Windows.Forms.TextBox txt_SaveDirectory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_ModifyDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_RSV_TotalPackage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_ReceivePackage;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_ReceiveStatus;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chb_ReceiveTimeout;
    }
}

