using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace NMBT_GUI
{
    partial class Main
    {
        public bool ContainsChinese(string input)
        {
            // 使用正则表达式匹配中文字符
            Regex regex = new Regex(@"[\u4e00-\u9fa5]");
            return regex.IsMatch(input);
        }

        void ConvertDedupedTexturesToTargetFormat()
        {
            string TextureFormatString = "jpg";
            if (this.AutoTextureFormat == 0)
            {
                TextureFormatString = "jpg";
            }
            else if (this.AutoTextureFormat == 1)
            {
                TextureFormatString = "tga";
            }
            else if (this.AutoTextureFormat == 2)
            {
                TextureFormatString = "png";
            }

            //在这里把所有output目录下的dds转为png格式
            string[] subdirectories = Directory.GetDirectories(this.Path_OutputFolder);
            foreach (string outputDirectory in subdirectories)
            {

                string DedupedTexturesFolderPath = outputDirectory + "\\DedupedTextures\\";
                if (!Directory.Exists(DedupedTexturesFolderPath))
                {
                    continue;
                }

                string DedupedTexturesConvertFolderPath = outputDirectory + "\\DedupedTextures_" + TextureFormatString + "\\";
                Directory.CreateDirectory(DedupedTexturesConvertFolderPath);

                string[] filePathArray = Directory.GetFiles(DedupedTexturesFolderPath);
                foreach (string ddsFilePath in filePathArray)
                {

                    Process process = new Process();
                    process.StartInfo.FileName = basePath + "Plugins\\texconv.exe";
                    if (!File.Exists(process.StartInfo.FileName))
                    {
                        ShowMessageBox("Current run path didn't exsits: " + process.StartInfo.FileName, "当前要执行的路径不存在: " + process.StartInfo.FileName);
                    }

                    

                    process.StartInfo.Arguments = " " + ddsFilePath + " -ft " + TextureFormatString + " -o " + DedupedTexturesConvertFolderPath;
                    process.StartInfo.UseShellExecute = false;  // 不使用操作系统的shell启动程序
                    process.StartInfo.RedirectStandardOutput = false;  // 重定向标准输出
                    process.StartInfo.RedirectStandardError = false;   // 重定向标准错误输出
                    process.StartInfo.CreateNoWindow = true;  // 不创建新窗口
                    process.Start();
                    process.WaitForExit();
                }
            }
        }


        void ConvertAllTextureFilesToTargetFolder(string SourceFolderPath, string TargetFolderPath)
        {
          
            string[] filePathArray = Directory.GetFiles(SourceFolderPath);
            foreach (string ddsFilePath in filePathArray)
            {
                //只转换dds格式和png格式贴图
                if (!ddsFilePath.EndsWith(".dds") && !ddsFilePath.EndsWith(".png"))
                {
                    continue;
                }
                //MessageBox.Show(ddsFilePath);

                Process process = new Process();
                process.StartInfo.FileName = basePath + "Plugins\\texconv.exe";
                if (!File.Exists(process.StartInfo.FileName))
                {
                    ShowMessageBox("Current run path didn't exsits: " + process.StartInfo.FileName, "当前要执行的路径不存在: " + process.StartInfo.FileName);
                }

                string TextureFormatString = "jpg";
                if (this.AutoTextureFormat == 0)
                {
                    TextureFormatString = "jpg";
                }
                else if (this.AutoTextureFormat == 1)
                {
                    TextureFormatString = "tga";
                }
                else if (this.AutoTextureFormat == 2)
                {
                    TextureFormatString = "png";
                }

                process.StartInfo.Arguments = " " + ddsFilePath + " -ft " + TextureFormatString + " -o " + TargetFolderPath;
                process.StartInfo.UseShellExecute = false;  // 不使用操作系统的shell启动程序
                process.StartInfo.RedirectStandardOutput = false;  // 重定向标准输出
                process.StartInfo.RedirectStandardError = false;   // 重定向标准错误输出
                process.StartInfo.CreateNoWindow = true;  // 不创建新窗口
                process.Start();
                process.WaitForExit();

                //MessageBox.Show(ddsFilePath + " 转换完成");
            }

        }


        void convertAllDdsToTgaInOutputFolder()
        {
            //在这里把所有output目录下的dds转为png格式
            string[] subdirectories = Directory.GetDirectories(this.Path_OutputFolder);
            foreach (string outputDirectory in subdirectories)
            {
                string[] filePathArray = Directory.GetFiles(outputDirectory);
                foreach (string ddsFilePath in filePathArray)
                {
                    if (this.AutoTextureOnlyConvertDiffuseMap)
                    {
                        if (!ddsFilePath.EndsWith("DiffuseMap.dds"))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (!ddsFilePath.EndsWith(".dds"))
                        {
                            continue;
                        }
                    }

                    Process process = new Process();
                    process.StartInfo.FileName = basePath + "Plugins\\texconv.exe";
                    if (!File.Exists(process.StartInfo.FileName))
                    {
                        ShowMessageBox("Current run path didn't exsits: " + process.StartInfo.FileName, "当前要执行的路径不存在: " + process.StartInfo.FileName);
                    }

                    string TextureFormatString = "jpg";
                    if (this.AutoTextureFormat == 0)
                    {
                        TextureFormatString = "jpg";
                    }else if(this.AutoTextureFormat == 1)
                    {
                        TextureFormatString = "tga";
                    }
                    else if(this.AutoTextureFormat == 2)
                    {
                        TextureFormatString = "png";
                    }

                    process.StartInfo.Arguments = " " + ddsFilePath + " -ft " + TextureFormatString  + " -o " + outputDirectory;
                    process.StartInfo.UseShellExecute = false;  // 不使用操作系统的shell启动程序
                    process.StartInfo.RedirectStandardOutput = false;  // 重定向标准输出
                    process.StartInfo.RedirectStandardError = false;   // 重定向标准错误输出
                    process.StartInfo.CreateNoWindow = true;  // 不创建新窗口
                    process.Start();
                    process.WaitForExit();
                }
            }
        }


        private void cleanLogFiles()
        {
            string logsPath = basePath + "Logs";

            if (!Directory.Exists(logsPath))
            {
                return;
            }

            //移除log文件
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

            if (logFileList.Count == 0)
            {
                return;
            }

            logFileList.Sort();
            int n = this.LogFileReserveNumber; // 你想移除的元素数量
            if (n > 0 && logFileList.Count > n)
            {
                logFileList.RemoveRange(logFileList.Count - n, n);

            }
            else if (logFileList.Count <= n)
            {
                // 如果 n 大于等于列表的长度，就清空整个列表
                logFileList.Clear();
            }
            if (logFileList.Count > 0)
            {
                foreach (string logfileName in logFileList)
                {
                    File.Delete(logsPath + "\\" + logfileName);

                    //移动到回收站有时无法生效
                    //FileSystem.DeleteFile();
                    //Directory.Delete(latestFrameAnalysisFolder, true);
                }
            }
        }


        private void cleanFrameAnalysisFiles()
        {
            if (!Directory.Exists(Path_LoaderFolder))
            {
                return;
            }

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

            if (frameAnalysisFileList.Count == 0)
            {
                return;
            }

            //Get FA numbers to reserve
            frameAnalysisFileList.Sort();

            int n = this.FrameAnalysisFolderReserveNumber; // 你想移除的元素数量
            if (n > 0 && frameAnalysisFileList.Count > n)
            {
                frameAnalysisFileList.RemoveRange(frameAnalysisFileList.Count - n, n);

            }
            else if (frameAnalysisFileList.Count <= n)
            {
                // 如果 n 大于等于列表的长度，就清空整个列表
                frameAnalysisFileList.Clear();
            }
            if (frameAnalysisFileList.Count > 0)
            {
                foreach (string directoryName in frameAnalysisFileList)
                {
                    string latestFrameAnalysisFolder = Path_LoaderFolder.Replace("/", "\\") + directoryName;
                    //FileSystem.DeleteDirectory(latestFrameAnalysisFolder, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                    Directory.Delete(latestFrameAnalysisFolder, true);
                }
            }

        }


        private void DirectoryCopy(string sourceDir, string targetDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDir}");
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(targetDir);

            // 复制目录下的文件
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(targetDir, file.Name);
                file.CopyTo(tempPath, false);
            }

            // 递归复制子目录
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(targetDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }


        void ShowMessageBox(string EnglishTip, string ChineseTip)
        {
            MessageBox.Show(ChineseTip);
        }


        List<string> ReadGameFolderNames()
        {
            //填充游戏名称列表
            string[] game_folders = Directory.GetDirectories("Games\\");
            //转换提取出目录名称
            List<string> game_folder_names = new List<string>();
            foreach (string game_folder_path in game_folders)
            {
                string folder_name = Path.GetFileName(game_folder_path);
                game_folder_names.Add(folder_name);
            }
            return game_folder_names;
        }

        bool CopyFileIfTargetNotExists(string SrcFilePath, string TargetFilePath)
        {
            if (File.Exists(TargetFilePath))
            {
                return true;
            }
            else
            {
                if (SrcFilePath != TargetFilePath )
                {
                    File.Copy(SrcFilePath, TargetFilePath, true);
                }
                return false;
            }
        }


        void Initialize3DmigotoFiles()
        {
            if (!Directory.Exists("3Dmigoto-GameMod-Fork\\"))
            {
                MessageBox.Show("在当前DBMT目录下未找到3Dmigoto-GameMod-Fork目录，无法初始化3Dmigoto，请检查您是否正确安装了DBMT");
                return;
            }

            string[] GameDirectoryList = Directory.GetDirectories("Games\\");
            foreach (string GamePath in GameDirectoryList)
            {
                string GameName = Path.GetFileName(GamePath);

                //初始化d3d11.dll
                bool d3d11dll_exists = CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\ReleaseX64Dev\\d3d11.dll", basePath + "Games\\" + GameName + "\\3Dmigoto\\d3d11.dll");

                //if (d3d11dll_exists)
                //{
                //    MessageBox.Show("d3d11.dll已存在");
                //}

                //如果没有d3d11.dll说明是第一次初始化，则复制全部内容过去
                if (!d3d11dll_exists)
                {
                    CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\3Dmigoto Loader.exe", basePath + "Games\\" + GameName + "\\3Dmigoto\\3Dmigoto Loader.exe");
                    CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\3Dmigoto Loader.py", basePath + "Games\\" + GameName + "\\3Dmigoto\\3Dmigoto Loader.py");
                    CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\3Dmigoto Loader-ByPassACE.exe", basePath + "Games\\" + GameName + "\\3Dmigoto\\3Dmigoto Loader-ByPassACE.exe");
                    CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\CreateSuspendedProcess.exe", basePath + "Games\\" + GameName + "\\3Dmigoto\\CreateSuspendedProcess.exe");
                    CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\d3dcompiler_46.dll", basePath + "Games\\" + GameName + "\\3Dmigoto\\d3dcompiler_46.dll");
                    CopyFileIfTargetNotExists("3Dmigoto-GameMod-Fork\\nvapi64.dll", basePath + "Games\\" + GameName + "\\3Dmigoto\\nvapi64.dll");
                }
            }
        }


        void InitializeGUI()
        {
            //检查当前程序是否为位于中文路径下
            if (ContainsChinese(basePath))
            {
                ShowMessageBox("DBMT can't be put in a path that contains Chinese, please put DBMT in pure english path!", "DBMT所在路径不能含有中文，请重新将DBMT放置到纯英文路径！");
                Application.Exit();
            }

            //检查DBMT是否存在
            if (!File.Exists(basePath + "Plugins\\" + MMT_EXE_FileName))
            {
                ShowMessageBox("Can't find " + basePath + MMT_EXE_FileName + ",please put it under this program's Plugins folder.", "未找到" + basePath + MMT_EXE_FileName + ",请将其放在本程序Plugins目录下，即将退出程序。");
                Application.Exit();
            }

            //如果DBMT存在，则开始正常初始化。
            //初始化Logs和Backups目录
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }
            if (!Directory.Exists("Backups"))
            {
                Directory.CreateDirectory("Backups");
            }

            //这俩插件必须故意露出来，吸引别人购买
            ////检查DBMT-Reverse是否存在
            //if (File.Exists(basePath + "Plugins\\DBMT-Reverse.vmp.exe"))
            //{
            //    Menu_Plugins_ToolStripMenuItem.Visible = true;
            //    Menu_ModReverse_ToolStripMenuItem.Visible = true;
            //}
            ////检查DBMT-Encryptor是否存在
            //if (File.Exists(basePath + "Plugins\\DBMT-Encryptor.vmp.exe"))
            //{
            //    Menu_Plugins_ToolStripMenuItem.Visible = true;
            //    Menu_ModEncryption_ToolStripMenuItem.Visible = true;
            //}
            Menu_Plugins_ToolStripMenuItem.Visible = true;
            Menu_ModReverse_ToolStripMenuItem.Visible = true;
            Menu_ModEncryption_ToolStripMenuItem.Visible = true;


            //检查DBMT-Protect是否存在再决定是否设置完整布局界面
            if (!File.Exists(basePath + "Plugins\\DBMT-Protect.vmp.exe"))
            {
                this.Width = 564;
                this.Height = 251;
            }
            else
            {
                this.Width = 1150;
                this.Height = 517;
            }

            //设置窗口大小固定防止用户看到隐藏界面
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //动态读取游戏列表
            List<string> game_folder_names = ReadGameFolderNames();
            Menu_GameName_toolStripComboBox.Items.Clear();
            Menu_GameName_toolStripComboBox.Items.AddRange(game_folder_names.ToArray());

            ReadPreferenceSetting();

            //开启时默认切换到Dev模式
            SwitchCurrentMode("Dev");

            //读取游戏类型和DrawIB列表
            readConfig(Path_MainConfig);

            //更新一下ShaderCheck列表
            updateShaderCheckList();

            //读取上一次使用的ACL文件夹配置
            ReadACLConfig();

            

            //初始化3Dmigoto相关文件
            Initialize3DmigotoFiles();

            //初始化完毕之后再决定是否展示对应的注入器。
            ShowRunMenu();
        }




        public bool runCommand(string arguments,string targetExe = "")
        {
            //把当前运行的命令保存到RunInput.json
            string json = File.ReadAllText(this.Path_RunInputJson); // 读取文件内容
            JObject runInputJson = JObject.Parse(json);
            runInputJson["RunCommand"] = arguments;
            string runInputJsonStr = runInputJson.ToString(Formatting.Indented);
            File.WriteAllText(this.Path_RunInputJson, runInputJsonStr);

            //运行merge前需要保存配置
            if (arguments == "merge" || arguments == "mergeReverse")
            {
                bool saveResult = saveConfig();
                if (!saveResult)
                {
                    ShowMessageBox("Auto save before run failed, please check your config.", "运行前自动保存配置失败！请检查您的配置！");
                    //MessageBox.Show("运行前自动保存配置失败！请检查您的配置！");
                    return false;
                }
            }

            //运行程序前，设置RunResult.json填充默认值，结果由MMT.exe进行纠正。
            JObject jsonObject = new JObject();
            jsonObject["result"] = "Unknown Error!";
            File.WriteAllText(this.Path_RunResultJson, jsonObject.ToString());

            // 创建一个 Process 对象
            Process process = new Process();
            // 设置要执行的程序和参数，主要是路径这里我们这样可以支持专业版与基础版区分，以及其他插件的添加
            if (targetExe == "")
            {
                if (CurrentGameName == "Naraka" )
                {
                    process.StartInfo.FileName = basePath + "Plugins\\" + "MMT-Naraka.exe";
                }
                else if (CurrentGameName == "Mecha")
                {
                    process.StartInfo.FileName = basePath + "Plugins\\" + "MMT-Mecha.exe";
                }
                else if (CurrentGameName == "LiarsBar")
                {
                    process.StartInfo.FileName = basePath + "Plugins\\" + "DBMT-LiarsBar.exe";
                }
                else
                {
                    process.StartInfo.FileName = basePath + "Plugins\\" + MMT_EXE_FileName;
                }
            }
            else
            {
                process.StartInfo.FileName = basePath + "Plugins\\" + targetExe;
            }
            //运行前必须检查路径
            if (!File.Exists(process.StartInfo.FileName))
            {
                ShowMessageBox("Current run path didn't exsits: " + process.StartInfo.FileName, "当前要执行的插件不存在: " + process.StartInfo.FileName + "\n请联系NicoMico赞助获取此插件。");
                //MessageBox.Show("当前要执行的路径不存在: "+ process.StartInfo.FileName);
                return false;
            }
            
            process.StartInfo.Arguments = arguments;  // 可选，如果该程序接受命令行参数
            //MessageBox.Show("当前运行参数： " + arguments);

            // 配置进程启动信息
            process.StartInfo.UseShellExecute = false;  // 不使用操作系统的shell启动程序
            process.StartInfo.RedirectStandardOutput = false;  // 重定向标准输出
            process.StartInfo.RedirectStandardError = false;   // 重定向标准错误输出
            process.StartInfo.CreateNoWindow = true;  // 不创建新窗口
             

            // 启动程序
            process.Start();
            process.WaitForExit();
            if (arguments == "merge" )
            {
                setDataGridViewStatus("等待生成");
            }

            string runResultJson = File.ReadAllText(Path_RunResultJson);
            JObject resultJsonObject = JObject.Parse(runResultJson);
            string runResult = (string)resultJsonObject["result"];

            if (runResult != "success")
            {
                ShowMessageBox("Run result: " + runResult + ". \n1.Please check your config.\n2.Please check log for more information.\n3.Please ask NicoMico for help, remember to send him the latest log file.\n4.Ask @Developer in ShaderFreedom for help.\n5.Read the source code of DBMT and try analyse the reason for Error with latest log file.",
                    "运行结果: " + runResult + ". \n\n很遗憾运行失败了，参考运行结果和运行日志改变策略再试一次吧。\n\n1.请检查您的配置是否正确.\n2.请查看日志获取更多细节信息.\n3.请检查您是否使用的是最新版本，新版本可能已修复此问题\n4.请联系NicoMico寻求帮助或反馈BUG, 别忘了把最新的FrameAnalysis文件夹、提取用的IB、运行的日志文件也打包发送给他.\n\n点击确认为后您打开本次运行日志。");
                //MessageBox.Show("Run result: " + runResult + ". \n1.Please check your config.\n2.Please check log for more information.\n3.Please ask NicoMico for help.");
                Menu_File_OpenLatestLogFile();
                return false;
            }
            else
            {
                if (arguments == "merge" || arguments == "mergeReverse")
                {
                    convertAllDdsToTgaInOutputFolder();

                    if (this.ConvertDedupedTextures)
                    {
                        ConvertDedupedTexturesToTargetFormat();
                    }
                }
               
                ShowMessageBox("Run result: " + runResult, "😊恭喜恭喜！运行成功！");
                //MessageBox.Show("Run result: " + runResult);
            }

            return true;

        }

        public void setDataGridViewStatus(string value)
        {
            
            foreach (DataGridViewRow row in DataGridView_BasicIBList.Rows)
            {
                if (!row.IsNewRow && row.Cells.Count > 2)
                {
                    row.Cells[2].Value = value;
                }
            }
        }

        public void addLineToDataGridDrawIBList(string drawIB, string buttonValue,string status)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell textBoxCellDrawIB = new DataGridViewTextBoxCell();
            textBoxCellDrawIB.Value = drawIB;
            row.Cells.Add(textBoxCellDrawIB);

            DataGridViewButtonCell textBoxCellButton = new DataGridViewButtonCell();
            textBoxCellButton.Value = buttonValue;
            row.Cells.Add(textBoxCellButton);

            DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();
            statusCell.Value = status;
            row.Cells.Add(statusCell);

            DataGridView_BasicIBList.Rows.Add(row);
        }

        void ShowRunMenu()
        {
            //依次判断三个加载器是否存在，来控制是否显示加载器的
            string LoaderPyPath = this.Path_LoaderFolder + "3Dmigoto Loader.py";
            if (File.Exists(LoaderPyPath))
            {
                Menu_Run_run3DmigotoLoaderpyToolStripMenuItem.Visible = true;
            }
            else
            {
                Menu_Run_run3DmigotoLoaderpyToolStripMenuItem.Visible = false;
            }
            string LoaderExePath = this.Path_LoaderFolder + "3Dmigoto Loader.exe";
            if(File.Exists(LoaderExePath))
            {
                Menu_Run_run3DmigotoLoaderexeToolStripMenuItem.Visible = true;
            }
            else
            {
                Menu_Run_run3DmigotoLoaderexeToolStripMenuItem.Visible = false;
            }
            string LoaderByPassACEPath = this.Path_LoaderFolder + "3Dmigoto Loader-ByPassACE.exe";
            if (File.Exists(LoaderByPassACEPath))
            {
                Menu_Run_run3DmigotoLoaderByPassACEexeToolStripMenuItem.Visible = true;
            }
            else
            {
                Menu_Run_run3DmigotoLoaderByPassACEexeToolStripMenuItem.Visible = false;
            }
        }

        private void UpdateTitleName()
        {
            this.Text = DBMT_Title + "  当前模式: " + this.CurrentMode;
        }


        private void setCurrentGame(string gameName)
        {
            //设置当前游戏名称
            this.CurrentGameName = gameName;

            //先清空dataGridView，切换游戏类型后重新读取
            DataGridView_BasicIBList.Rows.Clear();

            //同时也要设置一下配置文件路径
            this.Path_Game_ConfigJson = "Games\\" + CurrentGameName + "\\Config.json";
            this.Path_Game_VSCheck_Json = "Games\\" + CurrentGameName + "\\VSCheck.json";
            //读取configs\\游戏名Config.json，然后判断是否含有此drawIB来决定按钮的

            if (File.Exists(this.Path_Game_ConfigJson) )
            {
                //切换到对应配置
                string jsonData = File.ReadAllText(this.Path_Game_ConfigJson);
                JArray jsonArray = JArray.Parse(jsonData);

                foreach (JObject obj in jsonArray)
                {
                    string readDrawIB = (string)obj["DrawIB"];
                    addLineToDataGridDrawIBList(readDrawIB, "已配置", "");
                }
            }

            this.Path_LoaderFolder = "Games\\" + this.CurrentGameName + "\\3Dmigoto\\";
            this.Path_D3DXINI = this.Path_LoaderFolder + "d3dx.ini";
            this.Path_OutputFolder = this.Path_LoaderFolder + "Mods\\output\\";

            //最后把当前游戏名称和类型保存到配置文件，做到和Blender联动。
            saveCurrentGameNameAndGameType();

            //更新一下展示的加载器
            ShowRunMenu();

            //更新窗口名称
            UpdateTitleName();
        }
        

        private void initializeFolders()
        {
            
            //关于是否需要删除OutputFolder并重新生成
            if (File.Exists(this.Path_Game_SettingJson))
            {
                string json = File.ReadAllText(this.Path_Game_SettingJson); // 读取文件内容
                JObject jsonObject = JObject.Parse(json);
                if (jsonObject.ContainsKey(this.CurrentGameName))
                {
                    bool deleteOutputFolder = (bool)jsonObject[this.CurrentGameName]["DeleteOutputFolder"];
                    string outputFolder = (string)jsonObject[this.CurrentGameName]["OutputFolder"];
                    if (deleteOutputFolder)
                    {
                        if (Directory.Exists(outputFolder))
                        {
                            DialogResult result = DialogResult.None;

                            result = MessageBox.Show("您设置了在融合模型文件前删除OutputFolder，此操作非常危险，请再次检查防止误删除文件，您的OutputFolder路径为：" + outputFolder, "是否确认删除？", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            

                            // 根据用户的选择返回结果
                            if (result == DialogResult.Yes)
                            {

                                //已证实移动到回收站在部分情况下并不生效
                                //FileSystem.DeleteDirectory(outputFolder, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                                Directory.Delete(outputFolder,true);
                                Directory.CreateDirectory(outputFolder);
                            }

                        }
                        else
                        {
                            Directory.CreateDirectory(outputFolder);
                        }
                    }
                }
                
            }
        }



        private void backupFiles()
        {
            if (this.BackUpFiles)
            {
                //创建用于备份的文件夹
                if (!Directory.Exists("Backups"))
                {
                    Directory.CreateDirectory("Backups");
                }

                //确定备份文件夹的名称
                DateTime now = DateTime.Now;
                // 使用特定的格式字符串将日期和时间格式化为文件名字符串
                string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");
                string targetFolder = "Backups\\" + formattedDateTime;
                Directory.CreateDirectory(targetFolder);

                // 创建每个drawIB的备份文件夹
                string[] draw_ib_directories = Directory.GetDirectories(this.Path_OutputFolder);
                foreach (string directoryPath in draw_ib_directories)
                {
                    string directoryName = Path.GetFileName(directoryPath);
                    string draw_ib_backup_directory = targetFolder + "/" + directoryName;
                    Directory.CreateDirectory(draw_ib_backup_directory);

                    //复制所有文件
                    DirectoryCopy(directoryPath, draw_ib_backup_directory, false);

                    //TODO 备份PsHashTextures
                    string ps_hash_textures_folder_path = directoryPath + "/" + "PsHashTextures";
                    if (Directory.Exists(ps_hash_textures_folder_path))
                    {
                        string target_ps_hash_textures_backup_path = draw_ib_backup_directory + "/" + "PsHashTextures";
                        Directory.CreateDirectory(target_ps_hash_textures_backup_path);
                        DirectoryCopy(ps_hash_textures_folder_path, target_ps_hash_textures_backup_path, false);
                    }

                }
                //备份OutputFolder下面的纯文件
                DirectoryCopy(this.Path_OutputFolder, targetFolder, false);

                // 创建Mod的备份文件夹
                string output_mod_folder_name = now.ToString("yyyy_MM_dd");
                string output_mod_folder_path = this.Path_OutputFolder + output_mod_folder_name;
                string backup_mod_folder_path = targetFolder + "/" + output_mod_folder_name;
                Directory.CreateDirectory(backup_mod_folder_path);
                if (Directory.Exists(output_mod_folder_path))
                {
                    DirectoryCopy(output_mod_folder_path, backup_mod_folder_path, true);
                }

            }

        }


        private void start3Dmigoto()
        {
            string migotoLoaderPath = basePath + "3Dmigoto\\" + CurrentGameName + "\\3Dmigoto Loader.exe";

            if (!File.Exists(migotoLoaderPath))
            {
                ShowMessageBox("Can't find " + migotoLoaderPath + ", please check if your config.", "无法找到" + migotoLoaderPath + "，请检查你的配置是否正确");
                //MessageBox.Show("Can't find " + migotoLoaderPath  + ", please check if your config.");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo(migotoLoaderPath);
            string workingDirectory = Path.GetDirectoryName(migotoLoaderPath);
            startInfo.WorkingDirectory = workingDirectory;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        void ReadPreferenceSetting()
        {
            //读取并设置一些配置变量，用于传递给每个DrawIB的ConfigMod窗口
            if (File.Exists(this.Path_Game_SettingJson))
            {
                string json = File.ReadAllText(this.Path_Game_SettingJson); // 读取文件内容
                JObject jsonObject = JObject.Parse(json);
                this.AutoCleanFrameAnalysisFolder = (bool)jsonObject["AutoCleanFrameAnalysisFolder"];
                this.FrameAnalysisFolderReserveNumber = (int)jsonObject["FrameAnalysisFolderReserveNumber"];
                this.AutoCleanLogFile = (bool)jsonObject["AutoCleanLogFile"];
                this.LogFileReserveNumber = (int)jsonObject["LogFileReserveNumber"];

                this.DeleteOutputFolder = (bool)jsonObject["DeleteOutputFolder"];
                this.BackUpFiles = (bool)jsonObject["BackUp"];

                if (jsonObject.ContainsKey("AutoTextureOnlyConvertDiffuseMap"))
                {
                    this.AutoTextureOnlyConvertDiffuseMap = (bool)jsonObject["AutoTextureOnlyConvertDiffuseMap"];
                }

                if (jsonObject.ContainsKey("MMTWindowTopMost"))
                {
                    this.MMTWindowTopMost = (bool)jsonObject["MMTWindowTopMost"];
                    //设置是否置顶窗口
                    this.TopMost = this.MMTWindowTopMost;
                }

                if (jsonObject.ContainsKey("OpenModOutputFolderAfterGenerateMod"))
                {
                    this.OpenModOutputFolderAfterGenerateMod = (bool)jsonObject["OpenModOutputFolderAfterGenerateMod"];
                }

                //AutoTextureFormat
                if (jsonObject.ContainsKey("AutoTextureFormat"))
                {
                    this.AutoTextureFormat = (int)jsonObject["AutoTextureFormat"];
                }

                //ConvertDedupedTextures
                if (jsonObject.ContainsKey("ConvertDedupedTextures"))
                {
                    this.ConvertDedupedTextures = (bool)jsonObject["ConvertDedupedTextures"];
                }
            }

        }
    }
}
