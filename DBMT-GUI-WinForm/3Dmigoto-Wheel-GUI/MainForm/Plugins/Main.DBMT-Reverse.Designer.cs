using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMBT_GUI
{
    partial class Main
    {

        public bool CheckD3dxiniSetting(string checkSetting, string checkValue)
        {
            if (!File.Exists(Path_D3DXINI))
            {
                return false;
            }

            // Read all lines from the file
            var lines = File.ReadAllLines(Path_D3DXINI);

            foreach (var line in lines)
            {
                if (line.TrimStart().StartsWith(checkSetting, StringComparison.OrdinalIgnoreCase))
                {
                    if (line.Contains('='))
                    {
                        string value = line.Split('=')[1].Trim();
                        if (value == checkValue)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        void DBMT_Reverse_Lv4_ReverseExtract()
        {
            //先检测d3dx.ini中 track_texture_updates=1 是否设为1，如果不是则弹出提示

            bool isTrackTextureUpdatesEquals1 = CheckD3dxiniSetting("track_texture_updates","1");
            if(!isTrackTextureUpdatesEquals1)
            {
                MessageBox.Show("检测到您的d3dx.ini中track_texture_updates并未设为1，请将此配置设为1后再使用逆向提取功能。");
            }
            else
            {
                preDoBeforeMerge();
                bool command_run_result = runCommand("ReverseExtract", "3Dmigoto-Sword-Lv5.vmp.exe");
                if (command_run_result)
                {
                    convertAllDdsToTgaInOutputFolder();
                    Process.Start(this.Path_OutputFolder);
                }
            }
          
        }

        string RunReverseIniCommand(string commandStr)
        {
            if (string.IsNullOrEmpty(CurrentGameName))
            {
                ShowMessageBox("Please select your current game before reverse.", "在逆向Mod之前请选择当前要进行格式转换的二创模型的所属游戏");
                return "";
            }

            openFileDialog1.Filter = "INI Files (*.ini)|*.ini";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                if (ContainsChinese(filePath))
                {
                    ShowMessageBox("Target mod ini file path can't contains Chinese.", "目标Mod的ini文件路径中不能出现中文");
                    return "";
                }

                string json = File.ReadAllText(this.Path_RunInputJson); // 读取文件内容
                JObject runInputJson = JObject.Parse(json);
                runInputJson["GameName"] = CurrentGameName;
                runInputJson["ReverseFilePath"] = filePath;
                File.WriteAllText(this.Path_RunInputJson, runInputJson.ToString());

                runCommand(commandStr, "3Dmigoto-Sword-Lv5.vmp.exe");
                
                return filePath;
            }
            else
            {
                return "";
            }
        }

        void DBMT_Reverse_Lv4_MergedNameSpace()
        {
            if (string.IsNullOrEmpty(CurrentGameName))
            {
                ShowMessageBox("Please select your current game before reverse.", "在逆向Mod之前请选择当前要进行格式转换的二创模型的所属游戏");
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = folderBrowserDialog1.SelectedPath;
                if (ContainsChinese(filePath))
                {
                    ShowMessageBox("Target mod ini file path can't contains Chinese.", "目标Mod的ini文件路径中不能出现中文");
                    //MessageBox.Show("Target mod ini file path can't contains Chinese.", "目标Mod的ini文件路径中不能出现中文");
                    return;
                }

                string json = File.ReadAllText(this.Path_RunInputJson); // 读取文件内容
                JObject runInputJson = JObject.Parse(json);
                runInputJson["GameName"] = CurrentGameName;
                runInputJson["ReverseFilePath"] = filePath;
                File.WriteAllText(this.Path_RunInputJson, runInputJson.ToString());

                runCommand("ReverseMergedNameSpaceLv4");
            }
        }


        void DBMT_Reverse_Lv4_3DmigotoSimulator()
        {
            if (string.IsNullOrEmpty(CurrentGameName))
            {
                ShowMessageBox("Please select your current game before reverse.", "在逆向Mod之前请选择当前要进行格式转换的二创模型的所属游戏");
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = folderBrowserDialog1.SelectedPath;
                if (ContainsChinese(filePath))
                {
                    ShowMessageBox("Target mod ini file path can't contains Chinese.", "目标Mod的ini文件路径中不能出现中文");
                    //MessageBox.Show("Target mod ini file path can't contains Chinese.", "目标Mod的ini文件路径中不能出现中文");
                    return;
                }

                string json = File.ReadAllText(this.Path_RunInputJson); // 读取文件内容
                JObject runInputJson = JObject.Parse(json);
                runInputJson["GameName"] = CurrentGameName;
                runInputJson["ReverseFilePath"] = filePath;
                File.WriteAllText(this.Path_RunInputJson, runInputJson.ToString());

                runCommand("Reverse3DmigotoSimulatorLv4", "MMT-Reverse.exe");
            }
        }

    }
}
