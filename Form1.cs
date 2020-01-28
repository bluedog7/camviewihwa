using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SimpleSample_Audio
{
    public partial class Form1 : Form
    {
        AxIPROPSAPILib.AxipropsapiCtrl[] CameraControls;
        int SelectedCamera = 0;
        bool fullscreen = false;
        Point saved_posiztion;
        int save_Width, save_Height;
        //CodeVendor.Controls.Grouper[] Borders;
        RadioButton[] Ctlchecked;
        public Form1()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        // Define variables
        //---------------------------------------------------------------------
        private Form2 frmForm2;

        int m_PlayStatus = 0;    //LiveStatus 0:Stop 1:Live

        //---------------------------------------------------------------------
        // Function Name        : Load
        // Overview             : Load PSAPI and Initialize
        //---------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Please confirm beforehand that the audio function of a target device is available.", "SimpleSample_Audio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //Show the log window
            frmForm2 = new Form2();
            //frmForm2.Show();
            AppSettingsReader ar = new AppSettingsReader();
            //Set properties to connect the device
            axipropsapiCtrl1.IPAddr = (String)ar.GetValue("cam1", typeof(String));
            axipropsapiCtrl1.DeviceType = 2;
            axipropsapiCtrl1.HttpPort = 80;
            axipropsapiCtrl1.UserName = "admin";
            axipropsapiCtrl1.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl1.StreamFormat = 0;
            axipropsapiCtrl1.JPEGResolution = 320;
            axipropsapiCtrl1.MPEG4Resolution = 320;
            axipropsapiCtrl1.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl1.OnErrorEnable = 1;
            axipropsapiCtrl1.OnDevStatusEnable = 0;
            axipropsapiCtrl1.OnRecStatusEnable = 0;
            axipropsapiCtrl1.OnPlayStatusEnable = 1;
            axipropsapiCtrl1.OnImageRefreshEnable = 0;
            axipropsapiCtrl1.OnRecordStatusEnable = 0;
            axipropsapiCtrl1.OnOpStatusEnable = 0;
            axipropsapiCtrl1.OnAlmStatusEnable = 0;
            axipropsapiCtrl1.MouseDownEnable = 1;

            axipropsapiCtrl1.OnRecStatusCBEnable = 0;
            axipropsapiCtrl1.OnSearchCBEnable = 0;
            axipropsapiCtrl1.OnSearchExCBEnable = 0;
            axipropsapiCtrl1.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl1.OnOpStatusCBEnable = 0;
            axipropsapiCtrl1.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl1.OnFtpStatusCBEnable = 0;
            //Set properties for display area
            axipropsapiCtrl2.StreamFormat = 0;
            axipropsapiCtrl2.JPEGResolution = 320;
            axipropsapiCtrl2.MPEG4Resolution = 320;
            axipropsapiCtrl2.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl2.IPAddr = (String)ar.GetValue("cam2", typeof(String));
            axipropsapiCtrl2.DeviceType = 2;
            axipropsapiCtrl2.HttpPort = 80;
            axipropsapiCtrl2.UserName = "admin";
            axipropsapiCtrl2.Password = "ibst2997730!";
            axipropsapiCtrl2.OnErrorEnable = 1;
            axipropsapiCtrl2.OnDevStatusEnable = 0;
            axipropsapiCtrl2.OnRecStatusEnable = 0;
            axipropsapiCtrl2.OnPlayStatusEnable = 1;
            axipropsapiCtrl2.OnImageRefreshEnable = 0;
            axipropsapiCtrl2.OnRecordStatusEnable = 0;
            axipropsapiCtrl2.OnOpStatusEnable = 0;
            axipropsapiCtrl2.OnAlmStatusEnable = 0;

            axipropsapiCtrl2.OnRecStatusCBEnable = 0;
            axipropsapiCtrl2.OnSearchCBEnable = 0;
            axipropsapiCtrl2.OnSearchExCBEnable = 0;
            axipropsapiCtrl2.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl2.OnOpStatusCBEnable = 0;
            axipropsapiCtrl2.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl2.OnFtpStatusCBEnable = 0;

            axipropsapiCtrl3.IPAddr = (String)ar.GetValue("cam3", typeof(String));
            axipropsapiCtrl3.DeviceType = 2;
            axipropsapiCtrl3.HttpPort = 80;
            axipropsapiCtrl3.UserName = "admin";
            axipropsapiCtrl3.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl3.StreamFormat = 0;
            axipropsapiCtrl3.JPEGResolution = 320;
            axipropsapiCtrl3.MPEG4Resolution = 320;
            axipropsapiCtrl3.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl3.OnErrorEnable = 1;
            axipropsapiCtrl3.OnDevStatusEnable = 0;
            axipropsapiCtrl3.OnRecStatusEnable = 0;
            axipropsapiCtrl3.OnPlayStatusEnable = 1;
            axipropsapiCtrl3.OnImageRefreshEnable = 0;
            axipropsapiCtrl3.OnRecordStatusEnable = 0;
            axipropsapiCtrl3.OnOpStatusEnable = 0;
            axipropsapiCtrl3.OnAlmStatusEnable = 0;

            axipropsapiCtrl3.OnRecStatusCBEnable = 0;
            axipropsapiCtrl3.OnSearchCBEnable = 0;
            axipropsapiCtrl3.OnSearchExCBEnable = 0;
            axipropsapiCtrl3.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl3.OnOpStatusCBEnable = 0;
            axipropsapiCtrl3.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl3.OnFtpStatusCBEnable = 0;

            axipropsapiCtrl4.IPAddr = (String)ar.GetValue("cam4", typeof(String));
            axipropsapiCtrl4.DeviceType = 2;
            axipropsapiCtrl4.HttpPort = 80;
            axipropsapiCtrl4.UserName = "admin";
            axipropsapiCtrl4.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl4.StreamFormat = 0;
            axipropsapiCtrl4.JPEGResolution = 320;
            axipropsapiCtrl4.MPEG4Resolution = 320;
            axipropsapiCtrl4.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl4.OnErrorEnable = 1;
            axipropsapiCtrl4.OnDevStatusEnable = 0;
            axipropsapiCtrl4.OnRecStatusEnable = 0;
            axipropsapiCtrl4.OnPlayStatusEnable = 1;
            axipropsapiCtrl4.OnImageRefreshEnable = 0;
            axipropsapiCtrl4.OnRecordStatusEnable = 0;
            axipropsapiCtrl4.OnOpStatusEnable = 0;
            axipropsapiCtrl4.OnAlmStatusEnable = 0;

            axipropsapiCtrl4.OnRecStatusCBEnable = 0;
            axipropsapiCtrl4.OnSearchCBEnable = 0;
            axipropsapiCtrl4.OnSearchExCBEnable = 0;
            axipropsapiCtrl4.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl4.OnOpStatusCBEnable = 0;
            axipropsapiCtrl4.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl4.OnFtpStatusCBEnable = 0;

            //Set properties to connect the device
            axipropsapiCtrl5.IPAddr = (String)ar.GetValue("cam5", typeof(String));
            axipropsapiCtrl5.DeviceType = 2;
            axipropsapiCtrl5.HttpPort = 80;
            axipropsapiCtrl5.UserName = "admin";
            axipropsapiCtrl5.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl5.StreamFormat = 0;
            axipropsapiCtrl5.JPEGResolution = 320;
            axipropsapiCtrl5.MPEG4Resolution = 320;
            axipropsapiCtrl5.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl5.OnErrorEnable = 1;
            axipropsapiCtrl5.OnDevStatusEnable = 0;
            axipropsapiCtrl5.OnRecStatusEnable = 0;
            axipropsapiCtrl5.OnPlayStatusEnable = 1;
            axipropsapiCtrl5.OnImageRefreshEnable = 0;
            axipropsapiCtrl5.OnRecordStatusEnable = 0;
            axipropsapiCtrl5.OnOpStatusEnable = 0;
            axipropsapiCtrl5.OnAlmStatusEnable = 0;

            axipropsapiCtrl5.OnRecStatusCBEnable = 0;
            axipropsapiCtrl5.OnSearchCBEnable = 0;
            axipropsapiCtrl5.OnSearchExCBEnable = 0;
            axipropsapiCtrl5.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl5.OnOpStatusCBEnable = 0;
            axipropsapiCtrl5.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl5.OnFtpStatusCBEnable = 0;
            //Set properties to connect the device
            axipropsapiCtrl6.IPAddr = (String)ar.GetValue("cam6", typeof(String));
            axipropsapiCtrl6.DeviceType = 2;
            axipropsapiCtrl6.HttpPort = 80;
            axipropsapiCtrl6.UserName = "admin";
            axipropsapiCtrl6.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl6.StreamFormat = 0;
            axipropsapiCtrl6.JPEGResolution = 320;
            axipropsapiCtrl6.MPEG4Resolution = 320;
            axipropsapiCtrl6.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl6.OnErrorEnable = 1;
            axipropsapiCtrl6.OnDevStatusEnable = 0;
            axipropsapiCtrl6.OnRecStatusEnable = 0;
            axipropsapiCtrl6.OnPlayStatusEnable = 1;
            axipropsapiCtrl6.OnImageRefreshEnable = 0;
            axipropsapiCtrl6.OnRecordStatusEnable = 0;
            axipropsapiCtrl6.OnOpStatusEnable = 0;
            axipropsapiCtrl6.OnAlmStatusEnable = 0;

            axipropsapiCtrl6.OnRecStatusCBEnable = 0;
            axipropsapiCtrl6.OnSearchCBEnable = 0;
            axipropsapiCtrl6.OnSearchExCBEnable = 0;
            axipropsapiCtrl6.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl6.OnOpStatusCBEnable = 0;
            axipropsapiCtrl6.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl6.OnFtpStatusCBEnable = 0;


            //Set properties to connect the device
            axipropsapiCtrl7.IPAddr = (String)ar.GetValue("cam7", typeof(String));
            axipropsapiCtrl7.DeviceType = 2;
            axipropsapiCtrl7.HttpPort = 80;
            axipropsapiCtrl7.UserName = "admin";
            axipropsapiCtrl7.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl7.StreamFormat = 0;
            axipropsapiCtrl7.JPEGResolution = 320;
            axipropsapiCtrl7.MPEG4Resolution = 320;
            axipropsapiCtrl7.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl7.OnErrorEnable = 1;
            axipropsapiCtrl7.OnDevStatusEnable = 0;
            axipropsapiCtrl7.OnRecStatusEnable = 0;
            axipropsapiCtrl7.OnPlayStatusEnable = 1;
            axipropsapiCtrl7.OnImageRefreshEnable = 0;
            axipropsapiCtrl7.OnRecordStatusEnable = 0;
            axipropsapiCtrl7.OnOpStatusEnable = 0;
            axipropsapiCtrl7.OnAlmStatusEnable = 0;

            axipropsapiCtrl7.OnRecStatusCBEnable = 0;
            axipropsapiCtrl7.OnSearchCBEnable = 0;
            axipropsapiCtrl7.OnSearchExCBEnable = 0;
            axipropsapiCtrl7.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl7.OnOpStatusCBEnable = 0;
            axipropsapiCtrl7.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl7.OnFtpStatusCBEnable = 0;

            //Set properties to connect the device
            axipropsapiCtrl8.IPAddr = (String)ar.GetValue("cam8", typeof(String));
            axipropsapiCtrl8.DeviceType = 2;
            axipropsapiCtrl8.HttpPort = 80;
            axipropsapiCtrl8.UserName = "admin";
            axipropsapiCtrl8.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl8.StreamFormat = 0;
            axipropsapiCtrl8.JPEGResolution = 320;
            axipropsapiCtrl8.MPEG4Resolution = 320;
            axipropsapiCtrl8.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl8.OnErrorEnable = 1;
            axipropsapiCtrl8.OnDevStatusEnable = 0;
            axipropsapiCtrl8.OnRecStatusEnable = 0;
            axipropsapiCtrl8.OnPlayStatusEnable = 1;
            axipropsapiCtrl8.OnImageRefreshEnable = 0;
            axipropsapiCtrl8.OnRecordStatusEnable = 0;
            axipropsapiCtrl8.OnOpStatusEnable = 0;
            axipropsapiCtrl8.OnAlmStatusEnable = 0;

            axipropsapiCtrl8.OnRecStatusCBEnable = 0;
            axipropsapiCtrl8.OnSearchCBEnable = 0;
            axipropsapiCtrl8.OnSearchExCBEnable = 0;
            axipropsapiCtrl8.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl8.OnOpStatusCBEnable = 0;
            axipropsapiCtrl8.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl8.OnFtpStatusCBEnable = 0;

            //Set properties to connect the device
            axipropsapiCtrl9.IPAddr = (String)ar.GetValue("cam9", typeof(String));
            axipropsapiCtrl9.DeviceType = 2;
            axipropsapiCtrl9.HttpPort = 80;
            axipropsapiCtrl9.UserName = "admin";
            axipropsapiCtrl9.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl9.StreamFormat = 0;
            axipropsapiCtrl9.JPEGResolution = 320;
            axipropsapiCtrl9.MPEG4Resolution = 320;
            axipropsapiCtrl9.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl9.OnErrorEnable = 1;
            axipropsapiCtrl9.OnDevStatusEnable = 0;
            axipropsapiCtrl9.OnRecStatusEnable = 0;
            axipropsapiCtrl9.OnPlayStatusEnable = 1;
            axipropsapiCtrl9.OnImageRefreshEnable = 0;
            axipropsapiCtrl9.OnRecordStatusEnable = 0;
            axipropsapiCtrl9.OnOpStatusEnable = 0;
            axipropsapiCtrl9.OnAlmStatusEnable = 0;

            axipropsapiCtrl9.OnRecStatusCBEnable = 0;
            axipropsapiCtrl9.OnSearchCBEnable = 0;
            axipropsapiCtrl9.OnSearchExCBEnable = 0;
            axipropsapiCtrl9.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl9.OnOpStatusCBEnable = 0;
            axipropsapiCtrl9.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl9.OnFtpStatusCBEnable = 0;

            //Set properties to connect the device
            axipropsapiCtrl10.IPAddr = (String)ar.GetValue("cam10", typeof(String));
            axipropsapiCtrl10.DeviceType = 2;
            axipropsapiCtrl10.HttpPort = 80;
            axipropsapiCtrl10.UserName = "admin";
            axipropsapiCtrl10.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl10.StreamFormat = 0;
            axipropsapiCtrl10.JPEGResolution = 320;
            axipropsapiCtrl10.MPEG4Resolution = 320;
            axipropsapiCtrl10.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl10.OnErrorEnable = 1;
            axipropsapiCtrl10.OnDevStatusEnable = 0;
            axipropsapiCtrl10.OnRecStatusEnable = 0;
            axipropsapiCtrl10.OnPlayStatusEnable = 1;
            axipropsapiCtrl10.OnImageRefreshEnable = 0;
            axipropsapiCtrl10.OnRecordStatusEnable = 0;
            axipropsapiCtrl10.OnOpStatusEnable = 0;
            axipropsapiCtrl10.OnAlmStatusEnable = 0;

            axipropsapiCtrl10.OnRecStatusCBEnable = 0;
            axipropsapiCtrl10.OnSearchCBEnable = 0;
            axipropsapiCtrl10.OnSearchExCBEnable = 0;
            axipropsapiCtrl10.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl10.OnOpStatusCBEnable = 0;
            axipropsapiCtrl10.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl10.OnFtpStatusCBEnable = 0;
            //Set properties to connect the device
            axipropsapiCtrl11.IPAddr = (String)ar.GetValue("cam11", typeof(String));
            axipropsapiCtrl11.DeviceType = 2;
            axipropsapiCtrl11.HttpPort = 80;
            axipropsapiCtrl11.UserName = "admin";
            axipropsapiCtrl11.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl11.StreamFormat = 0;
            axipropsapiCtrl11.JPEGResolution = 320;
            axipropsapiCtrl11.MPEG4Resolution = 320;
            axipropsapiCtrl11.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl11.OnErrorEnable = 1;
            axipropsapiCtrl11.OnDevStatusEnable = 0;
            axipropsapiCtrl11.OnRecStatusEnable = 0;
            axipropsapiCtrl11.OnPlayStatusEnable = 1;
            axipropsapiCtrl11.OnImageRefreshEnable = 0;
            axipropsapiCtrl11.OnRecordStatusEnable = 0;
            axipropsapiCtrl11.OnOpStatusEnable = 0;
            axipropsapiCtrl11.OnAlmStatusEnable = 0;

            axipropsapiCtrl11.OnRecStatusCBEnable = 0;
            axipropsapiCtrl11.OnSearchCBEnable = 0;
            axipropsapiCtrl11.OnSearchExCBEnable = 0;
            axipropsapiCtrl11.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl11.OnOpStatusCBEnable = 0;
            axipropsapiCtrl11.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl11.OnFtpStatusCBEnable = 0;
            //Set properties to connect the device
            axipropsapiCtrl12.IPAddr = (String)ar.GetValue("cam12", typeof(String));
            axipropsapiCtrl12.DeviceType = 2;
            axipropsapiCtrl12.HttpPort = 80;
            axipropsapiCtrl12.UserName = "admin";
            axipropsapiCtrl12.Password = "ibst2997730!";

            //Set properties for display area
            axipropsapiCtrl12.StreamFormat = 0;
            axipropsapiCtrl12.JPEGResolution = 320;
            axipropsapiCtrl12.MPEG4Resolution = 320;
            axipropsapiCtrl12.H264Resolution = 320;

            //Set properties for event
            axipropsapiCtrl12.OnErrorEnable = 1;
            axipropsapiCtrl12.OnDevStatusEnable = 0;
            axipropsapiCtrl12.OnRecStatusEnable = 0;
            axipropsapiCtrl12.OnPlayStatusEnable = 1;
            axipropsapiCtrl12.OnImageRefreshEnable = 0;
            axipropsapiCtrl12.OnRecordStatusEnable = 0;
            axipropsapiCtrl12.OnOpStatusEnable = 0;
            axipropsapiCtrl12.OnAlmStatusEnable = 0;

            axipropsapiCtrl12.OnRecStatusCBEnable = 0;
            axipropsapiCtrl12.OnSearchCBEnable = 0;
            axipropsapiCtrl12.OnSearchExCBEnable = 0;
            axipropsapiCtrl12.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl12.OnOpStatusCBEnable = 0;
            axipropsapiCtrl12.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl12.OnFtpStatusCBEnable = 0;

            CameraControls = new AxIPROPSAPILib.AxipropsapiCtrl[24];
  
            Ctlchecked = new RadioButton[12];

            Ctlchecked[0] = radioButton1;
            Ctlchecked[1] = radioButton2;
            Ctlchecked[2] = radioButton3;
            Ctlchecked[3] = radioButton4;
            Ctlchecked[4] = radioButton5;
            Ctlchecked[5] = radioButton6;
            Ctlchecked[6] = radioButton7;
            Ctlchecked[7] = radioButton8;
            Ctlchecked[8] = radioButton9;
            Ctlchecked[9] = radioButton10;
            Ctlchecked[10] = radioButton11;
            Ctlchecked[11] = radioButton12;
            for (int i = 0; i < 12; i++)
            {
                Ctlchecked[i].Checked = false;
                Ctlchecked[i].Text = (String)ar.GetValue("group" + (i + 1).ToString(), typeof(String));
            }

            CameraControls[0] = axipropsapiCtrl1;
            CameraControls[1] = axipropsapiCtrl2;
            CameraControls[2] = axipropsapiCtrl3;
            CameraControls[3] = axipropsapiCtrl4;
            CameraControls[4] = axipropsapiCtrl5;
            CameraControls[5] = axipropsapiCtrl6;
            CameraControls[6] = axipropsapiCtrl7;
            CameraControls[7] = axipropsapiCtrl8;
            CameraControls[8] = axipropsapiCtrl9;
            CameraControls[9] = axipropsapiCtrl10;
            CameraControls[10] = axipropsapiCtrl11;
            CameraControls[11] = axipropsapiCtrl12;
            for (int i = 0; i < 12; i++)
            {
                CameraControls[i].MouseDownEnable = 1;
                CameraControls[i].DblClickEnable = 1;
                //Audio setting
                axipropsapiCtrl1.AudioRcvEnable = 1;
                axipropsapiCtrl1.AudioRcvVolume = 0;
                axipropsapiCtrl1.AudioRcvMute = 0;
            }

            SelectedCamera = 0;

        }

        //---------------------------------------------------------------------
        // Function Name        : FormClosed
        // Overview             : Destroy log window
        //---------------------------------------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //----------------------------------------
            //Set properties
            //----------------------------------------
            //Set properties for event
            axipropsapiCtrl1.OnErrorEnable = 0;
            axipropsapiCtrl1.OnDevStatusEnable = 0;
            axipropsapiCtrl1.OnRecStatusEnable = 0;
            axipropsapiCtrl1.OnPlayStatusEnable = 0;
            axipropsapiCtrl1.OnImageRefreshEnable = 0;
            axipropsapiCtrl1.OnRecordStatusEnable = 0;
            axipropsapiCtrl1.OnOpStatusEnable = 0;
            axipropsapiCtrl1.OnAlmStatusEnable = 0;

            axipropsapiCtrl1.OnRecStatusCBEnable = 0;
            axipropsapiCtrl1.OnSearchCBEnable = 0;
            axipropsapiCtrl1.OnSearchExCBEnable = 0;
            axipropsapiCtrl1.OnPlayStatusCBEnable = 0;
            axipropsapiCtrl1.OnOpStatusCBEnable = 0;
            axipropsapiCtrl1.OnAlmStatusCBEnable = 0;
            axipropsapiCtrl1.OnFtpStatusCBEnable = 0;

            frmForm2.Close();
        }

        //---------------------------------------------------------------------
        // Function Name        : Logging
        // Overview             : Output Logs
        //---------------------------------------------------------------------
        private void Logging(String str)
        {
            return;

            if (frmForm2.textLog.Text != "")
            {
                frmForm2.textLog.Text = frmForm2.textLog.Text + "\r\n";
            }
            frmForm2.textLog.Text = frmForm2.textLog.Text + str;
        }

        //---------------------------------------------------------------------
        // Function Name        : ShowResult
        // Overview             : Output list Search result
        //---------------------------------------------------------------------
        private void ShowResult()
        {
            //Set Search Result to list
        }

        //---------------------------------------------------------------------
        // Function Name        : ShowResultEx
        // Overview             : Output list SearchEx/VMDSearchEx result
        //---------------------------------------------------------------------
        private void ShowResultEx()
        {
            //Set SearchEx Result to list
        }

        //---------------------------------------------------------------------
        // Function Name        : StartLive
        // Overview             : Start live video play
        //---------------------------------------------------------------------
        private void buttonLiveStart_Click(object sender, EventArgs e)
        {
            //Define variables
            int iRet;
            int iChannel;
            int iBlockingMode;

            //전체 카메라 play
            for (int i = 0; i < 12; i++)
            {
                //Connect to the device
                iRet = CameraControls[i].Open();
                Logging("[Function] Open:" + iRet.ToString());

                if (iRet > -1)
                {
                    //Audio setting
                    CameraControls[i].AudioRcvEnable = 1;
                    CameraControls[i].AudioRcvVolume = 0;
                    CameraControls[i].AudioRcvMute = 0;
                    //CameraControls[i].RcvAudioDec = 0;

                    //Start Live
                    iChannel = 1;
                    iBlockingMode = 0;
                    iRet = CameraControls[i].PlayLive(iChannel, iBlockingMode);
                    Logging("[Function] PlayLive(Start):" + iRet.ToString());

                    if (iRet == 0)
                    {
                        m_PlayStatus = 1;
                    }
                    else
                    {
                        CameraControls[i].Close();
                        Logging("[Function] Close");
                    }
                }
            }
        }

        //---------------------------------------------------------------------
        // Function Name        : StopLive
        // Overview             : Stop live video play
        //---------------------------------------------------------------------
        private void buttonLiveStop_Click(object sender, EventArgs e)
        {
            //Define variables
            int iRet;
            int iCommand;
            int iSpeed;
            int iBlockMode;

            if (m_PlayStatus == 1)
            {
                //Stop Live
                iCommand = 1;
                iSpeed = 0;
                iBlockMode = 0;
                iRet = axipropsapiCtrl1.PlayControl(iCommand, iSpeed, iBlockMode);
                Logging("[Function] PlayLive(Stop):" + iRet.ToString());

                //Close connection to the device
                axipropsapiCtrl1.Close();
                Logging("[Function] Close");

                //ClearImage
                axipropsapiCtrl1.ClearImage();
                Logging("[Function] ClearImage");

                //Change status
                m_PlayStatus = 0;
            }
            else
            {
                Logging("[Message] No live.");
            }
        }

        //---------------------------------------------------------------------
        // Function Name        : Audio Start
        // Overview             : Start Audio transmission
        //---------------------------------------------------------------------
        private void bAudioStart_Click(object sender, EventArgs e)
        {
            //Define variables
            int iRet;
            int iCommand;
            int iStatus;
            axipropsapiCtrl1.AudioRcvMute = 0;
            if (m_PlayStatus == 1)
            {
                //Audio setting
                axipropsapiCtrl1.AudioSendVolume = 10;
                axipropsapiCtrl1.AudioSendMute = 0;

                //Start audio transmission
                iStatus = axipropsapiCtrl1.GetAudioSendStatus();
                if (iStatus == 0)
                {
                    iCommand = 1;
                    iRet = axipropsapiCtrl1.AudioSend(iCommand);
                    Logging("[Function] AudioSend(Start):" + iRet.ToString());
                }
                else
                {
                    Logging("[Message] No audio transmission.");
                }
            }
            else
            {
                Logging("[Message] No live.");
            }
        }

        //---------------------------------------------------------------------
        // Function Name        : Audio Stop
        // Overview             : Stop Audio transmission
        //---------------------------------------------------------------------
        private void bAudioStop_Click(object sender, EventArgs e)
        {
            //Define variables
            int iRet;
            int iCommand;
            int iStatus;

            if (m_PlayStatus == 1)
            {
                //Stop audio transmission
                iStatus = axipropsapiCtrl1.GetAudioSendStatus();
                if (iStatus == 1)
                {
                    iCommand = 0;
                    iRet = axipropsapiCtrl1.AudioSend(iCommand);
                    Logging("[Function] AudioSend(Stop):" + iRet.ToString());
                }
                else
                {
                    Logging("[Message] Cannot use audio transmission.");
                }
            }
            else
            {
                Logging("[Message] No live.");
            }
        }

        //---------------------------------------------------------------------
        // Function Name        : OnError
        // Overview             : OnError listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnError(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnErrorEvent e)
        {
            //Output Logs
            Logging("[OnError] errorCode[" + e.errorCode.ToString() + "] description[" + e.description + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnDevStatus
        // Overview             : OnDevStatus listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnDevStatus(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnDevStatusEvent e)
        {
            //Output Logs
            Logging("[OnDevStatus] channel[" + e.channel + "] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnRecStatu
        // Overview             : OnRecStatu listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnRecStatus(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnRecStatusEvent e)
        {
            //Output Logs
            Logging("[OnRecStatu] channel[" + e.channel + "] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnPlayStatus
        // Overview             : OnPlayStatus listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnPlayStatus(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnPlayStatusEvent e)
        {
            //Output Logs
            Logging("[OnPlayStatus] channel[" + e.channel + "] status[" + e.status + "]");
       }

        //---------------------------------------------------------------------
        // Function Name        : OnRecordStatus
        // Overview             : OnRecordStatus listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnRecordStatus(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnRecordStatusEvent e)
        {
            //Output Logs
            Logging("[OnRecordStatus] type[" + e.recType + "] timeDate[" + e.timeDate + "] nextRecTime[" + e.nextRecTime + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnImageRefresh
        // Overview             : OnImageRefresh listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnImageRefresh(object sender, EventArgs e)
        {
            //Output Logs
            Logging("[OnImageRefresh] No argument.");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnOpStatus
        // Overview             : OnOpStatus listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnOpStatus(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnOpStatusEvent e)
        {
            //Output Logs
            Logging("[OnOpStatus] channel[" + e.channel + "] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnAlmStatus
        // Overview             : OnAlmStatus listener event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnAlmStatus(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnAlmStatusEvent e)
        {
            //Output Logs
            Logging("[OnAlmStatus] channel[" + e.channel + "] type[" + e.alarmtype + "] timeDate[" + e.timeDate + "] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnRecStatusCB
        // Overview             : OnRecStatusCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnRecStatusCB(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnRecStatusCBEvent e)
        {
            //Output Logs
            Logging("[OnRecStatusCB] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnSearchCB
        // Overview             : OnSearchCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnSearchCB(object sender, EventArgs e)
        {
            //Output Logs
            Logging("[OnSearchCB] Show Search result.");
            ShowResult();
        }

        //---------------------------------------------------------------------
        // Function Name        : OnSearchExCB
        // Overview             : OnSearchExCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnSearchExCB(object sender, EventArgs e)
        {
            //Output Logs
            Logging("[OnSearchExCB] Show SearchEx result.");
            ShowResultEx();
        }

        //---------------------------------------------------------------------
        // Function Name        : OnPlayStatusCB
        // Overview             : OnPlayStatusCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnPlayStatusCB(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnPlayStatusCBEvent e)
        {
            //Output Logs
            Logging("[OnPlayStatusCB] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnOpStatusCB
        // Overview             : OnOpStatusCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnOpStatusCB(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnOpStatusCBEvent e)
        {
            //Output Logs
            Logging("[OnOpStatusCB] status[" + e.status + "]");
        }

        //---------------------------------------------------------------------
        // Function Name        : OnAlmStatusCB
        // Overview             : OnAlmStatusCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnAlmStatusCB(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnAlmStatusCBEvent e)
        {
            //Output Logs
            Logging("[OnAlmStatusCB] status[" + e.status + "]");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = false;
            //Audio setting
            CameraControls[SelectedCamera].AudioRcvVolume = 80;
             }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button1.Visible = true;
            //Audio setting
            CameraControls[SelectedCamera].AudioRcvVolume = 0;
        }

        private void AxipropsapiCtrl1_OnError_1(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnErrorEvent e)
        {

        }

        private void AxipropsapiCtrl1_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 0;
            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl1_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 0;
            Ctlchecked[0].Checked = true;
        }
        private void AxipropsapiCtrl5_OnError(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnErrorEvent e)
        {
            SelectedCamera = 4;
            //   button3.PerformClick();
        }

        private void AxipropsapiCtrl5_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {

            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 4;
            Ctlchecked[4].Checked = true;
        }



        private void AxipropsapiCtrl2_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 1;
            Ctlchecked[1].Checked = true;
        }

        private void AxipropsapiCtrl3_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 2;
            Ctlchecked[2].Checked = true;
        }

        private void AxipropsapiCtrl4_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 3;
            Ctlchecked[3].Checked = true;
        }

        private void AxipropsapiCtrl6_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 5;
            Ctlchecked[5].Checked = true;
        }

        private void AxipropsapiCtrl7_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 6;
            Ctlchecked[6].Checked = true;
        }

        private void AxipropsapiCtrl8_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 7;
            Ctlchecked[7].Checked = true;
        }

        private void AxipropsapiCtrl9_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 8;
            Ctlchecked[8].Checked = true;
        }

        private void AxipropsapiCtrl11_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 10;
            Ctlchecked[10].Checked = true;
        }

        private void AxipropsapiCtrl10_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 9;
            Ctlchecked[9].Checked = true;
        }

        private void AxipropsapiCtrl12_MouseDownEvent(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_MouseDownEvent e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 11;
            Ctlchecked[11].Checked = true;
        }


        private void AxipropsapiCtrl2_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 1;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl3_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 2;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl4_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 3;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl9_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 8;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl6_OnError(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnErrorEvent e)
        {

        }

        private void AxipropsapiCtrl6_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 5;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl7_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 6;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl8_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 7;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl10_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 9;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl11_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 10;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl12_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 11;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void AxipropsapiCtrl5_DblClick(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_DblClickEvent e)
        {
            SelectedCamera = 4;

            CamView.View v = new CamView.View(CameraControls[SelectedCamera].IPAddr);
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int iRet;
            int iChannel;
            int iPan;
            int iTilt;
            int iZoom;
            int iFocus;
            int iIris;


            iChannel = 1;
            iPan = 0;
            iTilt = -30;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
            System.Threading.Thread.Sleep(1000);
            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = axipropsapiCtrl1.CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int iRet;
            int iChannel;
            int iPan;
            int iTilt;
            int iZoom;
            int iFocus;
            int iIris;


            iChannel = 1;
            iPan = 0;
            iTilt = 30;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
            System.Threading.Thread.Sleep(1000);
            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            int iRet;
            int iChannel;
            int iPan;
            int iTilt;
            int iZoom;
            int iFocus;
            int iIris;


            iChannel = 1;
            iPan = -30;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
            System.Threading.Thread.Sleep(1000);
            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int iRet;
            int iChannel;
            int iPan;
            int iTilt;
            int iZoom;
            int iFocus;
            int iIris;


            iChannel = 1;
            iPan = 30;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
            System.Threading.Thread.Sleep(1000);
            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (!fullscreen)
            {
                fullscreen = true;
                saved_posiztion = CameraControls[SelectedCamera].Location;
                //Borders[0].Location = new Point(0, 0);
                save_Width = CameraControls[SelectedCamera].Width;
                save_Height = CameraControls[SelectedCamera].Height;
                CameraControls[SelectedCamera].Width = 1024; //349,255
                CameraControls[SelectedCamera].Height = 768;
                CameraControls[SelectedCamera].BringToFront();
                // CameraControls[SelectedCamera].Location.X = 0;
                CameraControls[SelectedCamera].Location = new Point(300, 150);

            }
            else
            {
                fullscreen = false;

                //Borders[0].Location = new Point(0, 0);
                CameraControls[SelectedCamera].Width = save_Width; //349,255
                CameraControls[SelectedCamera].Height = save_Height;
                CameraControls[SelectedCamera].BringToFront();
                // CameraControls[SelectedCamera].Location.X = 0;
                CameraControls[SelectedCamera].Location = saved_posiztion;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int iRet;
            int iChannel;
            int iPan;
            int iTilt;
            int iZoom;
            int iFocus;
            int iIris;


            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 1;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
            Logging("[Function] CamControl(Tele):" + iRet.ToString());
            System.Threading.Thread.Sleep(1000);
            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int iRet;
            int iChannel;
            int iPan;
            int iTilt;
            int iZoom;
            int iFocus;
            int iIris;


            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = -1;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
            Logging("[Function] CamControl(Tele):" + iRet.ToString());
            System.Threading.Thread.Sleep(1000);
            iChannel = 1;
            iPan = 0;
            iTilt = 0;
            iZoom = 0;
            iFocus = 0;
            iIris = 0;
            iRet = CameraControls[SelectedCamera].CameraControl(iChannel, iPan, iTilt, iZoom, iFocus, iIris);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 0;
            Ctlchecked[0].Checked = true;
        }

        private void RadioButton2_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 1;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton3_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 2;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton4_MouseEnter(object sender, EventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 3;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton5_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 4;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton6_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 5;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton7_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 6;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton8_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 7;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton9_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 8;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton10_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 9;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton11_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 10;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        private void RadioButton12_MouseDown(object sender, MouseEventArgs e)
        {
            Ctlchecked[SelectedCamera].Checked = false;
            SelectedCamera = 11;
            Ctlchecked[SelectedCamera].Checked = true;
        }

        //---------------------------------------------------------------------
        // Function Name        : OnFtpStatusCB
        // Overview             : OnFtpStatusCB callback event
        //---------------------------------------------------------------------
        private void axipropsapiCtrl1_OnFtpStatusCB(object sender, AxIPROPSAPILib._IipropsapiCtrlEvents_OnFtpStatusCBEvent e)
        {
            //Output Logs
            Logging("[OnFtpStatusCB] status[" + e.status + "]");
        }
    }
}