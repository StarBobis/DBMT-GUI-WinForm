﻿using Newtonsoft.Json.Linq;
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

namespace NMBT_GUI
{
    public partial class ConfigMod : Form
    {
        private string DrawIB = "";
        private string CurrentGame = "";
        private string Path_Game_ConfigJson = "";
        private Dictionary<string, List<string>> game_type_dict = new Dictionary<string, List<string>>();
        private string OutputFolder = "";

        public ConfigMod()
        {
            InitializeComponent();
        }

      

        public ConfigMod(string DrawIB, string CurrentGame)
        {
            InitializeComponent();
            this.DrawIB = DrawIB;
            this.CurrentGame = CurrentGame;
            this.OutputFolder = "Games\\" + CurrentGame + "\\3Dmigoto\\Mods\\output";
            this.Path_Game_ConfigJson = "Games\\" + this.CurrentGame + "\\Config.json";

            //初始化游戏数据类型列表
            InitializeGameTypeList();

            //接下来根据传递的DrawIB读取配置文件，如果不存在配置，则为从新开始配置。
            resetConfig();

            //游戏类型要从固定的游戏类型中读取
            comboBoxGameType.Items.Clear();
            comboBoxGameType.Items.AddRange(game_type_dict[this.CurrentGame].ToArray());
            comboBoxGameType.SelectedIndex = 0;

            if (this.CurrentGame == "GI" || this.CurrentGame == "HSR" )
            {
                checkBoxTANGENT.Checked = true;
            }

            readConfig();
        }

        private void ConfigMod_Load(object sender, EventArgs e)
        {
            
        }

        private void Menu_InitializeConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetConfig();
        }

       
        
        private void ConfigMod_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            bool checkResult = checkConfig();
            if (checkResult)
            {
                saveConfig();
            }
            else
            {
                ShowMessageBox("Save failed! Please check your config!", "保存失败，请检查您的配置！");
            }
        }

        private void checkBoxColorRGBR_CheckedChanged(object sender, EventArgs e)
        {
            textBoxColorRGBR.Enabled = checkBoxColorRGBR.Checked;
        }



        private void checkBoxColorRGBB_CheckedChanged(object sender, EventArgs e)
        {
            textBoxColorRGBB.Enabled = checkBoxColorRGBB.Checked;
        }

        private void checkBoxColorRGBG_CheckedChanged(object sender, EventArgs e)
        {
            textBoxColorRGBG.Enabled = checkBoxColorRGBG.Checked;
        }

        private void checkBoxColorRGBA_CheckedChanged(object sender, EventArgs e)
        {
            textBoxColorRGBA.Enabled = checkBoxColorRGBA.Checked;
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxColorRGBR.Checked = true;
            checkBoxColorRGBG.Checked = true;
            checkBoxColorRGBB.Checked = true;
            checkBoxColorRGBA.Checked = true;
            textBoxColorRGBR.Text = "255";
            textBoxColorRGBG.Text = "1";
            textBoxColorRGBB.Text = "128";
            textBoxColorRGBA.Text = "77";
        }

        private void hSR2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxColorRGBR.Checked = true;
            checkBoxColorRGBG.Checked = true;
            checkBoxColorRGBB.Checked = true;
            checkBoxColorRGBA.Checked = false;
            textBoxColorRGBR.Text = "255";
            textBoxColorRGBG.Text = "128";
            textBoxColorRGBB.Text = "128";
        }
    }
}
