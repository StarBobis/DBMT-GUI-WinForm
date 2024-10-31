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
        string GetLatestFrameAnalysisFolder()
        {
            try
            {
                string[] directories = Directory.GetDirectories(Path_LoaderFolder);
                List<string> frameAnalysisFileList = new List<string>();
                foreach (string directory in directories)
                {
                    string directoryName = Path.GetFileName(directory);

                    if (directoryName.StartsWith("FrameAnalysis-"))
                    {
                        frameAnalysisFileList.Add(directoryName);
                    }
                }

                //
                if (frameAnalysisFileList.Count > 0)
                {
                    frameAnalysisFileList.Sort();

                    string latestFrameAnalysisFolder = Path_LoaderFolder.Replace("/", "\\") + frameAnalysisFileList.Last();
                    return latestFrameAnalysisFolder;
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("An IO exception has occurred: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("You do not have permission to access one or more folders: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected exception has occurred: " + ex.Message);
            }

            return "";
        }

        void Menu_File_OpenD3DXIni()
        {
            if (Directory.Exists(Path_LoaderFolder))
            {
                Process.Start(Path_D3DXINI);
            }
            else
            {
                ShowMessageBox("Your 3Dmigoto directory doesn't exists.", "您的3Dmigoto目录不存在，请检查3Dmigoto文件夹是否配置正确");
            }
        }

        void Menu_File_OpenModsFolder()
        {
            string modsFolder = this.Path_LoaderFolder + "Mods/";
            if (!string.IsNullOrEmpty(modsFolder))
            {
                if (Directory.Exists(modsFolder))
                {
                    Process.Start(modsFolder);
                }
                else
                {
                    ShowMessageBox("This path didn't exists, please check if your Mods folder is correct", "此目录不存在，请检查您的Mods文件夹是否设置正确");
                    //MessageBox.Show("此目录不存在，请检查您的Mods文件夹是否设置正确");
                }
            }
        }

        void Menu_File_OpenDedupedFolder()
        {
            string latestFrameAnalysisFolder = GetLatestFrameAnalysisFolder();
            if (!string.IsNullOrEmpty(latestFrameAnalysisFolder))
            {
                Process.Start(latestFrameAnalysisFolder + "\\deduped\\");
            }
            else
            {
                ShowMessageBox("Target directory didn't have any FrameAnalysisFolder.", "目标目录没有任何帧分析文件夹");
            }
        }


        void Menu_File_OpenLatestFrameAnalysisLogTxtFile()
        {
            try
            {
                string[] directories = Directory.GetDirectories(Path_LoaderFolder);
                List<string> frameAnalysisFileList = new List<string>();
                foreach (string directory in directories)
                {
                    string directoryName = Path.GetFileName(directory);

                    if (directoryName.StartsWith("FrameAnalysis-"))
                    {
                        frameAnalysisFileList.Add(directoryName);
                    }
                }

                //
                if (frameAnalysisFileList.Count > 0)
                {
                    frameAnalysisFileList.Sort();

                    string latestFrameAnalysisFolder = Path_LoaderFolder.Replace("/", "\\") + frameAnalysisFileList.Last();

                    Process.Start(latestFrameAnalysisFolder + "\\log.txt");
                    //MessageBox.Show(latestFrameAnalysisFolderName);
                }
                else
                {
                    ShowMessageBox("Target directory didn't have any FrameAnalysisFolder.", "目标目录没有任何帧分析文件夹");
                    //MessageBox.Show("Target directory didn't have any FrameAnalysisFolder.");
                }


            }
            catch (IOException ex)
            {
                MessageBox.Show("An IO exception has occurred: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("You do not have permission to access one or more folders: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected exception has occurred: " + ex.Message);
            }
        }


        void Menu_File_OpenLatestLogFile()
        {
            //然后打开最新的Log文件
            string logsPath = basePath + "Logs";
            if (!Directory.Exists(logsPath))
            {
                return;
            }
            string[] logFiles = Directory.GetFiles(logsPath); ;
            List<string> logFileList = new List<string>();
            foreach (string logFile in logFiles)
            {
                string logfileName = Path.GetFileName(logFile);
                if (logfileName.EndsWith(".log") && logfileName.Length > 15)
                {
                    logFileList.Add(logfileName);
                }
            }

            logFileList.Sort();
            Process.Start(logsPath + "\\" + logFileList[logFileList.Count - 1]);
        }


        void Menu_File_OpenOutputFolder()
        {
            if (!string.IsNullOrEmpty(this.Path_OutputFolder))
            {
                if (Directory.Exists(Path_OutputFolder))
                {
                    Process.Start(this.Path_OutputFolder);
                }
                else
                {
                    ShowMessageBox("This folder doesn't exists,please check if your OutputFolder is correct.", "此目录不存在，请检查您的Output文件夹是否设置正确");
                    //MessageBox.Show("此目录不存在，请检查您的Output文件夹是否设置正确");
                }
            }
        }


        void Menu_File_OpenShaderFixesFolder()
        {
            string modsFolder = this.Path_LoaderFolder + "ShaderFixes/";
            if (!string.IsNullOrEmpty(modsFolder))
            {
                if (Directory.Exists(modsFolder))
                {
                    Process.Start(modsFolder.Replace("/", "\\"));
                }
                else
                {
                    ShowMessageBox("This folder didn't exsits,please check if your ShaderFixes folder is correct.", "此目录不存在，请检查您的ShaderFixs文件夹是否设置正确");
                    //MessageBox.Show("此目录不存在，请检查您的ShaderFixs文件夹是否设置正确");
                }
            }
        }


        void Menu_File_Open3DmigotoFolder()
        {
            if (Directory.Exists(Path_LoaderFolder))
            {
                Process.Start(Path_LoaderFolder.Replace("/", "\\"));
            }
            else
            {
                ShowMessageBox("This directory doesn't exists.", "此目录不存在，请检查3Dmigoto文件夹是否配置正确");
                //MessageBox.Show("This directory doesn't exists.");
            }
        }


        void Menu_File_OpenModGenerateFolder()
        {
            if (!string.IsNullOrEmpty(this.Path_OutputFolder))
            {
                //DateTime currentDate = DateTime.Now;
                //string formattedDate = currentDate.ToString("yyyy_MM_dd");
                string targetFolder = this.Path_OutputFolder + "/GeneratedMod/";
                if (Directory.Exists(targetFolder))
                {
                    Process.Start(targetFolder);
                }
                else
                {
                    ShowMessageBox("You have not generate any mod yet", "您还未生成二创模型");
                    //MessageBox.Show("您还未生成二创模型");
                }
            }
        }

    }
}
