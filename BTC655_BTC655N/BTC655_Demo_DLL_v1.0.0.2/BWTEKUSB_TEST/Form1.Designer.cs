namespace BTC655_Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_SetIntTime = new System.Windows.Forms.Button();
            this.textBox_IntTime = new System.Windows.Forms.TextBox();
            this.button_SingleScan0 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_Stop2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_DarkCompensate = new System.Windows.Forms.CheckBox();
            this.checkBox_Smooth = new System.Windows.Forms.CheckBox();
            this.textBox_Ave = new System.Windows.Forms.TextBox();
            this.button_SingleScan2 = new System.Windows.Forms.Button();
            this.button_MuitlScan2 = new System.Windows.Forms.Button();
            this.ExtTrigger = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Scancount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBox1_Channel = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_Spectrometer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_ChartReset = new System.Windows.Forms.Button();
            this.button_CaptureDarkSpectrum = new System.Windows.Forms.Button();
            this.button_SaveGraph = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FrameNum = new System.Windows.Forms.TextBox();
            this.button_MuitlScan0 = new System.Windows.Forms.Button();
            this.DeviceTreeView = new System.Windows.Forms.TreeView();
            this.panel40 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel50 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxAutoScan = new System.Windows.Forms.GroupBox();
            this.buttonSetAutoScanFolder = new System.Windows.Forms.Button();
            this.labelAutoScanStatus = new System.Windows.Forms.Label();
            this.buttonStopAutoScan = new System.Windows.Forms.Button();
            this.buttonStartAutoScan = new System.Windows.Forms.Button();
            this.comboBoxAutoScanUnit = new System.Windows.Forms.ComboBox();
            this.textBoxAutoScanInterval = new System.Windows.Forms.TextBox();
            this.labelAutoScanInterval = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Shutter = new System.Windows.Forms.CheckBox();
            this.button_Stop0 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_Stop1 = new System.Windows.Forms.Button();
            this.button_MuitlScan1 = new System.Windows.Forms.Button();
            this.button_SingleScan1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.numericUpDown_CCDTemp = new System.Windows.Forms.NumericUpDown();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.numericUpDown_ExternalTemp = new System.Windows.Forms.NumericUpDown();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.textBox_USB3Temp0 = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.button_USB3GetTemp0 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.textBox_USB3Temp1 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.button_USB3GetTemp1 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.zgOverlay = new SpecGraph.SpecGraphControl();
            this.timerAutoScan = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialogAutoScan = new System.Windows.Forms.FolderBrowserDialog();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel50.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxAutoScan.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CCDTemp)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExternalTemp)).BeginInit();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_SetIntTime
            // 
            this.button_SetIntTime.Location = new System.Drawing.Point(3, 85);
            this.button_SetIntTime.Name = "button_SetIntTime";
            this.button_SetIntTime.Size = new System.Drawing.Size(75, 23);
            this.button_SetIntTime.TabIndex = 4;
            this.button_SetIntTime.Text = "Set IntTime";
            this.button_SetIntTime.UseVisualStyleBackColor = true;
            this.button_SetIntTime.Click += new System.EventHandler(this.button_SetIntTime_Click);
            // 
            // textBox_IntTime
            // 
            this.textBox_IntTime.Location = new System.Drawing.Point(79, 86);
            this.textBox_IntTime.Name = "textBox_IntTime";
            this.textBox_IntTime.Size = new System.Drawing.Size(54, 20);
            this.textBox_IntTime.TabIndex = 5;
            this.textBox_IntTime.Text = "6000";
            this.textBox_IntTime.TextChanged += new System.EventHandler(this.textBox_IntTime_TextChanged);
            // 
            // button_SingleScan0
            // 
            this.button_SingleScan0.Location = new System.Drawing.Point(7, 104);
            this.button_SingleScan0.Name = "button_SingleScan0";
            this.button_SingleScan0.Size = new System.Drawing.Size(75, 23);
            this.button_SingleScan0.TabIndex = 6;
            this.button_SingleScan0.Text = "Single Scan";
            this.button_SingleScan0.UseVisualStyleBackColor = true;
            this.button_SingleScan0.Click += new System.EventHandler(this.button_SingleScan0_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button_Stop2);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.checkBox_DarkCompensate);
            this.panel4.Controls.Add(this.checkBox_Smooth);
            this.panel4.Controls.Add(this.textBox_Ave);
            this.panel4.Controls.Add(this.button_SingleScan2);
            this.panel4.Controls.Add(this.button_MuitlScan2);
            this.panel4.Location = new System.Drawing.Point(439, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(137, 162);
            this.panel4.TabIndex = 3;
            // 
            // button_Stop2
            // 
            this.button_Stop2.Location = new System.Drawing.Point(91, 104);
            this.button_Stop2.Name = "button_Stop2";
            this.button_Stop2.Size = new System.Drawing.Size(39, 50);
            this.button_Stop2.TabIndex = 7;
            this.button_Stop2.Text = "Stop";
            this.button_Stop2.UseVisualStyleBackColor = true;
            this.button_Stop2.Click += new System.EventHandler(this.button_Stop2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Average Num";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smart Mode";
            // 
            // checkBox_DarkCompensate
            // 
            this.checkBox_DarkCompensate.AutoSize = true;
            this.checkBox_DarkCompensate.Location = new System.Drawing.Point(8, 59);
            this.checkBox_DarkCompensate.Name = "checkBox_DarkCompensate";
            this.checkBox_DarkCompensate.Size = new System.Drawing.Size(108, 17);
            this.checkBox_DarkCompensate.TabIndex = 3;
            this.checkBox_DarkCompensate.Text = "DarkCompensate";
            this.checkBox_DarkCompensate.UseVisualStyleBackColor = true;
            // 
            // checkBox_Smooth
            // 
            this.checkBox_Smooth.AutoSize = true;
            this.checkBox_Smooth.Location = new System.Drawing.Point(8, 80);
            this.checkBox_Smooth.Name = "checkBox_Smooth";
            this.checkBox_Smooth.Size = new System.Drawing.Size(62, 17);
            this.checkBox_Smooth.TabIndex = 4;
            this.checkBox_Smooth.Text = "Smooth";
            this.checkBox_Smooth.UseVisualStyleBackColor = true;
            // 
            // textBox_Ave
            // 
            this.textBox_Ave.Location = new System.Drawing.Point(83, 33);
            this.textBox_Ave.Name = "textBox_Ave";
            this.textBox_Ave.Size = new System.Drawing.Size(40, 20);
            this.textBox_Ave.TabIndex = 2;
            this.textBox_Ave.Text = "1";
            // 
            // button_SingleScan2
            // 
            this.button_SingleScan2.Location = new System.Drawing.Point(10, 104);
            this.button_SingleScan2.Name = "button_SingleScan2";
            this.button_SingleScan2.Size = new System.Drawing.Size(75, 23);
            this.button_SingleScan2.TabIndex = 5;
            this.button_SingleScan2.Text = "Single Scan";
            this.button_SingleScan2.UseVisualStyleBackColor = true;
            this.button_SingleScan2.Click += new System.EventHandler(this.button_SingleScan2_Click);
            // 
            // button_MuitlScan2
            // 
            this.button_MuitlScan2.Location = new System.Drawing.Point(10, 132);
            this.button_MuitlScan2.Name = "button_MuitlScan2";
            this.button_MuitlScan2.Size = new System.Drawing.Size(75, 23);
            this.button_MuitlScan2.TabIndex = 6;
            this.button_MuitlScan2.Text = "Multi Scan";
            this.button_MuitlScan2.UseVisualStyleBackColor = true;
            this.button_MuitlScan2.Click += new System.EventHandler(this.button_MuitlScan2_Click);
            // 
            // ExtTrigger
            // 
            this.ExtTrigger.AutoSize = true;
            this.ExtTrigger.Location = new System.Drawing.Point(7, 79);
            this.ExtTrigger.Name = "ExtTrigger";
            this.ExtTrigger.Size = new System.Drawing.Size(77, 17);
            this.ExtTrigger.TabIndex = 2;
            this.ExtTrigger.Text = "Ext Trigger";
            this.ExtTrigger.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_Scancount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.comboBox1_Channel);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.comboBox_Spectrometer);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Controls.Add(this.button_ChartReset);
            this.panel1.Controls.Add(this.button_SetIntTime);
            this.panel1.Controls.Add(this.textBox_IntTime);
            this.panel1.Controls.Add(this.button_CaptureDarkSpectrum);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 190);
            this.panel1.TabIndex = 0;
            // 
            // label_Scancount
            // 
            this.label_Scancount.AutoSize = true;
            this.label_Scancount.Location = new System.Drawing.Point(79, 144);
            this.label_Scancount.Name = "label_Scancount";
            this.label_Scancount.Size = new System.Drawing.Size(13, 13);
            this.label_Scancount.TabIndex = 10;
            this.label_Scancount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Scan Counts:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel7.Location = new System.Drawing.Point(144, 137);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(15, 19);
            this.panel7.TabIndex = 8;
            // 
            // comboBox1_Channel
            // 
            this.comboBox1_Channel.FormattingEnabled = true;
            this.comboBox1_Channel.Location = new System.Drawing.Point(117, 9);
            this.comboBox1_Channel.Name = "comboBox1_Channel";
            this.comboBox1_Channel.Size = new System.Drawing.Size(44, 21);
            this.comboBox1_Channel.TabIndex = 1;
            this.comboBox1_Channel.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Select Spectrometer";
            // 
            // comboBox_Spectrometer
            // 
            this.comboBox_Spectrometer.FormattingEnabled = true;
            this.comboBox_Spectrometer.Location = new System.Drawing.Point(6, 57);
            this.comboBox_Spectrometer.Name = "comboBox_Spectrometer";
            this.comboBox_Spectrometer.Size = new System.Drawing.Size(153, 21);
            this.comboBox_Spectrometer.TabIndex = 3;
            this.comboBox_Spectrometer.SelectedIndexChanged += new System.EventHandler(this.comboBox_Spectrometer_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(62, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Startup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "(ms)";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(79, 111);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(52, 23);
            this.button_Exit.TabIndex = 8;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_ChartReset
            // 
            this.button_ChartReset.Location = new System.Drawing.Point(3, 111);
            this.button_ChartReset.Name = "button_ChartReset";
            this.button_ChartReset.Size = new System.Drawing.Size(75, 23);
            this.button_ChartReset.TabIndex = 7;
            this.button_ChartReset.Text = "Chart Reset";
            this.button_ChartReset.UseVisualStyleBackColor = true;
            this.button_ChartReset.Click += new System.EventHandler(this.button_ChartReset_Click);
            // 
            // button_CaptureDarkSpectrum
            // 
            this.button_CaptureDarkSpectrum.Location = new System.Drawing.Point(3, 160);
            this.button_CaptureDarkSpectrum.Name = "button_CaptureDarkSpectrum";
            this.button_CaptureDarkSpectrum.Size = new System.Drawing.Size(150, 23);
            this.button_CaptureDarkSpectrum.TabIndex = 11;
            this.button_CaptureDarkSpectrum.Text = "Capture Dark Spectrum";
            this.button_CaptureDarkSpectrum.UseVisualStyleBackColor = true;
            this.button_CaptureDarkSpectrum.Click += new System.EventHandler(this.button_CaptureDarkSpectrum_Click);
            // 
            // button_SaveGraph
            // 
            this.button_SaveGraph.Location = new System.Drawing.Point(582, 10);
            this.button_SaveGraph.Name = "button_SaveGraph";
            this.button_SaveGraph.Size = new System.Drawing.Size(150, 23);
            this.button_SaveGraph.TabIndex = 4;
            this.button_SaveGraph.Text = "Save Spectrum";
            this.button_SaveGraph.UseVisualStyleBackColor = true;
            this.button_SaveGraph.Click += new System.EventHandler(this.button_SaveGraph_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Frame Num";
            // 
            // textBox_FrameNum
            // 
            this.textBox_FrameNum.Location = new System.Drawing.Point(73, 47);
            this.textBox_FrameNum.Name = "textBox_FrameNum";
            this.textBox_FrameNum.Size = new System.Drawing.Size(40, 20);
            this.textBox_FrameNum.TabIndex = 2;
            this.textBox_FrameNum.Text = "100";
            // 
            // button_MuitlScan0
            // 
            this.button_MuitlScan0.Location = new System.Drawing.Point(7, 132);
            this.button_MuitlScan0.Name = "button_MuitlScan0";
            this.button_MuitlScan0.Size = new System.Drawing.Size(75, 23);
            this.button_MuitlScan0.TabIndex = 4;
            this.button_MuitlScan0.Text = "Multi Scan";
            this.button_MuitlScan0.UseVisualStyleBackColor = true;
            this.button_MuitlScan0.Click += new System.EventHandler(this.button_MuitlScan0_Click);
            // 
            // DeviceTreeView
            // 
            this.DeviceTreeView.BackColor = System.Drawing.SystemColors.MenuBar;
            this.DeviceTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceTreeView.Location = new System.Drawing.Point(0, 0);
            this.DeviceTreeView.Name = "DeviceTreeView";
            this.DeviceTreeView.Size = new System.Drawing.Size(214, 470);
            this.DeviceTreeView.TabIndex = 0;
            this.DeviceTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DeviceTreeView_AfterSelect);
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel40.Controls.Add(this.DeviceTreeView);
            this.panel40.Controls.Add(this.panel9);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel40.Location = new System.Drawing.Point(0, 0);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(214, 570);
            this.panel40.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel9.Controls.Add(this.pictureBox1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 470);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(214, 100);
            this.panel9.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel50.Controls.Add(this.tabControl1);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel50.Location = new System.Drawing.Point(214, 0);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(789, 195);
            this.panel50.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 195);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxAutoScan);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.button_SaveGraph);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 169);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutoScan
            // 
            this.groupBoxAutoScan.Controls.Add(this.buttonSetAutoScanFolder);
            this.groupBoxAutoScan.Controls.Add(this.labelAutoScanStatus);
            this.groupBoxAutoScan.Controls.Add(this.buttonStopAutoScan);
            this.groupBoxAutoScan.Controls.Add(this.buttonStartAutoScan);
            this.groupBoxAutoScan.Controls.Add(this.comboBoxAutoScanUnit);
            this.groupBoxAutoScan.Controls.Add(this.textBoxAutoScanInterval);
            this.groupBoxAutoScan.Controls.Add(this.labelAutoScanInterval);
            this.groupBoxAutoScan.Location = new System.Drawing.Point(582, 40);
            this.groupBoxAutoScan.Name = "groupBoxAutoScan";
            this.groupBoxAutoScan.Size = new System.Drawing.Size(193, 125);
            this.groupBoxAutoScan.TabIndex = 5;
            this.groupBoxAutoScan.TabStop = false;
            this.groupBoxAutoScan.Text = "Timed Auto-Scan";
            // 
            // buttonSetAutoScanFolder
            // 
            this.buttonSetAutoScanFolder.Location = new System.Drawing.Point(9, 70);
            this.buttonSetAutoScanFolder.Name = "buttonSetAutoScanFolder";
            this.buttonSetAutoScanFolder.Size = new System.Drawing.Size(80, 23);
            this.buttonSetAutoScanFolder.TabIndex = 4;
            this.buttonSetAutoScanFolder.Text = "Set Folder";
            this.buttonSetAutoScanFolder.UseVisualStyleBackColor = true;
            this.buttonSetAutoScanFolder.Click += new System.EventHandler(this.buttonSetAutoScanFolder_Click);
            // 
            // labelAutoScanStatus
            // 
            this.labelAutoScanStatus.AutoSize = true;
            this.labelAutoScanStatus.Location = new System.Drawing.Point(6, 101);
            this.labelAutoScanStatus.Name = "labelAutoScanStatus";
            this.labelAutoScanStatus.Size = new System.Drawing.Size(43, 13);
            this.labelAutoScanStatus.TabIndex = 6;
            this.labelAutoScanStatus.Text = "Status: ";
            // 
            // buttonStopAutoScan
            // 
            this.buttonStopAutoScan.Enabled = false;
            this.buttonStopAutoScan.Location = new System.Drawing.Point(98, 44);
            this.buttonStopAutoScan.Name = "buttonStopAutoScan";
            this.buttonStopAutoScan.Size = new System.Drawing.Size(89, 23);
            this.buttonStopAutoScan.TabIndex = 3;
            this.buttonStopAutoScan.Text = "Stop Scans";
            this.buttonStopAutoScan.UseVisualStyleBackColor = true;
            this.buttonStopAutoScan.Click += new System.EventHandler(this.buttonStopAutoScan_Click);
            // 
            // buttonStartAutoScan
            // 
            this.buttonStartAutoScan.Location = new System.Drawing.Point(9, 44);
            this.buttonStartAutoScan.Name = "buttonStartAutoScan";
            this.buttonStartAutoScan.Size = new System.Drawing.Size(80, 23);
            this.buttonStartAutoScan.TabIndex = 2;
            this.buttonStartAutoScan.Text = "Start Scans";
            this.buttonStartAutoScan.UseVisualStyleBackColor = true;
            this.buttonStartAutoScan.Click += new System.EventHandler(this.buttonStartAutoScan_Click);
            // 
            // comboBoxAutoScanUnit
            // 
            this.comboBoxAutoScanUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutoScanUnit.FormattingEnabled = true;
            this.comboBoxAutoScanUnit.Location = new System.Drawing.Point(121, 17);
            this.comboBoxAutoScanUnit.Name = "comboBoxAutoScanUnit";
            this.comboBoxAutoScanUnit.Size = new System.Drawing.Size(66, 21);
            this.comboBoxAutoScanUnit.TabIndex = 1;
            // 
            // textBoxAutoScanInterval
            // 
            this.textBoxAutoScanInterval.Location = new System.Drawing.Point(55, 17);
            this.textBoxAutoScanInterval.Name = "textBoxAutoScanInterval";
            this.textBoxAutoScanInterval.Size = new System.Drawing.Size(60, 20);
            this.textBoxAutoScanInterval.TabIndex = 0;
            this.textBoxAutoScanInterval.Text = "6";
            // 
            // labelAutoScanInterval
            // 
            this.labelAutoScanInterval.AutoSize = true;
            this.labelAutoScanInterval.Location = new System.Drawing.Point(6, 20);
            this.labelAutoScanInterval.Name = "labelAutoScanInterval";
            this.labelAutoScanInterval.Size = new System.Drawing.Size(45, 13);
            this.labelAutoScanInterval.TabIndex = 0;
            this.labelAutoScanInterval.Text = "Interval:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Shutter);
            this.panel2.Controls.Add(this.button_Stop0);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button_MuitlScan0);
            this.panel2.Controls.Add(this.button_SingleScan0);
            this.panel2.Controls.Add(this.ExtTrigger);
            this.panel2.Location = new System.Drawing.Point(171, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 162);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Shutter
            // 
            this.Shutter.AutoSize = true;
            this.Shutter.Location = new System.Drawing.Point(7, 47);
            this.Shutter.Name = "Shutter";
            this.Shutter.Size = new System.Drawing.Size(89, 17);
            this.Shutter.TabIndex = 1;
            this.Shutter.Text = "Open Shutter";
            this.Shutter.UseVisualStyleBackColor = true;
            this.Shutter.CheckedChanged += new System.EventHandler(this.Shutter_CheckedChanged);
            // 
            // button_Stop0
            // 
            this.button_Stop0.Location = new System.Drawing.Point(87, 104);
            this.button_Stop0.Name = "button_Stop0";
            this.button_Stop0.Size = new System.Drawing.Size(39, 50);
            this.button_Stop0.TabIndex = 5;
            this.button_Stop0.Text = "Stop";
            this.button_Stop0.UseVisualStyleBackColor = true;
            this.button_Stop0.Click += new System.EventHandler(this.button_Stop0_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Normal Mode";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_Stop1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBox_FrameNum);
            this.panel3.Controls.Add(this.button_MuitlScan1);
            this.panel3.Controls.Add(this.button_SingleScan1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(305, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(133, 162);
            this.panel3.TabIndex = 2;
            // 
            // button_Stop1
            // 
            this.button_Stop1.Location = new System.Drawing.Point(87, 104);
            this.button_Stop1.Name = "button_Stop1";
            this.button_Stop1.Size = new System.Drawing.Size(39, 50);
            this.button_Stop1.TabIndex = 5;
            this.button_Stop1.Text = "Stop";
            this.button_Stop1.UseVisualStyleBackColor = true;
            this.button_Stop1.Click += new System.EventHandler(this.button_Stop1_Click);
            // 
            // button_MuitlScan1
            // 
            this.button_MuitlScan1.Location = new System.Drawing.Point(7, 132);
            this.button_MuitlScan1.Name = "button_MuitlScan1";
            this.button_MuitlScan1.Size = new System.Drawing.Size(75, 23);
            this.button_MuitlScan1.TabIndex = 4;
            this.button_MuitlScan1.Text = "Multi Scan";
            this.button_MuitlScan1.UseVisualStyleBackColor = true;
            this.button_MuitlScan1.Click += new System.EventHandler(this.button_MuitlScan1_Click);
            // 
            // button_SingleScan1
            // 
            this.button_SingleScan1.Location = new System.Drawing.Point(7, 104);
            this.button_SingleScan1.Name = "button_SingleScan1";
            this.button_SingleScan1.Size = new System.Drawing.Size(75, 23);
            this.button_SingleScan1.TabIndex = 3;
            this.button_SingleScan1.Text = "Single Scan";
            this.button_SingleScan1.UseVisualStyleBackColor = true;
            this.button_SingleScan1.Click += new System.EventHandler(this.button_SingleScan1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Speed Mode";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox26);
            this.tabPage2.Controls.Add(this.groupBox25);
            this.tabPage2.Controls.Add(this.groupBox22);
            this.tabPage2.Controls.Add(this.groupBox21);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 169);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Temperature";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label10);
            this.groupBox26.Controls.Add(this.label46);
            this.groupBox26.Controls.Add(this.numericUpDown_CCDTemp);
            this.groupBox26.Location = new System.Drawing.Point(7, 74);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(235, 63);
            this.groupBox26.TabIndex = 2;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "CCD Temperature Set";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(7, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "(-30 °C...+10 °C)";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(5, 27);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(90, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Temperature(°C) :";
            // 
            // numericUpDown_CCDTemp
            // 
            this.numericUpDown_CCDTemp.Location = new System.Drawing.Point(114, 25);
            this.numericUpDown_CCDTemp.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_CCDTemp.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.numericUpDown_CCDTemp.Name = "numericUpDown_CCDTemp";
            this.numericUpDown_CCDTemp.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_CCDTemp.TabIndex = 1;
            this.numericUpDown_CCDTemp.ValueChanged += new System.EventHandler(this.numericUpDown_CCDTemp_ValueChanged);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label11);
            this.groupBox25.Controls.Add(this.label56);
            this.groupBox25.Controls.Add(this.numericUpDown_ExternalTemp);
            this.groupBox25.Location = new System.Drawing.Point(249, 74);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(230, 63);
            this.groupBox25.TabIndex = 3;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "External Temperature Set";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(6, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "(0 °C...+30 °C)";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label56.Location = new System.Drawing.Point(5, 27);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(90, 13);
            this.label56.TabIndex = 0;
            this.label56.Text = "Temperature(°C) :";
            // 
            // numericUpDown_ExternalTemp
            // 
            this.numericUpDown_ExternalTemp.Location = new System.Drawing.Point(111, 25);
            this.numericUpDown_ExternalTemp.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_ExternalTemp.Name = "numericUpDown_ExternalTemp";
            this.numericUpDown_ExternalTemp.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_ExternalTemp.TabIndex = 1;
            this.numericUpDown_ExternalTemp.ValueChanged += new System.EventHandler(this.numericUpDown_ExternalTemp_ValueChanged);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.textBox_USB3Temp0);
            this.groupBox22.Controls.Add(this.label58);
            this.groupBox22.Controls.Add(this.button_USB3GetTemp0);
            this.groupBox22.Location = new System.Drawing.Point(8, 15);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(235, 48);
            this.groupBox22.TabIndex = 0;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "CCD Temperature Monitor";
            // 
            // textBox_USB3Temp0
            // 
            this.textBox_USB3Temp0.Enabled = false;
            this.textBox_USB3Temp0.Location = new System.Drawing.Point(112, 20);
            this.textBox_USB3Temp0.Name = "textBox_USB3Temp0";
            this.textBox_USB3Temp0.Size = new System.Drawing.Size(46, 20);
            this.textBox_USB3Temp0.TabIndex = 1;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(5, 22);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(90, 13);
            this.label58.TabIndex = 0;
            this.label58.Text = "Temperature(°C) :";
            // 
            // button_USB3GetTemp0
            // 
            this.button_USB3GetTemp0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_USB3GetTemp0.Location = new System.Drawing.Point(160, 17);
            this.button_USB3GetTemp0.Name = "button_USB3GetTemp0";
            this.button_USB3GetTemp0.Size = new System.Drawing.Size(69, 23);
            this.button_USB3GetTemp0.TabIndex = 2;
            this.button_USB3GetTemp0.Text = "Get Temp";
            this.button_USB3GetTemp0.UseVisualStyleBackColor = true;
            this.button_USB3GetTemp0.Click += new System.EventHandler(this.button_USB3GetTemp0_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.textBox_USB3Temp1);
            this.groupBox21.Controls.Add(this.label57);
            this.groupBox21.Controls.Add(this.button_USB3GetTemp1);
            this.groupBox21.Location = new System.Drawing.Point(249, 15);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(231, 48);
            this.groupBox21.TabIndex = 1;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "External Temperature Monitor";
            // 
            // textBox_USB3Temp1
            // 
            this.textBox_USB3Temp1.Enabled = false;
            this.textBox_USB3Temp1.Location = new System.Drawing.Point(106, 20);
            this.textBox_USB3Temp1.Name = "textBox_USB3Temp1";
            this.textBox_USB3Temp1.Size = new System.Drawing.Size(46, 20);
            this.textBox_USB3Temp1.TabIndex = 1;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label57.Location = new System.Drawing.Point(5, 22);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(90, 13);
            this.label57.TabIndex = 0;
            this.label57.Text = "Temperature(°C) :";
            // 
            // button_USB3GetTemp1
            // 
            this.button_USB3GetTemp1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_USB3GetTemp1.Location = new System.Drawing.Point(154, 17);
            this.button_USB3GetTemp1.Name = "button_USB3GetTemp1";
            this.button_USB3GetTemp1.Size = new System.Drawing.Size(69, 23);
            this.button_USB3GetTemp1.TabIndex = 2;
            this.button_USB3GetTemp1.Text = "Get Temp";
            this.button_USB3GetTemp1.UseVisualStyleBackColor = true;
            this.button_USB3GetTemp1.Click += new System.EventHandler(this.button_USB3GetTemp1_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.zgOverlay);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(214, 195);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(789, 375);
            this.panel6.TabIndex = 2;
            // 
            // zgOverlay
            // 
            this.zgOverlay.BackColor = System.Drawing.SystemColors.Window;
            this.zgOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgOverlay.Location = new System.Drawing.Point(0, 0);
            this.zgOverlay.Name = "zgOverlay";
            this.zgOverlay.ScrollGrace = 0D;
            this.zgOverlay.ScrollMaxX = 0D;
            this.zgOverlay.ScrollMaxY = 0D;
            this.zgOverlay.ScrollMaxY2 = 0D;
            this.zgOverlay.ScrollMinX = 0D;
            this.zgOverlay.ScrollMinY = 0D;
            this.zgOverlay.ScrollMinY2 = 0D;
            this.zgOverlay.Size = new System.Drawing.Size(789, 375);
            this.zgOverlay.TabIndex = 0;
            this.zgOverlay.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 570);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel50);
            this.Controls.Add(this.panel40);
            this.Name = "Form1";
            this.Text = "BTC655 Demo using BWTEKUSB.DLL (V1.0.0.2)";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel50.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxAutoScan.ResumeLayout(false);
            this.groupBoxAutoScan.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CCDTemp)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExternalTemp)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_SetIntTime;
        private System.Windows.Forms.TextBox textBox_IntTime;
        private System.Windows.Forms.Button button_SingleScan0;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_MuitlScan0;
        private System.Windows.Forms.Button button_ChartReset;
        private System.Windows.Forms.TreeView DeviceTreeView;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.Panel panel50;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_SingleScan2;
        private System.Windows.Forms.Button button_MuitlScan2;
        private System.Windows.Forms.TextBox textBox_Ave;
        private System.Windows.Forms.CheckBox ExtTrigger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FrameNum;
        private System.Windows.Forms.CheckBox checkBox_Smooth;
        private System.Windows.Forms.CheckBox checkBox_DarkCompensate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_MuitlScan1;
        private System.Windows.Forms.Button button_SingleScan1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Stop1;
        private System.Windows.Forms.Button button_Stop2;
        private System.Windows.Forms.Button button_Stop0;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_Spectrometer;
        private System.Windows.Forms.ComboBox comboBox1_Channel;
        private SpecGraph.SpecGraphControl zgOverlay;
        private System.Windows.Forms.CheckBox Shutter;
        private System.Windows.Forms.Label label_Scancount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.NumericUpDown numericUpDown_CCDTemp;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.NumericUpDown numericUpDown_ExternalTemp;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.TextBox textBox_USB3Temp0;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button_USB3GetTemp0;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.TextBox textBox_USB3Temp1;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button button_USB3GetTemp1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_SaveGraph;
        private System.Windows.Forms.Button button_CaptureDarkSpectrum;
        private System.Windows.Forms.GroupBox groupBoxAutoScan;
        private System.Windows.Forms.Label labelAutoScanStatus;
        private System.Windows.Forms.Button buttonStopAutoScan;
        private System.Windows.Forms.Button buttonStartAutoScan;
        private System.Windows.Forms.ComboBox comboBoxAutoScanUnit;
        private System.Windows.Forms.TextBox textBoxAutoScanInterval;
        private System.Windows.Forms.Label labelAutoScanInterval;
        private System.Windows.Forms.Timer timerAutoScan;
        private System.Windows.Forms.Button buttonSetAutoScanFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogAutoScan;
    }
}

