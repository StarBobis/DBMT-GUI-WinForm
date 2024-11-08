﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NMBT_GUI
{
    partial class ConfigGame
    {

        void ShowMessageBox(string EnglishTip, string ChineseTip)
        {
            MessageBox.Show(ChineseTip);
        }

        public void resetConfig()
        {
            checkBoxBackUp.Checked = true;
            checkBoxBackUp.Checked = false;

            checkBoxDeleteOutputFolder.Checked = true;
            checkBoxDeleteOutputFolder.Checked = false;


            checkBoxAutoCleanLog.Checked = true;
            checkBoxAutoCleanLog.Checked = false;
            textBoxLogReserveNumber.Text = string.Empty;

            checkBoxAutoCleanFrameAnalysisFolder.Checked = true;
            checkBoxAutoCleanFrameAnalysisFolder.Checked = false;
            textBoxFrameAnalysisFolderReserveNumber.Text = string.Empty;

            checkBox_AutoTextureOnlyConvertDiffuseMap.Checked = true;

            checkBoxTopMost.Checked = true;
            checkBoxTopMost.Checked = false;

            checkBoxShareSourceModel.Checked = true;
            checkBoxShareSourceModel.Checked = false;

            textBoxAuthor.Text = string.Empty;
            textBoxAuthorLink.Text = string.Empty;

            checkBoxOpenModOutputFolder.Checked = true;
            checkBoxOpenModOutputFolder.Checked = false;

            checkBoxDynamicVertexLimitBreak.Checked = true;
            checkBoxDynamicVertexLimitBreak.Checked = false;

            //贴图文件格式
            comboBoxTextureFormat.SelectedIndex = 0;
            //模型文件命名风格
            comboBoxModelFileNameStyle.SelectedIndex = 0;

            //MoveIBRelatedFiles
            checkBoxMoveIBRelatedFiles.Checked = true;
            checkBoxMoveIBRelatedFiles.Checked = false;

            //ConvertDedupedTextures
            checkBoxConvertDedupedTextures.Checked = true;
            checkBoxConvertDedupedTextures.Checked = false;

            //DontSplitModelByMatchFirstIndex
            checkBoxDontSplitModelByMatchFirstIndex.Checked = true;
            checkBoxDontSplitModelByMatchFirstIndex.Checked = false;

            //ForbidAutoTexture
            checkBox_ForbidAutoTexture.Checked = true;
            checkBox_ForbidAutoTexture.Checked = false;

            //UseHashTexture
            checkBoxUseHashTexture.Checked = true;
            checkBoxUseHashTexture.Checked = false;

        }


        public void readConfig()
        {
            //读取json配置文件
            
            if (File.Exists(Path_Setting))
            {
                string json = File.ReadAllText(Path_Setting); // 读取文件内容
                JObject gameObject = JObject.Parse(json);

                 
                checkBoxBackUp.Checked = (bool)gameObject["BackUp"];
                checkBoxDeleteOutputFolder.Checked = (bool)gameObject["DeleteOutputFolder"];
                  

                //自动清理FrameAnalysis文件夹
                bool autoCleanFrameAnalysisFolder = (bool)gameObject["AutoCleanFrameAnalysisFolder"];
                int frameAnalysisFolderReserveNumber = (int)gameObject["FrameAnalysisFolderReserveNumber"];
                if (autoCleanFrameAnalysisFolder)
                {
                    checkBoxAutoCleanFrameAnalysisFolder.Checked = true;
                    textBoxFrameAnalysisFolderReserveNumber.Text = frameAnalysisFolderReserveNumber + "";
                }

                bool autoCleanLogFile = (bool)gameObject["AutoCleanLogFile"];
                int logFileReserveNumber = (int)gameObject["LogFileReserveNumber"];
                if (autoCleanLogFile)
                {
                    checkBoxAutoCleanLog.Checked = true;
                    textBoxLogReserveNumber.Text = logFileReserveNumber + "";
                }

                if (gameObject.ContainsKey("AutoTextureOnlyConvertDiffuseMap"))
                {
                    checkBox_AutoTextureOnlyConvertDiffuseMap.Checked = (bool)gameObject["AutoTextureOnlyConvertDiffuseMap"];
                }

                if (gameObject.ContainsKey("MMTWindowTopMost"))
                {
                    checkBoxTopMost.Checked = (bool)gameObject["MMTWindowTopMost"];
                }

                if (gameObject.ContainsKey("ShareSourceModel"))
                {
                    checkBoxShareSourceModel.Checked = (bool)gameObject["ShareSourceModel"];
                }

                if (gameObject.ContainsKey("Author"))
                {
                    textBoxAuthor.Text = (string)gameObject["Author"];
                }

                if (gameObject.ContainsKey("AuthorLink"))
                {
                    textBoxAuthorLink.Text = (string)gameObject["AuthorLink"];
                }

                if (gameObject.ContainsKey("OpenModOutputFolderAfterGenerateMod"))
                {
                    checkBoxOpenModOutputFolder.Checked = (bool)gameObject["OpenModOutputFolderAfterGenerateMod"];
                }

                if (gameObject.ContainsKey("DynamicVertexLimitBreak"))
                {
                    checkBoxDynamicVertexLimitBreak.Checked = (bool)gameObject["DynamicVertexLimitBreak"];
                }

                if (gameObject.ContainsKey("AutoTextureFormat"))
                {
                    comboBoxTextureFormat.SelectedIndex = (int)gameObject["AutoTextureFormat"];
                }

                //模型文件命名风格
                if (gameObject.ContainsKey("ModelFileNameStyle"))
                {
                    comboBoxModelFileNameStyle.SelectedIndex = (int)gameObject["ModelFileNameStyle"];
                }

                //MoveIBRelatedFiles
                if (gameObject.ContainsKey("MoveIBRelatedFiles"))
                {
                    checkBoxMoveIBRelatedFiles.Checked = (bool)gameObject["MoveIBRelatedFiles"];
                }

                //ConvertDedupedTextures
                if (gameObject.ContainsKey("ConvertDedupedTextures"))
                {
                    checkBoxConvertDedupedTextures.Checked = (bool)gameObject["ConvertDedupedTextures"];
                }

                //DontSplitModelByMatchFirstIndex
                if (gameObject.ContainsKey("DontSplitModelByMatchFirstIndex"))
                {
                    checkBoxDontSplitModelByMatchFirstIndex.Checked = (bool)gameObject["DontSplitModelByMatchFirstIndex"];
                }

                //ForbidAutoTexture
                if (gameObject.ContainsKey("ForbidAutoTexture"))
                {
                    checkBox_ForbidAutoTexture.Checked = (bool)gameObject["ForbidAutoTexture"];
                }

                //UseHashTexture
                if (gameObject.ContainsKey("UseHashTexture"))
                {
                    checkBoxUseHashTexture.Checked = (bool)gameObject["UseHashTexture"];
                }

            }
        }


        public bool saveConfig()
        {
            //检查数量是否输入完成要保留的数字
            if (checkBoxAutoCleanFrameAnalysisFolder.Checked)
            {
                if (string.IsNullOrEmpty(textBoxFrameAnalysisFolderReserveNumber.Text))
                {
                    ShowMessageBox("Please fill reserve number for FrameAnalysisFolder.","请输入要保留的FrameAnalysisFolder的数量");
                    return false;
                }
            }

            if (checkBoxAutoCleanLog.Checked)
            {
                if (string.IsNullOrEmpty(textBoxLogReserveNumber.Text))
                {
                    ShowMessageBox("Please fill reserve number for log files.", "请输入要保留的日志文件的数量");
                    return false;
                }
            }


            if (File.Exists(Path_Setting))
            {
                //获取游戏类型
                JObject gameObject = new JObject();

                gameObject["BackUp"] = checkBoxBackUp.Checked;
                gameObject["DeleteOutputFolder"] = checkBoxDeleteOutputFolder.Checked;
                gameObject["AutoTextureOnlyConvertDiffuseMap"] = checkBox_AutoTextureOnlyConvertDiffuseMap.Checked;
                gameObject["MMTWindowTopMost"] = checkBoxTopMost.Checked;
                gameObject["ShareSourceModel"] = checkBoxShareSourceModel.Checked;
                gameObject["Author"] = textBoxAuthor.Text;
                gameObject["AuthorLink"] = textBoxAuthorLink.Text;

                gameObject["OpenModOutputFolderAfterGenerateMod"] = checkBoxOpenModOutputFolder.Checked;
                gameObject["DynamicVertexLimitBreak"] = checkBoxDynamicVertexLimitBreak.Checked;

                gameObject["AutoTextureFormat"] = comboBoxTextureFormat.SelectedIndex;

                //ModelFileNameStyle
                gameObject["ModelFileNameStyle"] = comboBoxModelFileNameStyle.SelectedIndex;

                //MoveIBRelatedFiles
                gameObject["MoveIBRelatedFiles"] = checkBoxMoveIBRelatedFiles.Checked;

                //ConvertDedupedTextures
                gameObject["ConvertDedupedTextures"] = checkBoxConvertDedupedTextures.Checked;

                //DontSplitModelByMatchFirstIndex
                gameObject["DontSplitModelByMatchFirstIndex"] = checkBoxDontSplitModelByMatchFirstIndex.Checked;

                //ForbidAutoTexture
                gameObject["ForbidAutoTexture"] = checkBox_ForbidAutoTexture.Checked;

                //UseHashTexture
                gameObject["UseHashTexture"] = checkBoxUseHashTexture.Checked;


                if (checkBoxAutoCleanFrameAnalysisFolder.Checked)
                {
                    gameObject["AutoCleanFrameAnalysisFolder"] = true;
                    gameObject["FrameAnalysisFolderReserveNumber"] = int.Parse(textBoxFrameAnalysisFolderReserveNumber.Text);
                }
                else
                {
                    gameObject["AutoCleanFrameAnalysisFolder"] = false;
                    gameObject["FrameAnalysisFolderReserveNumber"] = 0;
                }

                if (checkBoxAutoCleanLog.Checked)
                {
                    gameObject["AutoCleanLogFile"] = true;
                    gameObject["LogFileReserveNumber"] = int.Parse(textBoxLogReserveNumber.Text);
                }
                else
                {
                    gameObject["AutoCleanLogFile"] = false;
                    gameObject["LogFileReserveNumber"] = 0;
                }


                // 将JObject转换为JSON字符串
                string json_string = gameObject.ToString(Formatting.Indented);

                // 将JSON字符串写入文件
                File.WriteAllText(Path_Setting, json_string);

            }
            else
            {
                MessageBox.Show("Didn't exists");
            }
            return true;
        }


    }
}
