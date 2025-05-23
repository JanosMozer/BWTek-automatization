using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CyUSB;
using System.Threading;
using SpecGraph;
using System.Runtime.InteropServices;
using System.IO; //StreamWriter


namespace BTC655_Demo
{
    public partial class Form1 : Form
    {
        //The total number of connected spectrometers
        public const int DEVICE_NUM_MAX = 32;

        //the unique identify value of spectrometer
        public enum TypeID
        {
            UnKnown = -1,
            BTC110_MODE = 0,
            BRC100_MODE = 1,
            BTC120_MODE = 2,
            BTC121_MODE = 3,
            BTC200_MODE = 4,
            BTC300_MODE = 5,
            BTC320_MODE = 6,
            BTC400_MODE = 7,
            BTC500_MODE = 8,
            BRC110_MODE = 9,
            BTC111_MODE = 10,
            BRC111A_MODE = 11,
            BTC611_MODE = 12,
            BRC711_MODE = 13,
            BTC112_MODE = 14,
            BTC211_MODE = 15,
            BTC15x_MODE = 16,
            BRC112_MODE = 17,
            BRC311_MODE = 18,
            BTC311_MODE = 19,
            BTC610_MODE = 20,
            BTC321_MODE = 21,
            BTF111_MODE = 22,
            BTC811_MODE = 23,
            BTC221_MODE = 24,
            BTC251_MODE = 25,
            BTC711_MODE = 26,
            BTC611E_512_MODE = 27,
            BTC611E_1024_MODE = 28,
            BTC711E_512_MODE = 29,
            BTC711E_1024_MODE = 30,
            BRC711E_512_MODE = 31,
            BRC711E_1024_MODE = 32,
            BTF113_MODE = 33,
            BWS003_MODE = 34,
            BWS004_MODE = 35,
            BTC221E_G9208_256W_MODE = 36,
            BTU111_MODE = 37,
            BTC251E_512_RS232_MODE = 38,
            BTC251E_512_MODE = 39,
            BTC261E_512_RS232_MODE = 40,
            BTC261E_512_MODE = 41,
            BTC261E_256_MODE = 42,
            BTC261E_1024_MODE = 43,
            BRC131_MODE = 44,
            BTC262E_256_MODE = 45,
            BTC262E_512_MODE = 46,
            BTC262E_1024_MODE = 47,
            BRC100_OEM_MODE = 48,
            BRC641_MODE = 49,
            BTC613E_512_MODE = 50,
            BTC613E_1024_MODE = 51,
            BTC651E_512_MODE = 52,
            BTC651E_1024_MODE = 53,
            BWS225_256_MODE = 54,
            BWS225_512_MODE = 55,
            BTC641_MODE = 56,
            BWS102_MODE = 57,
            BWS003B_MODE = 58,
            BWS435_MODE = 59,
            BRC642E_2048_MODE = 60,
            BTC263E_256_MODE = 61,
            BRC113_MODE = 62,
            BRC112P_MODE = 63,
            BTC261P_512_MODE = 64,
            BRC115_MODE = 65,
            BTC665_MODE = 66,
            BTC675_MODE = 67,
            BTC655_MODE = 68,
            BTC264P_512_MODE = 69,
            BTC264P_1024_MODE = 70,
            BRC1k_MODE = 71,
            BTC665N_MODE = 72,
            BRC115P_MODE = 73,
            BTC655N_MODE = 74,
            BTC264P_512_RS232_MODE = 75,
            BTC261P_256_MODE = 76,
            BTC667N_MODE = 77,
            BTC675N_MODE = 78,
            BTC261P_1024_MODE = 79

        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct Spec_Para_Struct
        {
            public int usbtype;                    //usetype=2-->USB2.0 Interface, usetype=3-->USB3.0 Interface 
            public int channel;                    //channel is 0...N-1, N is the connected spectrometers number.

            public string cCode;                   //ccode is 3 or 4 identify character for every spectrometer. 
            public string model;                   //spectrometer model name 
            public string spectrometer_name;       //spectrometer name (nick name)
            public int spectrometer_type;          //the unique identify value of spectrometer  
            public int pixel_number;               //CCD pixel number of spectrometer.
            public int timing_mode;                //timing mode of spectrometer
            public int input_mode;                 //input mode of spectrometer
            public int xaxis_data_reverse;         //the x-axis inverse flag of spectrum

            public double inttime;                 //exposure time of spectrometer (double format)
            public int inttime_int;                //exposure time of spectrometer (integer format)
            public double inttime_min;             //minimum exposure time of spectrometer
            public int inttime_base;               //the offset of exposure time 
            public int inttime_unit;               //the unit of exposure time,0=us, 1=ms 

            public int trigger_mode;               //scan trigger flag, 0=internal trigger, 1=external trigger

            public double starttime;               //the time stamp of data scan start 
            public double endtime;                 //the time stamp of data scan finish
            public double deltatime;               //the total time period of data scan 

            public double coefficient_a0;          //A0,coefficient of pixel convert to wavelength
            public double coefficient_a1;          //A1,coefficient of pixel convert to wavelength
            public double coefficient_a2;          //A2,coefficient of pixel convert to wavelength
            public double coefficient_a3;          //A3,coefficient of pixel convert to wavelength
                                                   //Wavelength(pixel)=A0+A1*pixel+A2*pixel^2+A3*pixel^3

            public double coefficient_b0;          //B0,coefficient of wavelength convert to pixel
            public double coefficient_b1;          //B1,coefficient of wavelength convert to pixel
            public double coefficient_b2;          //B2,coefficient of wavelength convert to pixel
            public double coefficient_b3;          //B3,coefficient of wavelength convert to pixel
                                                   //pixel=B0+B1*wavelength+B2*wavelength^2+B3*wavelength^3

            public double[] wavelength;            //the array of wavelength           
            public ushort[] DataArray;            //the array of spectrum data

            public int scan_flag;                  //scan flag, 1=single scan, 2=continuously scan 
            public int stop_flag;                  //stop flag, 1=stop scan 
            public int scan_mode;                  //scan mode, 0=Normal Scan Mode, 1=Speed Scan Mode,2=Smart Scan Mode 
            public int frame_num;                  //the frame number, every frame has 2048 pixel data.
            public int ave_num;                    //average number of scan data
            public int darkcompensate_flag;        //dark compensate flag of spectrum.
            public int smooth_flag;                //smooth flag of spectrum. 1=do sommth (Savitzky-galay), 0=no smooth  
            public int shutter_inverse;            //Shutter pin inverse flag
            public int CCDTemp_Set;                //the default setting temperature of CCD
            public int ExternalTemp_Set;           //the default setting temperature of External Board.

        }
        public static Spec_Para_Struct[] spec_para = new Spec_Para_Struct[DEVICE_NUM_MAX + 1];

        public int[] spec_initialize;             //initialize flag array of conneccted spectrometers  
        public int[] spec_channel;                //channel value array of connected spectrometers
        public int[] spec_usbtype;                //USB interface type of connected spectrometers, 2=usb2.03=usb3.0
        string[] spec_ccode;                      //ccode array of connected spectrometers  
        string[] spec_deviceid;                  //deviceid array of connected spectrometers

        int device_count;                         //the total number of connected spectrometers  
        int current_deviceindex;                  //the active index of connected spectrometers 
        int scan_count = 0;                         //the count value of scan data

        USBDeviceList usbDevices = null;          //the instance of USBDevice List     
        CyUSBDevice spectrometerDevice = null;    //the instance of USB Device     
        CyBulkEndPoint inEndpoint = null;         //the instance of Bulk In-Endpoint     
        CyBulkEndPoint outEndpoint = null;        //the instance of Bulk Out-Endpoint     

        Thread td;                                //thread
        delegate void DeleFunc();                 //delagate function 
        DeleFunc de;
        DeleFunc de1;

        Graphics myGraphics;
        double[] databuf;                         //data array

        //the setting of display chart
        int chart_xMin;                           //x-axis min of chart 
        int chart_xMax;                           //x-axis max of chart 
        int chart_yMin;                           //y-axis min of chart 
        int chart_yMax;                           //y-axis max of chart 

        // Dark spectrum data
        bool isDarkSpectrumCaptured = false;
        ushort[] darkSpectrum;

        // Auto-Scan fields
        private bool isAutoScanning = false;
        private string autoScanSaveFolder;
        private int autoScanIntervalMilliseconds;


        //Initialize USB Devices
        [DllImport("BWTEKUSB.DLL")]
        static extern bool InitDevices();

        //Get the ccode of spectrometer
        [DllImport("BWTEKUSB.dll")]
        public static extern Int32 GetCCode(byte[] pCCode, Int32 nChannel);

        //Get the usb interface of spectrometer
        [DllImport("BWTEKUSB.dll")]
        public static extern Int32 GetUSBType(ref int USBType, Int32 nChannel);

        //get the number of connected spectrometers
        [DllImport("BWTEKUSB.dll")]
        public static extern int GetDeviceCount();

        //get the valid channel value of connected spectrometers
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekSetupChannel(Int32 nChannel, [In, Out] Byte[] pChannelStatus);

        //read EEPROM content of spectrometer
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekReadEEPROMUSB(string filename, int chnnel);

        //initialize spectrometer
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekTestUSB(int TimngMode, int PixelNumber, int InputMode, int chnnel, int pParam);

        //set the external trigger timeout and multiply of exposure time
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekSetTimingsUSB(int lTriggerExit, int Multiply, int channel);

        //set the exposure time of spectrometer
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekSetTimeUSB(int nTime, int channel);

        //set the exposure time unit (ms,us)
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekSetTimeUnitUSB(int nTimeUnit, int channel);

        //set the offset of exposure time
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekSetTimeBase0USB(Int32 lTimeBase, Int32 nchannel);

        //set the exposure time unit (ms,us) for BTC261E/BTC262E
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekWriteValue(Int32 nMode, Int32 SetValue, Int32 nChannel);

        //get the exposure time unit (ms,us) for BTC261E/BTC262E
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekReadValue(Int32 nMode, ref Int32 GetValue, Int32 nChannel);

        //set lownoise mode for BTC665N
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekSetLowNoiseModeUSB(int nMode, int channel);


        //get the spectrum of spectrometer (normal mode)
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekDataReadUSB(int TriggerMode, [In, Out] UInt16[] MemHandle, int channel);

        //get the spectrums of spectrometer (speed mode)
        [DllImport("bwtekusb.dll")]
        private static extern Int32 bwtekFrameDataReadUSB(Int32 nFrameNum, Int32 nTriggerMode, UInt16[] pArray, Int32 nChannel);

        //get the spectrum of spectrometer (smart mode)
        [DllImport("bwtekusb.dll")]
        private static extern Int32 bwtekDSPDataReadUSB(Int32 nAveNum, Int32 nSmoothing, Int32 nDarkCompensate, Int32 nTriggerMode, UInt16[] pArray, Int32 nChannel);

        //erase the customer eeprom (64K)
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekEraseBlockUSB(Int32 nChannel);

        //write one block to customer eeprom 
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekWriteBlockUSB(Int32 nAddrress, byte[] pDataArray, Int32 nNum, Int32 nChannel);

        //read one block to customer eeprom 
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekReadBlockUSB(Int32 nAddrress, byte[] pDataArray, Int32 nNum, Int32 nChannel);

        //close the commuminication with specify spectrometer, it should be used when close programm.
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekCloseUSB(int channel);

        //set TTL output
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekSetTTLOut(int nNo, int nSetValue, int nInverse, int chnnel);

        //get TTL input
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekGetTTLIn(int nNo, [In, Out] int[] pGetValue, int chnnel);

        //set Analog output
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekSetAnalogOut(int nNo, int nSetValue, int chnnel);

        //get Analog input
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekGetAnalogIn(int nNo, [In, Out] int[] pIntegerValue, [In, Out] double[] pDoubleVoltage, int chnnel);

        //read the ccd temperature
        [DllImport("bwtekusb.dll")]
        public static extern Int32 bwtekReadTemperature(Int32 nADChannel, ref Int32 nADValue, ref double dTemperature, Int32 nChannel);

        //define the pulse output
        [DllImport("BWTEKUSB.DLL")]
        static extern int bwtekSetExtPulse(int nOnOff, int nDelayTime, int nHighWidth, int nLowWidth, int nPulseNo, int nInverse, int chnnel);


        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            init_variable();
            InitializeAutoScanComponents(); // Call new initialization method

            usbDevices = new USBDeviceList(CyConst.DEVICES_CYUSB);
            RefreshDeviceTree();
            usbDevices.DeviceAttached += new EventHandler(usbDevices_DeviceAttached);
            usbDevices.DeviceRemoved += new EventHandler(usbDevices_DeviceRemoved);
        }

        private void InitializeAutoScanComponents()
        {
            // Populate ComboBox for units
            comboBoxAutoScanUnit.Items.AddRange(new object[] { "Minutes", "Hours" });
            comboBoxAutoScanUnit.SelectedIndex = 1; // Default to Hours

            // Set default interval
            textBoxAutoScanInterval.Text = "6";

            // Set default save folder
            autoScanSaveFolder = Path.Combine(Application.StartupPath, "AutomatedScans");
            if (!Directory.Exists(autoScanSaveFolder))
            {
                try
                {
                    Directory.CreateDirectory(autoScanSaveFolder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not create default save folder for auto-scans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    autoScanSaveFolder = Application.StartupPath; // Fallback
                }
            }
            UpdateAutoScanStatus("Idle. Save folder: " + autoScanSaveFolder);

            // Wire up timer tick event (Timer itself is added in Designer.cs)
            this.timerAutoScan.Tick += new System.EventHandler(this.timerAutoScan_Tick);
        }


        //initialize the space for connected spectrometers
        void init_variable()
        {
            spec_initialize = new int[DEVICE_NUM_MAX];
            spec_usbtype = new int[DEVICE_NUM_MAX];
            spec_channel = new int[DEVICE_NUM_MAX];
            spec_ccode = new string[DEVICE_NUM_MAX];
            spec_deviceid = new string[DEVICE_NUM_MAX];

            for (int i = 0; i < DEVICE_NUM_MAX; i++)
            {
                spec_initialize[i] = 0; spec_channel[i] = 0; spec_usbtype[i] = 0;
            }
        }
        void RefreshDeviceTree()
        {
            spectrometerDevice = null;
            DeviceTreeView.Nodes.Clear();
            foreach (USBDevice dev in usbDevices)
            {
                DeviceTreeView.Nodes.Add(dev.Tree);
                UpdateDevices();
            }
        }

        //USE Device Adding
        void usbDevices_DeviceAttached(object sender, EventArgs e)
        {
            RefreshDeviceTree();
        }

        //USE Device Removed
        void usbDevices_DeviceRemoved(object sender, EventArgs e)
        {
            RefreshDeviceTree();
        }

        //select active spectromter on DeviceTreeView component 
        private void DeviceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selNode = DeviceTreeView.SelectedNode;

            CyUSBInterfaceContainer curIntfcContainer = selNode.Tag as CyUSBInterfaceContainer;
            CyUSBInterface curIntfc = selNode.Tag as CyUSBInterface;
            CyUSBConfig curConfig = selNode.Tag as CyUSBConfig;
            CyUSBEndPoint curEndpt = selNode.Tag as CyUSBEndPoint;
            CyUSBDevice curCyUsbDev = selNode.Tag as CyUSBDevice;
            CyHidDevice curHidDev = null;
            CyHidReport curHidReport = null;

            if (curConfig != null)
            {
                curCyUsbDev = selNode.Parent.Tag as CyUSBDevice;
            }
            else if (curIntfcContainer != null)
            {
                curCyUsbDev = selNode.Parent.Parent.Tag as CyUSBDevice;
            }
            else if (curIntfc != null)
            {
                curCyUsbDev = selNode.Parent.Parent.Parent.Tag as CyUSBDevice;
                curCyUsbDev.AltIntfc = curIntfc.bAlternateSetting;
            }
            else if (curEndpt != null)
            {
                if (curEndpt.Address != 0) // Only if we're not on the Control Endpoint
                {
                    curCyUsbDev = selNode.Parent.Parent.Parent.Parent.Tag as CyUSBDevice;
                    curIntfc = selNode.Parent.Tag as CyUSBInterface;
                    curCyUsbDev.AltIntfc = curIntfc.bAlternateSetting;
                }
                else
                {
                    curCyUsbDev = selNode.Parent.Parent.Tag as CyUSBDevice;
                }
            }
            else if ((selNode.Tag is CyHidButton) || (selNode.Tag is CyHidValue))
            {
                curHidDev = selNode.Parent.Parent.Tag as CyHidDevice;
                curHidReport = selNode.Parent.Tag as CyHidReport;
            }
            else if (selNode.Tag is CyHidReport)
            {
                curHidDev = selNode.Parent.Tag as CyHidDevice;
                curHidReport = selNode.Tag as CyHidReport;
            }
            else if (selNode.Tag is CyHidDevice)
                curHidDev = selNode.Tag as CyHidDevice;

            spectrometerDevice = curCyUsbDev as CyUSBDevice;  //get the active spectrometer
        }

        void UpdateDevices()
        {
            //initialize the usb device
            bool retcode = InitDevices();

            if (retcode)
            {
                //get the valid channel number
                byte[] tmp_channel = new byte[32];
                int retcode1 = bwtekSetupChannel(-1, tmp_channel);
                if (retcode1 > 0)
                {
                    comboBox1_Channel.Items.Clear();
                    comboBox_Spectrometer.Items.Clear();

                    //get the total number of connected spectrometer
                    device_count = GetDeviceCount();


                    for (int i = 0; i < DEVICE_NUM_MAX; i++)
                    {
                        if (tmp_channel[i] < DEVICE_NUM_MAX)
                        {
                            //save the valid channel to array spec_cahhanel[]
                            spec_channel[i] = tmp_channel[i];
                            comboBox1_Channel.Items.Add(spec_channel[i]);

                            //get the ccode from connected spectrometer
                            byte[] tmp_pccode = new byte[8];
                            int ret = GetCCode(tmp_pccode, i);
                            spec_ccode[i] = ASCIIEncoding.ASCII.GetString(tmp_pccode);

                            //get the usb type from connected spectrometer
                            int tmp_usbtype = 0;
                            ret = GetUSBType(ref tmp_usbtype, i);
                            spec_para[i].usbtype = tmp_usbtype;

                            //read EEPROM content from connected spectromer, and save it as file, file name is "para_#.ini"
                            string filename = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\para_" + i.ToString() + ".ini";
                            ret = bwtekReadEEPROMUSB(filename, spec_channel[i]);

                            //read spectrometer parameters from this "para_#.ini" file
                            Load_Para(filename, i);

                            comboBox_Spectrometer.Items.Add(spec_para[i].cCode + "  " + spec_para[i].model);
                        }
                    }

                    if (device_count > 0)
                    {
                        panel1.Enabled = true;
                        panel2.Enabled = true;
                        panel3.Enabled = true;
                        panel4.Enabled = true;
                        groupBoxAutoScan.Enabled = true;

                        current_deviceindex = 0;
                        comboBox1_Channel.Text = comboBox1_Channel.Items[current_deviceindex].ToString();
                        comboBox_Spectrometer.Text = comboBox_Spectrometer.Items[current_deviceindex].ToString();

                        //setup spectrometer using parameters that read from para_#.ini
                        SetupSpectrmeter(current_deviceindex);

                        //setup chart x-axis/y-axis range
                        SetAxisRange(this.zgOverlay.GraphPane);

                        //setup chart 
                        ChartSetting(this.zgOverlay.GraphPane);

                        //open shutter
                        bwtekSetTTLOut(4, 1, spec_para[current_deviceindex].shutter_inverse, spec_para[current_deviceindex].channel);
                        Shutter.Checked = true;
                    }
                }
                else
                {
                    device_count = 0;
                    current_deviceindex = 0;
                    panel1.Enabled = false;
                    panel2.Enabled = false;
                    panel3.Enabled = false;
                    panel4.Enabled = false;
                    groupBoxAutoScan.Enabled = false;
                }
            }
        }


        //read spectrometer parameters from file
        public void Load_Para(string filename, int Index)
        {
            IniFile myini = new IniFile(filename);

            string section_str = "SPECTROMETER";
            int spectrometer_type = Convert.ToInt32(myini.ReadString(section_str, "spectrometer_type", "14")); //the unique identify value of spectrometer

            section_str = get_section(spectrometer_type);  //the block name
            int pixelnumber = Convert.ToInt32(myini.ReadString(section_str, "pixelnumber", "2048")); //CCD pixel number of spectrometer.
            int timing_mode = Convert.ToInt32(myini.ReadString(section_str, "timing_mode", "1"));    //timing mode of spectrometer
            int input_mode = Convert.ToInt32(myini.ReadString(section_str, "input_mode", "1"));      //input mode of spectrometer
            int inttime_unit = Convert.ToInt32(myini.ReadString(section_str, "inttime_unit", "1"));  //the unit of exposure time,0=us, 1=ms ,2=us
            int inttime_base = Convert.ToInt32(myini.ReadString(section_str, "intTimeBase", "0"));   //the offset of exposure time 		   
            int inttime_min = Convert.ToInt32(myini.ReadString(section_str, "inttime_min", "10"));   //minimum exposure time of spectrometer		               


            section_str = "COMMON";
            string model = myini.ReadString(section_str, "model", "");                              //spectrometer mode name
            string ccode = myini.ReadString(section_str, "c_code", "");                             //ccode
            double inttime = StrToDouble(myini.ReadString(section_str, "inttime", "10"));
            double[] coefficeint_a = new double[4];
            coefficeint_a[0] = StrToDouble(myini.ReadString(section_str, "coefs_a0", "0"));         //A0,coefficient of pixel convert to wavelength
            coefficeint_a[1] = StrToDouble(myini.ReadString(section_str, "coefs_a1", "0"));         //A1,coefficient of pixel convert to wavelength  
            coefficeint_a[2] = StrToDouble(myini.ReadString(section_str, "coefs_a2", "0"));         //A2,coefficient of pixel convert to wavelength
            coefficeint_a[3] = StrToDouble(myini.ReadString(section_str, "coefs_a3", "0"));         //A3,coefficient of pixel convert to wavelength
            double[] coefficeint_b = new double[4];
            coefficeint_b[0] = StrToDouble(myini.ReadString(section_str, "coefs_b0", "0"));         //B0,coefficient of wavelength convert to pixel
            coefficeint_b[1] = StrToDouble(myini.ReadString(section_str, "coefs_b1", "0"));         //B1,coefficient of wavelength convert to pixel
            coefficeint_b[2] = StrToDouble(myini.ReadString(section_str, "coefs_b2", "0"));         //B2,coefficient of wavelength convert to pixel
            coefficeint_b[3] = StrToDouble(myini.ReadString(section_str, "coefs_b3", "0"));         //B3,coefficient of wavelength convert to pixel
            int xaxis_data_reverse = Convert.ToInt32(myini.ReadString(section_str, "xaxis_data_reverse", "0")); //the x-axis inverse flag of spectrum
            int shutter_inverse = Convert.ToInt32(myini.ReadString("EXTERNAL_IO", "TTL4_Inverse", "0")); //shutter pin inverse flag

            int tmp_flag = 0;
            int CCDTemp_Set = 0;
            int ExternalTemp_Set = 0;
            if (spectrometer_type == (int)TypeID.BTC655_MODE) tmp_flag = 2;
            if (spectrometer_type == (int)TypeID.BTC655N_MODE) tmp_flag = 2;
            if (spectrometer_type == (int)TypeID.BTC665_MODE) tmp_flag = 1;
            if (spectrometer_type == (int)TypeID.BTC665N_MODE) tmp_flag = 1;
            if (spectrometer_type == (int)TypeID.BTC675_MODE) tmp_flag = 1;
            if (tmp_flag != 0)
            {
                if (tmp_flag == 1) { CCDTemp_Set = Convert.ToInt32(myini.ReadString("COMMON", "CCDTemp_Set", "-2")); }  //
                else { CCDTemp_Set = Convert.ToInt32(myini.ReadString("COMMON", "CCDTemp_Set", "0")); }
                ExternalTemp_Set = Convert.ToInt32(myini.ReadString("COMMON", "ExternalTemp_Set", "25"));
            }

            spec_para[Index].cCode = ccode;
            spec_para[Index].channel = Index;
            spec_para[Index].spectrometer_type = spectrometer_type;
            spec_para[Index].model = model;
            spec_para[Index].pixel_number = pixelnumber;
            spec_para[Index].timing_mode = timing_mode;
            spec_para[Index].input_mode = input_mode;
            spec_para[Index].inttime_base = inttime_base;
            spec_para[Index].inttime_unit = inttime_unit;
            spec_para[Index].inttime_min = inttime_min;

            spec_para[Index].inttime = inttime_min;
            spec_para[Index].inttime_int = (int)inttime;
            spec_para[Index].trigger_mode = 0;
            spec_para[Index].xaxis_data_reverse = xaxis_data_reverse;
            spec_para[Index].coefficient_a0 = coefficeint_a[0];
            spec_para[Index].coefficient_a1 = coefficeint_a[1];
            spec_para[Index].coefficient_a2 = coefficeint_a[2];
            spec_para[Index].coefficient_a3 = coefficeint_a[3];
            spec_para[Index].coefficient_b0 = coefficeint_b[0];
            spec_para[Index].coefficient_b1 = coefficeint_b[1];
            spec_para[Index].coefficient_b2 = coefficeint_b[2];
            spec_para[Index].coefficient_b3 = coefficeint_b[3];
            spec_para[Index].xaxis_data_reverse = xaxis_data_reverse;
            spec_para[Index].shutter_inverse = shutter_inverse;
            spec_para[Index].CCDTemp_Set = CCDTemp_Set;
            spec_para[Index].ExternalTemp_Set = ExternalTemp_Set;

            spec_para[Index].wavelength = new double[pixelnumber + 1];
            for (int i = 0; i < pixelnumber; i++)
            {
                spec_para[Index].wavelength[i] = coefficeint_a[0] + coefficeint_a[1] * Math.Pow(i, 1) + coefficeint_a[2] * Math.Pow(i, 2) + coefficeint_a[3] * Math.Pow(i, 3);
            }
        }

        private string get_section(int spectrometer_type)
        {
            string tmp_section = "";
            switch (spectrometer_type)
            {
                case 0: tmp_section = "BRC100"; break;
                case 1: tmp_section = "BRC100"; break;
                case 2: tmp_section = "BTC120"; break;
                case 3: tmp_section = "BTC121"; break;
                case 4: tmp_section = "BTC200"; break;
                case 5: tmp_section = "BTC300"; break;
                case 6: tmp_section = "BTC320"; break;
                case 7: tmp_section = "BTC400"; break;
                case 8: tmp_section = "BTC500"; break;
                case 9: tmp_section = "BRC110"; break;
                case 10: tmp_section = "BTC111"; break;
                case 11: tmp_section = "BRC111"; break;
                case 12: tmp_section = "BTC611"; break;
                case 13: tmp_section = "BRC711"; break;
                case 14: tmp_section = "BTC112"; break;
                case 15: tmp_section = "BTC211"; break;
                case 16: tmp_section = "BTC15x"; break;
                case 17: tmp_section = "BRC112"; break;
                case 18: tmp_section = "BRC311"; break;
                case 19: tmp_section = "BTC311"; break;
                case 20: tmp_section = "BTC610"; break;
                case 21: tmp_section = "BTC321"; break;
                case 22: tmp_section = "BTF111"; break;
                case 23: tmp_section = "BTC811"; break;
                case 24: tmp_section = "BTC221"; break;
                case 25: tmp_section = "BTC251"; break;
                case 26: tmp_section = "BTC711"; break;
                case 27: tmp_section = "BTC611E_512"; break;
                case 28: tmp_section = "BTC611E_1024"; break;
                case 29: tmp_section = "BTC711E_512"; break;
                case 30: tmp_section = "BTC711E_1024"; break;
                case 31: tmp_section = "BRC711E_512"; break;
                case 32: tmp_section = "BRC711E_1024"; break;
                case 33: tmp_section = "BTF113"; break;
                case 34: tmp_section = "BWS003"; break;
                case 35: tmp_section = "BWS004"; break;
                case 36: tmp_section = "BTC221E_G9208_256W"; break;
                case 37: tmp_section = "BTU111"; break;
                case 38: tmp_section = "BTC251E_512_RS232"; break;
                case 39: tmp_section = "BTC251E_512"; break;
                case 40: tmp_section = "BTC261E_512_RS232"; break;
                case 41: tmp_section = "BTC261E_512"; break;
                case 42: tmp_section = "BTC261E_256"; break;
                case 43: tmp_section = "BTC261E_1024"; break;
                case 44: tmp_section = "BRC131"; break;
                case 45: tmp_section = "BTC262E_256"; break;
                case 46: tmp_section = "BTC262E_512"; break;
                case 47: tmp_section = "BTC262E_1024"; break;
                case 48: tmp_section = "BRC100_OEM"; break;
                case 49: tmp_section = "BRC641"; break;
                case 50: tmp_section = "BTC613E_512"; break;
                case 51: tmp_section = "BTC613E_1024"; break;
                case 52: tmp_section = "BTC651E_512"; break;
                case 53: tmp_section = "BTC651E_1024"; break;
                case 54: tmp_section = "BWS225_256"; break;
                case 55: tmp_section = "BWS225_512"; break;
                case 56: tmp_section = "BTC641"; break;
                case 57: tmp_section = "BWS102"; break;
                case 58: tmp_section = "BWS003B"; break;
                case 59: tmp_section = "BWS435"; break;
                case 60: tmp_section = "BRC642E_2048"; break;
                case 61: tmp_section = "BTC263E_256"; break;
                case 62: tmp_section = "BRC113"; break;
                case 63: tmp_section = "BRC112P"; break;
                case 64: tmp_section = "BTC261P_512"; break;
                case 65: tmp_section = "BRC115"; break;
                case 66: tmp_section = "BTC665"; break;
                case 67: tmp_section = "BTC675"; break;
                case 68: tmp_section = "BTC655"; break;
                case 69: tmp_section = "BTC264P_512"; break;
                case 70: tmp_section = "BTC264P_1024"; break;
                case 71: tmp_section = "BRC1k"; break;
                case 72: tmp_section = "BTC665N"; break;
                case 73: tmp_section = "BRC115P"; break;
                case 74: tmp_section = "BTC655N"; break;
                case 75: tmp_section = "BTC264P_512_RS232"; break;
                case 76: tmp_section = "BTC261P_256"; break;
                case 77: tmp_section = "BTC667N"; break;
                case 78: tmp_section = "BTC675N"; break;
                case 79: tmp_section = "BTC261P_1024"; break;

            }
            return tmp_section;
        }

        //initialize spectrometer
        private void SetupSpectrmeter(int Index)
        {
            //create data buf
            spec_para[Index].DataArray = new ushort[spec_para[Index].pixel_number];

            //initialize spectrometer
            int ret = bwtekTestUSB(spec_para[Index].timing_mode, spec_para[Index].pixel_number, spec_para[Index].input_mode, spec_channel[Index], 0);

            //set LowNoise mode
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665N_MODE)
            {
                ret = bwtekSetLowNoiseModeUSB(1, spec_para[Index].channel);
            }

            //set exposure time
            ret = SetIntegrateTime(Index, spec_para[Index].inttime);

            //set timeout 
            ret = bwtekSetTimingsUSB(0, 1, spec_channel[Index]);

            //Set CCD cooler
            int tmp_flag = 0;
            if (spec_para[Index].spectrometer_type == (int)TypeID.BRC115_MODE) { tmp_flag = 1; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BRC115P_MODE) { tmp_flag = 1; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC655_MODE) { tmp_flag = 3; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC655N_MODE) { tmp_flag = 3; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665N_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC675_MODE) { tmp_flag = 2; }
            if (tmp_flag != 0)
            {
                if ((tmp_flag == 2) || (tmp_flag == 3))
                {
                    this.SetCoolerTemp(0, spec_para[Index].CCDTemp_Set);          //set ccd cooler
                    if (tmp_flag == 2)
                    {
                        this.SetCoolerTemp(1, spec_para[Index].ExternalTemp_Set); //set external cooler
                    }
                }
            }

            //set the initialized flag
            spec_initialize[Index] = 1;

            textBox_IntTime.Text = spec_para[Index].inttime.ToString();
            if (spec_para[Index].inttime_unit == 1)
            {
                label6.Text = "(ms)";
            }
            else
            {
                label6.Text = "(us)";
            }
            Panel_visible(Index);
        }

        //set exposure time
        public int SetIntegrateTime(int Index, double NewTime)
        {
            int ret = -1;
            int inttime_set = -1;

            int tmp_flag = 0;
            if (spec_para[Index].spectrometer_type == (int)TypeID.BRC115_MODE) { tmp_flag = 1; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC655_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC675_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC655N_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665N_MODE) { tmp_flag = 2; }
            if (tmp_flag != 0)
            {  //USB3.0 interface Spectrometers

                if (tmp_flag == 1) //BRC115
                {
                    if (spec_para[Index].inttime_unit == 1)            //is ms
                    {
                        inttime_set = Convert.ToInt32(NewTime * 1000);
                    }
                    else
                    {
                        inttime_set = Convert.ToInt32(NewTime);       //is us
                    }
                    ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);  //set exposure time
                }

                if (tmp_flag == 2)  //BTC665/BTC665N/BTC655/BTC655N
                {
                    if (spec_para[Index].inttime_unit == 1)          //is ms
                    {
                        inttime_set = Convert.ToInt32(NewTime * 1000 - spec_para[Index].inttime_base);
                    }
                    else
                    {                                               //is us
                        inttime_set = Convert.ToInt32(NewTime - spec_para[Index].inttime_base);
                    }
                    ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel); //set exposure time
                }
            }
            else
            {  //USB2.0 interface Spectrometers
                tmp_flag = 0;
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC261E_256_MODE) { tmp_flag = 1; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC261E_512_MODE) { tmp_flag = 1; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC261E_1024_MODE) { tmp_flag = 1; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC262E_256_MODE) { tmp_flag = 1; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC262E_512_MODE) { tmp_flag = 1; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC262E_1024_MODE) { tmp_flag = 1; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC263E_256_MODE) { tmp_flag = 2; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC261P_512_MODE) { tmp_flag = 3; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC611E_512_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC611E_1024_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC613E_512_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC613E_1024_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC651E_512_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC651E_1024_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BWS003_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BWS435_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BRC642E_2048_MODE) { tmp_flag = 4; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BRC641_MODE) { tmp_flag = 5; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BTC641_MODE) { tmp_flag = 5; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BWS102_MODE) { tmp_flag = 5; }
                if (spec_para[Index].spectrometer_type == (int)TypeID.BWS003B_MODE) { tmp_flag = 5; }

                if (tmp_flag != 0)
                {
                    int inttime_int = Convert.ToInt32(NewTime);
                    if (tmp_flag == 1)//BTC261E_XXX, BTC262E_XXX
                    {
                        inttime_set = inttime_int;

                        //set exposure time unit
                        ret = bwtekWriteValue(0, spec_para[Index].inttime_unit, spec_para[Index].channel); //First param :0:set time unit, second param:0=us, 1=ms
                        System.Threading.Thread.Sleep(100);

                        //set exposure time
                        ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                        System.Threading.Thread.Sleep(100);
                    }
                    else if (tmp_flag == 2) //BTC263E_256
                    {
                        //set exposure time unit
                        ret = bwtekSetTimeUnitUSB(spec_para[Index].inttime_unit, spec_para[Index].channel);
                        if (spec_para[Index].inttime_unit == 0)
                        {  //is us

                            inttime_set = inttime_int + spec_para[Index].inttime_base;
                            //set exposure time
                            ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                        }
                        else
                        {   //is ms

                            inttime_set = inttime_int;
                            //set exposure time
                            ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                        }
                    }
                    else if (tmp_flag == 3) //BTC261P_512
                    {
                        inttime_set = inttime_int;

                        //set exposure time unit
                        ret = bwtekSetTimeUnitUSB(spec_para[Index].inttime_unit, spec_para[Index].channel);

                        //set exposure time
                        ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                    }
                    else if (tmp_flag == 4) //BTC611,BTC613,BTC651,BWS003,BWS435,BRC642
                    {
                        inttime_set = Convert.ToInt32(NewTime - spec_para[Index].inttime_base);

                        //set exposure time base
                        ret = bwtekSetTimeBase0USB(spec_para[Index].inttime_base, spec_para[Index].channel);

                        //set exposure time
                        ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                    }
                    else if (tmp_flag == 5)  //BRC641, BTC641,BWS102,BWS003B
                    {
                        //set exposure time
                        inttime_set = Convert.ToInt32(NewTime - spec_para[Index].inttime_base);
                        ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                    }
                }
                else
                {   //BRC112, BTC112 and other spectrometer                    
                    inttime_set = Convert.ToInt32(NewTime);

                    //set exposure time
                    ret = bwtekSetTimeUSB(inttime_set, spec_para[Index].channel);
                }
            }

            return ret;
        }

        private void Panel_visible(int Index)
        {
            int tmp_flag = 0;
            if (spec_para[Index].spectrometer_type == (int)TypeID.BRC115_MODE) { tmp_flag = 1; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BRC115P_MODE) { tmp_flag = 1; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC665N_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC655_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC655N_MODE) { tmp_flag = 2; }
            if (spec_para[Index].spectrometer_type == (int)TypeID.BTC675_MODE) { tmp_flag = 2; }
            if (tmp_flag != 0)
            {
                panel3.Visible = true;
                panel4.Visible = true;
            }
            else
            {
                panel3.Visible = false;
                panel4.Visible = false;
            }
        }

        //string convert to double value
        public Double StrToDouble(string tmp_str)
        {
            double tmp_v = double.Parse(tmp_str, new System.Globalization.CultureInfo("en-US"));
            return tmp_v;
        }

        //setup chart x-axis/y-axis ranget 
        public void SetAxisRange(GraphPane myPane)
        {
            chart_xMin = 0;
            chart_xMax = 2047;
            chart_yMin = 0;
            chart_yMax = 65535;

            myPane.ZoomStack.Clear();
            myPane.XAxis.Scale.Min = chart_xMin;     //x-axis min of chart 
            myPane.XAxis.Scale.Max = chart_xMax;     //x-axis max of chart 
            myPane.YAxis.Scale.Min = chart_yMin;     //y-axis min of chart 
            myPane.YAxis.Scale.Max = chart_yMax;     //y-axis max of chart 
        }

        //setup chart 
        public void ChartSetting(GraphPane myPane)
        {
            //chart title font size
            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 12;
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.Size = 12;
            myPane.YAxis.Title.FontSpec.Size = 12;
            myPane.XAxis.Scale.FontSpec.Size = 12;
            myPane.YAxis.Scale.FontSpec.Size = 12;
            myPane.YAxis.Scale.FontSpec.IsBold = false;
            myPane.XAxis.Scale.FontSpec.IsBold = false;

            //chart legend font size
            myPane.Legend.FontSpec.Size = 12;
            myPane.Legend.FontSpec.IsBold = false;
            myPane.Legend.Fill.Type = FillType.None;
            myPane.Legend.IsVisible = false;
            myPane.Legend.Position = SpecGraph.LegendPos.InsideTopRight;

            myPane.IsFontsScaled = false;
            myPane.XAxis.Scale.Mag = 0;
            myPane.YAxis.Scale.Mag = 0;

            myPane.Title.Text = "Test Chart";                   //chart title on top
            myPane.XAxis.Title.Text = "Pixel";                  //chart title on botton
            myPane.YAxis.Title.Text = "Relative Intensity";     //chart title on left

            // Show the axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsZeroLine = false;

            myPane.Chart.Fill = new Fill(Color.White);        //chart background with white color
            myPane.Fill = new Fill(Color.White);
            myPane.AxisChange();
        }




        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }


        private void button12_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox_Spectrometer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select spectrometer
            current_deviceindex = comboBox_Spectrometer.SelectedIndex;

            //initialize selected spectrometer
            SetupSpectrmeter(current_deviceindex);
        }



        //disable some button on form
        private void Button_Disable()
        {
            button_SingleScan0.Enabled = false;
            button_MuitlScan0.Enabled = false;
            button_SingleScan1.Enabled = false;
            button_MuitlScan1.Enabled = false;
            button_SingleScan2.Enabled = false;
            button_MuitlScan2.Enabled = false;

            button_SetIntTime.Enabled = false;
            textBox_IntTime.Enabled = false;
        }

        //enable some button on form
        private void Button_Enable()
        {
            button_SingleScan0.Enabled = true;
            button_MuitlScan0.Enabled = true;
            button_SingleScan1.Enabled = true;
            button_MuitlScan1.Enabled = true;
            button_SingleScan2.Enabled = true;
            button_MuitlScan2.Enabled = true;

            button_SetIntTime.Enabled = true;
            textBox_IntTime.Enabled = true;
        }





        private void textBox_IntTime_TextChanged(object sender, EventArgs e)
        {
            if (device_count <= 0) return;
            if (double.TryParse(textBox_IntTime.Text, out double newIntTime))
            {
                spec_para[current_deviceindex].inttime = newIntTime;
                int retcode = SetIntegrateTime(current_deviceindex, spec_para[current_deviceindex].inttime);
            }
        }

        private void button_SetIntTime_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;
            if (double.TryParse(textBox_IntTime.Text, out double newIntTime))
            {
                spec_para[current_deviceindex].inttime = newIntTime;
                int retcode = SetIntegrateTime(current_deviceindex, spec_para[current_deviceindex].inttime);
            }
            else
            {
                MessageBox.Show("Invalid integration time format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ChartReset_Click(object sender, EventArgs e)
        {
            //reset chart
            this.zgOverlay.ZoomOutAll(this.zgOverlay.GraphPane);
            this.zgOverlay.Refresh();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (isAutoScanning)
            {
                timerAutoScan.Stop(); // Stop auto-scan if running
            }
            for (int i = 0; i < DEVICE_NUM_MAX; i++)
            {
                if (spec_initialize[i] == 1) { int ret = bwtekCloseUSB(i); }
            }
            Close(); //exit program
        }

        private void Shutter_CheckedChanged(object sender, EventArgs e)
        {
            if (device_count <= 0) return;
            int onoff;

            //onoff=1-->Open Shutter, onoff=0-->Close Shutter
            if (Shutter.Checked) { onoff = 1; } else { onoff = 0; }

            //TTL Out Pin4 is Shutter,so use function bwtekSetTTLOut() to Control Shutter
            bwtekSetTTLOut(4, onoff, spec_para[current_deviceindex].shutter_inverse, spec_para[current_deviceindex].channel);
        }

        private void button_SingleScan0_Click(object sender, EventArgs e)
        {   //single scan on normal scan mode

            if (device_count <= 0) return;
            spec_para[current_deviceindex].frame_num = 1;
            if (spec_para[current_deviceindex].DataArray != null) { spec_para[current_deviceindex].DataArray = null; }
            int memory_count = spec_para[current_deviceindex].pixel_number * spec_para[current_deviceindex].frame_num;
            spec_para[current_deviceindex].DataArray = new ushort[memory_count];

            spec_para[current_deviceindex].scan_mode = 0; //0=Normal Mode, 1=Speed Mode,2=Smart Mode
            spec_para[current_deviceindex].scan_flag = 1; //1=single scan, 2=continuously scan
            spec_para[current_deviceindex].stop_flag = 0; //0=no stop button pressed, 1=stop button pressed
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0;  //1= external trigger, 0= no external trigger
            Start_Scan();
        }

        private void button_MuitlScan0_Click(object sender, EventArgs e)
        {   //continuously scan on normal scan mode

            if (device_count <= 0) return;
            spec_para[current_deviceindex].frame_num = 1;
            if (spec_para[current_deviceindex].DataArray != null) { spec_para[current_deviceindex].DataArray = null; }
            int memory_count = spec_para[current_deviceindex].pixel_number * spec_para[current_deviceindex].frame_num;
            spec_para[current_deviceindex].DataArray = new ushort[memory_count];

            spec_para[current_deviceindex].scan_mode = 0;  //0=Normal Mode, 1=Speed Mode,2=Smart Mode
            spec_para[current_deviceindex].scan_flag = 2;  //1=single scan, 2=continuously scan
            spec_para[current_deviceindex].stop_flag = 0;  //0=no stop button pressed, 1=stop button pressed
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0;  //1= external trigger, 0= no external trigger
            Start_Scan();
        }

        private void button_SingleScan1_Click(object sender, EventArgs e)
        {   //single scan on speed scan mode

            if (device_count <= 0) return;
            spec_para[current_deviceindex].frame_num = Convert.ToInt32(textBox_FrameNum.Text);
            if (spec_para[current_deviceindex].DataArray != null) { spec_para[current_deviceindex].DataArray = null; }
            int memory_count = spec_para[current_deviceindex].pixel_number * spec_para[current_deviceindex].frame_num;
            spec_para[current_deviceindex].DataArray = new ushort[memory_count];

            spec_para[current_deviceindex].scan_mode = 1;  //0=Normal Mode, 1=Speed Mode,2=Smart Mode
            spec_para[current_deviceindex].scan_flag = 1;  //1=single scan, 2=continuously scan
            spec_para[current_deviceindex].stop_flag = 0;  //0=no stop button pressed, 1=stop button pressed
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0; //1= external trigger, 0= no external trigger
            Start_Scan();

        }

        private void button_MuitlScan1_Click(object sender, EventArgs e)
        {   //continuously scan on speed scan mode

            if (device_count <= 0) return;
            spec_para[current_deviceindex].frame_num = Convert.ToInt32(textBox_FrameNum.Text);
            if (spec_para[current_deviceindex].DataArray != null) { spec_para[current_deviceindex].DataArray = null; }
            int memory_count = spec_para[current_deviceindex].pixel_number * spec_para[current_deviceindex].frame_num;
            spec_para[current_deviceindex].DataArray = new ushort[memory_count];

            spec_para[current_deviceindex].scan_mode = 1;  //0=Normal Mode, 1=Speed Mode,2=Smart Mode
            spec_para[current_deviceindex].scan_flag = 2;  //1=single scan, 2=continuously scan
            spec_para[current_deviceindex].stop_flag = 0;  //0=no stop button pressed, 1=stop button pressed
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0; //1= external trigger, 0= no external trigger
            Start_Scan();
        }

        private void button_SingleScan2_Click(object sender, EventArgs e)
        {
            //single scan on smart scan mode

            if (device_count <= 0) return;
            spec_para[current_deviceindex].frame_num = 1;
            if (spec_para[current_deviceindex].DataArray != null) { spec_para[current_deviceindex].DataArray = null; }
            int memory_count = spec_para[current_deviceindex].pixel_number * spec_para[current_deviceindex].frame_num;
            spec_para[current_deviceindex].DataArray = new ushort[memory_count];

            spec_para[current_deviceindex].scan_mode = 2;  //0=Normal Mode, 1=Speed Mode,2=Smart Mode
            spec_para[current_deviceindex].scan_flag = 1;  //1=single scan, 2=continuously scan
            spec_para[current_deviceindex].stop_flag = 0;  //0=no stop button pressed, 1=stop button pressed
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0;  //1= external trigger, 0= no external trigger

            spec_para[current_deviceindex].ave_num = Convert.ToInt32(textBox_Ave.Text); //average number
            spec_para[current_deviceindex].darkcompensate_flag = checkBox_DarkCompensate.Checked ? 1 : 0; //dark componsate, 1=do, 0=undo
            spec_para[current_deviceindex].smooth_flag = checkBox_Smooth.Checked ? 1 : 0;   //smooth, 1=smooth, 0=no smooth
            Start_Scan();
        }

        private void button_MuitlScan2_Click(object sender, EventArgs e)
        {
            //continuously scan on smart scan mode

            if (device_count <= 0) return;
            spec_para[current_deviceindex].frame_num = 1;
            if (spec_para[current_deviceindex].DataArray != null) { spec_para[current_deviceindex].DataArray = null; }
            int memory_count = spec_para[current_deviceindex].pixel_number * spec_para[current_deviceindex].frame_num;
            spec_para[current_deviceindex].DataArray = new ushort[memory_count];

            spec_para[current_deviceindex].scan_mode = 2;  //0=Normal Mode, 1=Speed Mode,2=Smart Mode
            spec_para[current_deviceindex].scan_flag = 2;  //1=single scan, 2=continuously scan
            spec_para[current_deviceindex].stop_flag = 0;  //0=no stop button pressed, 1=stop button pressed
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0; //1= external trigger, 0= no external trigger

            spec_para[current_deviceindex].ave_num = Convert.ToInt32(textBox_Ave.Text);//average number
            spec_para[current_deviceindex].darkcompensate_flag = checkBox_DarkCompensate.Checked ? 1 : 0;  //dark componsate, 1=do, 0=undo
            spec_para[current_deviceindex].smooth_flag = checkBox_Smooth.Checked ? 1 : 0;  //smooth, 1=smooth, 0=no smooth
            Start_Scan();
        }

        private void Start_Scan()
        {
            //enable some button on form
            Button_Disable();

            //abort the revious data scan thread
            if (td != null && td.IsAlive) { td.Abort(); td.Join(); } // Check IsAlive

            //cretea data scan thread
            td = new Thread(new ThreadStart(DataScan_Process));

            //execute thread
            td.Start();
        }

        private void DataScan_Process() { DataScan_SubProcess(0); }


        //data scan procedure
        private void DataScan_SubProcess(int mode)
        {
            int ret;
            while ((spec_para[current_deviceindex].scan_flag != 0) && (spec_para[current_deviceindex].stop_flag == 0))
            {
                //lock
                System.Threading.Monitor.Enter(this);

                switch (spec_para[current_deviceindex].scan_mode)
                {
                    case 0: //Normal Scan Mode
                        ret = bwtekDataReadUSB(spec_para[current_deviceindex].trigger_mode, spec_para[current_deviceindex].DataArray, spec_para[current_deviceindex].channel);
                        break;
                    case 1: //Speed Scan Mode
                        ret = bwtekFrameDataReadUSB(spec_para[current_deviceindex].frame_num, spec_para[current_deviceindex].trigger_mode, spec_para[current_deviceindex].DataArray, spec_para[current_deviceindex].channel);
                        break;
                    case 2: //Smart Scan Mode
                        ret = bwtekDSPDataReadUSB(spec_para[current_deviceindex].ave_num, spec_para[current_deviceindex].smooth_flag, spec_para[current_deviceindex].darkcompensate_flag, spec_para[current_deviceindex].trigger_mode, spec_para[current_deviceindex].DataArray, spec_para[current_deviceindex].channel);
                        break;
                }
                scan_count++;

                //unlock
                System.Threading.Monitor.Exit(this);

                //display spectrum
                DeleFunc de = new DeleFunc(ShowSpectrum); this.Invoke(de);
                Thread.Sleep(100);

                //single scan will exit loop
                if (spec_para[current_deviceindex].scan_flag == 1)
                {
                    spec_para[current_deviceindex].scan_flag = 0;

                    //enable some button on form
                    DeleFunc de1 = new DeleFunc(Button_Enable); this.Invoke(de1);
                }
            }
        }

        //display spectrum
        private void ShowSpectrum()
        {
            //display spectrum subroutine
            ShowSpectrum0(zgOverlay, current_deviceindex);

            label_Scancount.Text = scan_count.ToString();

            if (scan_count == (scan_count / 2) * 2) { panel7.BackColor = Color.Black; } else { panel7.BackColor = Color.Red; }
        }

        //display spectrum subroutine
        void ShowSpectrum0(SpecGraphControl spGraph, int index)
        {
            if (spGraph == null) { return; }

            // Clear the curve list
            spGraph.GraphPane.CurveList.Clear();
            spGraph.GraphPane.GraphObjList.Clear();

            // Create point list
            PointPairList list = new PointPairList();
            double X = 0, Y = 0, Max_Y = 0;

            for (int i = 0; i < spec_para[index].pixel_number; i++)
            {
                if (Max_Y < spec_para[index].DataArray[i]) { Max_Y = spec_para[index].DataArray[i]; }
                X = i; // X value of point

                // Subtract the dark spectrum if available
                if (isDarkSpectrumCaptured && darkSpectrum != null && i < darkSpectrum.Length) // Added length check
                {
                    Y = Math.Max(0, spec_para[index].DataArray[i] - darkSpectrum[i]); // Ensure no negative values
                }
                else
                {
                    Y = spec_para[index].DataArray[i];
                }

                list.Add(X, Y); // Add this point
            }

            // Create curve with point list
            LineItem myCurve = spGraph.GraphPane.AddCurve("Spectrum #1", list, Color.Red, SymbolType.None); // Color.Red

            myCurve.Line.Width = 1; // Curve line width
            myCurve.Line.IsAntiAlias = false;

            // Refresh chart
            spGraph.Invalidate();
        }

        private void button_Stop0_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;

            //set stop flag
            spec_para[current_deviceindex].stop_flag = 1;

            //Enabled button
            Button_Enable();
        }

        private void button_Stop1_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;

            //set stop flag
            spec_para[current_deviceindex].stop_flag = 1;

            //Enabled button
            Button_Enable();

        }

        private void button_Stop2_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;

            //set stop flag
            spec_para[current_deviceindex].stop_flag = 1;

            //Enabled button
            Button_Enable();

        }

        private void button_EraseBlock_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;

            //erase customer eeprom (64k)
            int ret = bwtekEraseBlockUSB(current_deviceindex);
        }

        private void button_WriteBlock_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;

            //create buffer
            byte[] data = new byte[100];
            int addr = 0;
            int nNum = 100;
            // listBox1.Items.Clear(); // listBox1 no longer exists

            //set desired write data with 0..99 value
            for (int i = 0; i < nNum; i++)
            {
                data[i] = (byte)i;
                // listBox1.Items.Add(data[i].ToString()); // listBox1 no longer exists
            }

            //write data to customer EEPROM
            int ret = bwtekWriteBlockUSB(addr, data, nNum, spec_para[current_deviceindex].channel);
        }

        private void button_ReadBlock_Click(object sender, EventArgs e)
        {
            if (device_count <= 0) return;

            //reset buffer with 0xff value
            byte[] data = new byte[100];
            int addr = 0;
            int nNum = 100;
            for (int i = 0; i < nNum; i++) { data[i] = 255; }

            //read data from customer EEPROM
            int ret = bwtekReadBlockUSB(addr, data, nNum, spec_para[current_deviceindex].channel);

            //display data
            // listBox1.Items.Clear(); // listBox1 no longer exists
            for (int i = 0; i < nNum; i++)
            {
                // listBox1.Items.Add(data[i].ToString()); // listBox1 no longer exists
            }
        }

        private void button_USB3GetTemp0_Click(object sender, EventArgs e)
        {
            Int32 ret;
            Int32 nADvalue = 0;
            double dTemperature = 0.0;

            //read ccd temperature
            ret = bwtekReadTemperature(0x10, ref nADvalue, ref dTemperature, spec_para[current_deviceindex].channel);

            //display ccd temperature
            textBox_USB3Temp0.Text = dTemperature.ToString("0.00");
        }

        private void button_USB3GetTemp1_Click(object sender, EventArgs e)
        {
            Int32 ret;
            Int32 nADvalue = 0;
            double dTemperature = 0.0;

            //read external temperature
            ret = bwtekReadTemperature(0x11, ref nADvalue, ref dTemperature, spec_para[current_deviceindex].channel);

            //display external temperature
            textBox_USB3Temp1.Text = dTemperature.ToString("0.00");
        }

        public bool SaveSpectrumToFile(string filePath = null, bool silentMode = false)
        {
            if (current_deviceindex < 0 || device_count <= 0)
            {
                if (!silentMode) MessageBox.Show("No spectrometer selected or active.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (spec_para[current_deviceindex].DataArray == null || spec_para[current_deviceindex].DataArray.Length == 0)
            {
                if (!silentMode) MessageBox.Show("No spectrum data to save. Please acquire a spectrum first.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (spec_para[current_deviceindex].wavelength == null || spec_para[current_deviceindex].wavelength.Length < spec_para[current_deviceindex].pixel_number)
            {
                if (!silentMode) MessageBox.Show("Wavelength calibration data is missing or incomplete. Cannot save with wavelength.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string actualFilePath = filePath;
            if (string.IsNullOrEmpty(actualFilePath))
            {
                if (silentMode)
                {
                    // In silent mode, if no path is given, we can't prompt.
                    // Decide on behavior: error, or generate a default path.
                    // For now, let's assume an error or log it.
                    // Console.WriteLine("Error: FilePath not provided for silent save.");
                    return false;
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save Spectrum Data";
                    saveFileDialog.FileName = "spectrum_data.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        actualFilePath = saveFileDialog.FileName;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            try
            {
                string directory = Path.GetDirectoryName(actualFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (StreamWriter sw = new StreamWriter(actualFilePath))
                {
                    sw.WriteLine("Wavelength\tIntensity");
                    int pointsToSave = spec_para[current_deviceindex].pixel_number;
                    for (int i = 0; i < pointsToSave; i++)
                    {
                        double intensity = spec_para[current_deviceindex].DataArray[i];
                        if (isDarkSpectrumCaptured && darkSpectrum != null && i < darkSpectrum.Length)
                        {
                            intensity = Math.Max(0, spec_para[current_deviceindex].DataArray[i] - darkSpectrum[i]);
                        }
                        sw.WriteLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:F3}\t{1}",
                            spec_para[current_deviceindex].wavelength[i],
                            intensity));
                    }
                }
                if (!silentMode) MessageBox.Show($"Spectrum saved successfully to:\n{actualFilePath}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                if (!silentMode) MessageBox.Show($"Error saving spectrum: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // else Console.WriteLine($"Error saving spectrum silently: {ex.Message}");
                return false;
            }
        }
        private void numericUpDown_CCDTemp_ValueChanged(object sender, EventArgs e)
        {
            //set CCD Cooler temperature between -40°C..+10°C

            if ((numericUpDown_CCDTemp.Value >= -40) && (numericUpDown_CCDTemp.Value <= 10))
            {
                SetCoolerTemp(0, (int)numericUpDown_CCDTemp.Value);

                //save variable of set CCD Cooler temperature
                spec_para[current_deviceindex].CCDTemp_Set = (int)numericUpDown_CCDTemp.Value;
            }
        }

        private void numericUpDown_ExternalTemp_ValueChanged(object sender, EventArgs e)
        {
            //set External Cooler temperature between 0°C..+30°C

            if ((numericUpDown_ExternalTemp.Value >= 0) && (numericUpDown_ExternalTemp.Value <= 30))
            {
                SetCoolerTemp(1, (int)numericUpDown_ExternalTemp.Value);

                //save variable of set External Cooler temperature
                spec_para[current_deviceindex].ExternalTemp_Set = (int)numericUpDown_ExternalTemp.Value;
            }
        }

        private void SetCoolerTemp(int DAChannel, int SetTemp)
        {
            //  Rt/R25=exp(A+B/T+C/T^2+D/T^3);  R25=10 K
            //  T=Temperature in K.   K=°C+273.15
            //  -50 to 0 (°C): A=-1.6165371*10^1, B=5.9362293*10^3,C=-4.0817384*10^5, D=2.2340382*10^7  
            //  0  to 50 (°C): A=-1.5702076*10^1, B=5.7388897*10^3,C=-4.0470744*10^5, D=2.6675244*10^7  
            //
            //  V(set)=Rt/(Rt+R25)*1.5v= Rt/(Rt+10)*1.5
            //  DA Set=V(set)/2.28*4096

            double[] coef = new double[4];
            double Rt_R25;
            double T = SetTemp + 273.15;
            double Rt, R25, Vset;
            int DA_Set;
            if (SetTemp < 0)
            {
                coef[0] = -1.6165371 * Math.Pow(10, 1);
                coef[1] = 5.9362293 * Math.Pow(10, 3);
                coef[2] = -4.0817384 * Math.Pow(10, 5);
                coef[3] = 2.2340382 * Math.Pow(10, 7);

            }
            else
            {
                coef[0] = -1.5702076 * Math.Pow(10, 1);
                coef[1] = 5.7388897 * Math.Pow(10, 3);
                coef[2] = -4.0470744 * Math.Pow(10, 5);
                coef[3] = 2.6675244 * Math.Pow(10, 7);
            }
            Rt_R25 = coef[0] + coef[1] / T + coef[2] / Math.Pow(T, 2) + coef[3] / Math.Pow(T, 3);
            Rt_R25 = Math.Exp(Rt_R25);
            R25 = 10000;  //R25=10K
            Rt = Rt_R25 * R25;
            Vset = (Rt / (Rt + R25) * 1.5);

            //calc DA set value
            DA_Set = (int)(Vset / 2.28 * 4096);

            //set DA out
            int ret = bwtekSetAnalogOut(DAChannel, DA_Set, spec_para[current_deviceindex].channel);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Content related to listBox1, which no longer exists.
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_SaveGraph_Click(object sender, EventArgs e)
        {
            SaveSpectrumToFile(); // Calls the overloaded method without silentMode
        }

        private void button_CaptureDarkSpectrum_Click(object sender, EventArgs e)
        {
            CaptureDarkSpectrum();
        }

        private void CaptureDarkSpectrum()
        {
            if (device_count <= 0)
            {
                MessageBox.Show("No spectrometer connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Close the shutter
            bwtekSetTTLOut(4, 0, spec_para[current_deviceindex].shutter_inverse, spec_para[current_deviceindex].channel);
            Shutter.Checked = false;

            // Perform a single scan
            spec_para[current_deviceindex].frame_num = 1;
            spec_para[current_deviceindex].scan_mode = 0; // Normal mode
            spec_para[current_deviceindex].scan_flag = 1; // Single scan
            spec_para[current_deviceindex].stop_flag = 0; // Ensure no stop flag
            spec_para[current_deviceindex].trigger_mode = ExtTrigger.Checked ? 1 : 0; // External trigger if checked

            // Allocate memory for the dark spectrum
            darkSpectrum = new ushort[spec_para[current_deviceindex].pixel_number];

            // Start the scan
            int ret = bwtekDataReadUSB(spec_para[current_deviceindex].trigger_mode, darkSpectrum, spec_para[current_deviceindex].channel);

            if (ret == 0) // Check if the scan was successful
            {
                isDarkSpectrumCaptured = true;
                MessageBox.Show("Dark spectrum captured successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to capture dark spectrum.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reopen the shutter
            bwtekSetTTLOut(4, 1, spec_para[current_deviceindex].shutter_inverse, spec_para[current_deviceindex].channel);
            Shutter.Checked = true;
        }

        // --- Auto-Scan Methods ---
        private void UpdateAutoScanStatus(string message)
        {
            if (labelAutoScanStatus.InvokeRequired)
            {
                labelAutoScanStatus.Invoke(new Action(() => labelAutoScanStatus.Text = "Status: " + message));
            }
            else
            {
                labelAutoScanStatus.Text = "Status: " + message;
            }
        }

        private void buttonStartAutoScan_Click(object sender, EventArgs e)
        {
            if (device_count <= 0)
            {
                MessageBox.Show("No spectrometer connected.", "Auto-Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(textBoxAutoScanInterval.Text, out double intervalValue) || intervalValue <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the interval.", "Auto-Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long multiplier = 1;
            string unit = comboBoxAutoScanUnit.SelectedItem.ToString();
            if (unit == "Minutes")
            {
                multiplier = 60 * 1000; // milliseconds
            }
            else if (unit == "Hours")
            {
                multiplier = 60 * 60 * 1000; // milliseconds
            }

            autoScanIntervalMilliseconds = (int)(intervalValue * multiplier);
            if (autoScanIntervalMilliseconds <= 0) // Check for overflow or too small value
            {
                MessageBox.Show("The calculated interval is too large or too small. Please adjust.", "Auto-Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            timerAutoScan.Interval = autoScanIntervalMilliseconds;
            isAutoScanning = true;
            timerAutoScan.Start();

            buttonStartAutoScan.Enabled = false;
            buttonStopAutoScan.Enabled = true;
            textBoxAutoScanInterval.Enabled = false;
            comboBoxAutoScanUnit.Enabled = false;
            buttonSetAutoScanFolder.Enabled = false;
            UpdateAutoScanStatus($"Started. Next scan in approx. {intervalValue} {unit}.");
        }

        private void buttonStopAutoScan_Click(object sender, EventArgs e)
        {
            isAutoScanning = false;
            timerAutoScan.Stop();

            buttonStartAutoScan.Enabled = true;
            buttonStopAutoScan.Enabled = false;
            textBoxAutoScanInterval.Enabled = true;
            comboBoxAutoScanUnit.Enabled = true;
            buttonSetAutoScanFolder.Enabled = true;
            UpdateAutoScanStatus("Stopped. Save folder: " + autoScanSaveFolder);
        }

        private void buttonSetAutoScanFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialogAutoScan.SelectedPath = autoScanSaveFolder;
            if (folderBrowserDialogAutoScan.ShowDialog() == DialogResult.OK)
            {
                autoScanSaveFolder = folderBrowserDialogAutoScan.SelectedPath;
                UpdateAutoScanStatus("Save folder set to: " + autoScanSaveFolder);
            }
        }

        private void timerAutoScan_Tick(object sender, EventArgs e)
        {
            if (!isAutoScanning || current_deviceindex < 0 || device_count <= 0)
            {
                return; // Should not happen if logic is correct, but good for safety
            }

            // Prevent issues if a manual scan is running via the 'td' thread
            if (td != null && td.IsAlive)
            {
                UpdateAutoScanStatus("Manual scan in progress. Auto-scan tick skipped.");
                return;
            }

            timerAutoScan.Stop(); // Stop timer to prevent re-entrancy during scan/save

            try
            {
                UpdateAutoScanStatus($"Acquiring spectrum at {DateTime.Now}...");
                Application.DoEvents();

                if (spec_para[current_deviceindex].DataArray == null ||
                    spec_para[current_deviceindex].DataArray.Length != spec_para[current_deviceindex].pixel_number)
                {
                    spec_para[current_deviceindex].DataArray = new ushort[spec_para[current_deviceindex].pixel_number];
                }

                // Perform data acquisition (Normal Mode, Internal Trigger for simplicity)
                int acquisitionResult = bwtekDataReadUSB(0, spec_para[current_deviceindex].DataArray, spec_para[current_deviceindex].channel);

                if (acquisitionResult == 0) // Success
                {
                    string deviceCode = spec_para[current_deviceindex].cCode.Trim().Replace(" ", "_");
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string fileName = $"AutoScan_{deviceCode}_{timestamp}.txt";
                    string filePath = Path.Combine(autoScanSaveFolder, fileName);

                    bool saved = SaveSpectrumToFile(filePath, true); // silentMode = true

                    if (saved)
                    {
                        UpdateAutoScanStatus($"Spectrum saved to {fileName}.");
                    }
                    else
                    {
                        UpdateAutoScanStatus($"Failed to save spectrum to {fileName}.");
                    }
                }
                else
                {
                    UpdateAutoScanStatus($"Failed to acquire spectrum. Error: {acquisitionResult}");
                }
            }
            catch (Exception ex)
            {
                UpdateAutoScanStatus($"Error during auto-scan: {ex.Message}");
            }
            finally
            {
                if (isAutoScanning) // Only restart if still in auto-scan mode
                {
                    timerAutoScan.Start(); // Restart timer for the next interval
                    double intervalValue = 0;
                    string unit = "";
                    if (comboBoxAutoScanUnit.SelectedItem != null && double.TryParse(textBoxAutoScanInterval.Text, out intervalValue))
                    {
                        unit = comboBoxAutoScanUnit.SelectedItem.ToString();
                        UpdateAutoScanStatus($"Next scan in approx. {intervalValue} {unit}.");
                    }
                    else
                    {
                        UpdateAutoScanStatus($"Next scan in {autoScanIntervalMilliseconds / 1000} seconds.");
                    }

                }
            }
        }
    }
}
