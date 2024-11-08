﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NMBT_GUI
{
    public partial class ConfigGame : Form
    {
        private string Path_Setting = "Configs\\Setting.json";

        //当前程序运行所在位置的路径,注意这里已经包含了结尾的\\
        string basePath = AppDomain.CurrentDomain.BaseDirectory.ToString();

        public ConfigGame()
        {
            InitializeComponent();
        }


        private void ConfigBasic_Load(object sender, EventArgs e)
        {
            //先重置
            resetConfig();
            //再读取
            readConfig();
        }

        private void checkBoxAutoCleanLog_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLogReserveNumber.Enabled = checkBoxAutoCleanLog.Checked;
        }

        private void checkBoxAutoCleanFrameAnalysisFolder_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFrameAnalysisFolderReserveNumber.Enabled = checkBoxAutoCleanFrameAnalysisFolder.Checked;
        }


        private void ConfigGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveConfig();
        }

        private void checkBoxUnsafeMode_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
