using DBMT_GUI;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace NMBT_GUI
{
    public partial class Main : Form
    {
        //当前选择的游戏名称
        private string CurrentGameName = "";

        //当前工作模式，分为Dev和Play，默认为Dev
        private string CurrentMode = "Dev";

        //程序名称
        private string DBMT_Title = "DirectX Buffer Mod Tool  当前版本:V1.0.4.2 ";

        //由C++开发的核心算法进程
        private string MMT_EXE_FileName = "DBMT.exe";

        //当前程序运行所在位置的路径,注意这里已经包含了结尾的\\
        private string basePath = AppDomain.CurrentDomain.BaseDirectory.ToString();
        
        private string Path_MainConfig = "Configs\\Main.json";
        private string Path_RunResultJson = "Configs\\RunResult.json";
        private string Path_RunInputJson = "Configs\\RunInput.json";
        private string Path_Game_SettingJson = "Configs\\Setting.json";

        //Protect专用
        private string Path_DeviceKeySetting =  "Configs\\DeviceKeySetting.json";
        //private string Path_ArmorSetting = "Configs\\ArmorSetting.json";
        //private string Path_ACLSettingJson = "Configs\\ACLSetting.json";
        private string Path_ACLFolderJson = "Configs\\ACLFolder.json";

        //运行后程序动态生成
        private string Path_Game_ConfigJson = "";
        private string Path_Game_VSCheck_Json = "";
        private string Path_OutputFolder = "";
        private string Path_LoaderFolder = "";
        private string Path_D3DXINI = "";

        //首选项设置
        private bool AutoCleanFrameAnalysisFolder = false;
        private int FrameAnalysisFolderReserveNumber = 0;
        private bool AutoCleanLogFile = false;
        private int LogFileReserveNumber = 0;
        private bool DeleteOutputFolder;
        private bool BackUpFiles;
        private bool AutoTextureOnlyConvertDiffuseMap = true;
        private bool MMTWindowTopMost = false;
        private bool OpenModOutputFolderAfterGenerateMod = false;

        private int AutoTextureFormat = 0;
        private bool ConvertDedupedTextures = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void DataGridViewIBList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                //获取drawIB的值，先校验DrawIB和游戏类型是否已设置
                object draw_ib_object = DataGridView_BasicIBList.Rows[e.RowIndex].Cells[0].Value;
                if (draw_ib_object == null)
                {
                    ShowMessageBox("Please fill the DrawIB", "请填写用于绘制的IB的哈希值");
                    //MessageBox.Show("Please fill the DrawIB");
                    return;
                }
                string draw_ib = draw_ib_object.ToString();
                if (string.IsNullOrEmpty(draw_ib))
                {
                    ShowMessageBox("Please fill the DrawIB", "请填写用于绘制的IB的哈希值");
                    //MessageBox.Show("Please fill the DrawIB");
                    return;
                }
                if (CurrentGameName == "")
                {
                    ShowMessageBox("Please choose your work game.", "请选择你当前工作的游戏");
                    //MessageBox.Show("Please choose your work game.");
                    return;
                }

                //设置好DrawIB和游戏类型才能执行后面的选项
                //先调出配置界面
                ConfigMod anotherForm = new ConfigMod(draw_ib, CurrentGameName);
                anotherForm.Show();

                //然后根据是否配置完成来显示对应信息
                if (File.Exists(Path_Game_ConfigJson))
                {
                    string jsonData = File.ReadAllText(Path_Game_ConfigJson);
                    JArray jsonArray = JArray.Parse(jsonData);
                    bool find_draw_ib = false;
                    foreach (JObject obj in jsonArray)
                    {
                        string drawIB = (string)obj["DrawIB"];
                        if (draw_ib == drawIB)
                        {
                            find_draw_ib = true;
                            break;
                        }

                    }

                    if (find_draw_ib)
                    {
                        DataGridView_BasicIBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "已配置";
                    }
                    else
                    {
                        DataGridView_BasicIBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "未配置";
                    }

                }

            }
        }


        private void DataGridViewIBList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //如果当前行这个button显示为空，则设置显示为未配置
                if (DataGridView_BasicIBList.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    DataGridViewCell buttonCell = DataGridView_BasicIBList.Rows[e.RowIndex].Cells[1];
                    buttonCell.Value = "未配置";
                }

                //如果当前行的DrawIB显示为空，则设置显示也为空
                if (DataGridView_BasicIBList.Rows[e.RowIndex].Cells[0].Value == null)
                {

                    DataGridViewCell buttonCell = DataGridView_BasicIBList.Rows[e.RowIndex].Cells[1];
                    buttonCell.Value = "";
                }
                else
                {
                    //在Config.json中查找是否有这个DrawIB，如果没有则显示为未配置，和上面差不多
                    string DrawIBValue = DataGridView_BasicIBList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (File.Exists(this.Path_Game_ConfigJson))
                    {
                        string jsonData = File.ReadAllText(this.Path_Game_ConfigJson);
                        JArray jsonArray = JArray.Parse(jsonData);

                        bool findDrawIB = false;
                        foreach (JObject obj in jsonArray)
                        {
                            string drawIB = (string)obj["DrawIB"];
                            if (drawIB == DrawIBValue)
                            {
                                findDrawIB = true;
                                break;
                            }
                        }

                        if (!findDrawIB)
                        {
                            DataGridViewCell buttonCell = DataGridView_BasicIBList.Rows[e.RowIndex].Cells[1];
                            buttonCell.Value = "默认配置";

                            ConfigMod anotherForm = new ConfigMod(DrawIBValue, CurrentGameName);
                            anotherForm.Show();
                            anotherForm.Close();
                        }
                    }
                    else
                    {
                        ConfigMod anotherForm = new ConfigMod(DrawIBValue, CurrentGameName);
                        anotherForm.Show();
                        anotherForm.Close();
                    }
                }

            }
        }

       
        //提取模型
        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preDoBeforeMerge();
            bool command_run_result = runCommand("merge");
            if (command_run_result)
            {
                //打开Output文件夹
                Process.Start(this.Path_OutputFolder);
            }
        }


        //生成模型
        private void splitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand("split");
            backupFiles();
            if (this.OpenModOutputFolderAfterGenerateMod)
            {
                Menu_File_OpenModGenerateFolder();
            }
        }

        private void Menu_BasicMod_InitializeConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView_BasicIBList.Rows.Clear();
            saveConfig();
        }

        private void Menu_BasicMod_SaveConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool saveResult = saveConfig();
            if (saveResult)
            {
                ShowMessageBox("Save Success", "保存成功");
            }
            else
            {
                ShowMessageBox("Save Failed, please check your config", "保存失败，请检查配置");
            }
        }

        private void Menu_File_OpenOutputFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenOutputFolder();
        }

        private void Menu_File_OpenModGenerateFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenModGenerateFolder();
        }

        private void Menu_File_OpenMMTLocationFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(this.basePath);
        }

        private void Menu_File_OpenLogsFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(this.basePath + "Logs\\");
        }


        private void Menu_File_OpenModsFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenModsFolder();
        }

        private void Menu_File_OpenLatestFrameAnalysisFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenLatestFrameAnalysisFolder();
        }

        private void Menu_File_Open3DmigotoFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_Open3DmigotoFolder();
        }

        private void Menu_File_OpenShaderFixesFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenShaderFixesFolder();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AutoCleanFrameAnalysisFolder)
            {
                cleanFrameAnalysisFiles();

            }
            if (AutoCleanLogFile)
            {
                cleanLogFiles();
            }
        }


        private void openLatestLOGFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenLatestLogFile();
        }


        private void Menu_File_OpenBackupsFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(this.basePath + "Backups\\");
        }

        private void Menu_File_OpenConfigsFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(this.basePath + "Configs\\");
        }

       

        private void Menu_File_Open3DmigotosD3dxini_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenD3DXIni();
        }

        private void Menu_GameName_toolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            setCurrentGame(Menu_GameName_toolStripComboBox.Text.ToString());
        }

        private void extractReverseModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Reverse_Lv4_ReverseExtract();
        }

        private void reverseOutfitCompilerCompressedMergedModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReverseIniCommand("ReverseOutfitCompilerLv4");
        }

        private void reverseSingleModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReverseIniCommand("ReverseSingleLv4");
        }

        private void reverseMergedModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReverseIniCommand("ReverseMergedLv4");
        }

        private void Menu_Run_run3DmigotoLoaderexeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_Run_3DmigotoLoaderExe();
        }

        private void Menu_Run_run3DmigotoLoaderByPassACEexeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_Run_3DmigotoLoaderByPassACE();
        }
       
        private void openTypesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenExtractTypesFolder();
        }

        private void Menu_Reverse_reverseLv4MergedNameSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Reverse_Lv4_MergedNameSpace();
        }

        private void Menu_Reverse_reverseLv43DmigotoSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Reverse_Lv4_3DmigotoSimulator();
        }

        private void ShaderCheck_updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool readResult = updateShaderCheckList();
            if (readResult)
            {
                ShowMessageBox("Update Success.", "更新成功");
            }
        }

        private void ShaderCheck_importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_VSCheck_Import();
        }

        private void ShaderCheck_saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool result = Menu_VSCheck_SaveShaderCheckList();
            if (result)
            {
                ShowMessageBox("Save Success", "保存成功");
            }
        }

        private void ShaderCheck_saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_VSCheck_SaveAs();
        }

        private void ShaderCheck_generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_VSCheck_GenerateVSCheck();
        }

        private void Menu_VertexShaderCheck_initializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewShaderCheckList.Rows.Clear();
        }

        private void Menu_VertexShaderCheck_ViewRelations_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_VSCheck_ViewRelations();
        }

        private void Menu_Analysis_VertexShaderCheck_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_Analysis_GenerateShaderCheck();
        }

        private void Menu_Analysis_SkipIB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_Analysis_SkipIB();
        }

        private void Menu_Run_run3DmigotoLoaderpyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_Run_3DmigotoLoaderPython();
        }
        private void Menu_File_OpenLatestFrameAnalysislogtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenLatestFrameAnalysisLogTxtFile();
        }

        private void Menu_File_openDedupedFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_File_OpenDedupedFolder();
        }





   
        private void Menu_DeviceID_GenerateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //把DeviceID写到配置文件里
            JObject jsonObject = new JObject();
            jsonObject["UserName"] = textBoxKeyUserName.Text;
            jsonObject["DeviceID"] = textBoxDeviceID.Text;
            // 将JObject转换为JSON字符串
            string json_string = jsonObject.ToString(Formatting.Indented);
            // 将JSON字符串写入文件
            File.WriteAllText(Path_DeviceKeySetting, json_string);
            runCommand("generateKeyByDeviceID", "DBMT-Protect.vmp.exe");
        }


        private void ACL_UpdateACLtoolStripMenu_Click(object sender, EventArgs e)
        {
            updateACLList();
            ShowMessageBox("Update ACL success.", "更新成功");
        }

        private void ACL_chooseACLFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置默认路径
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog1.SelectedPath;
                string selectedPathWithForwardSlash = selectedPath.Replace("\\", "/");
                toolStripTextBoxACLFolder.Text = selectedPathWithForwardSlash + "/";
            }

            //选完之后进行保存，方便下一次读取
            saveACLFolder();
        }

        private void ACL_toolStripTextBoxACLFolder_TextChanged(object sender, EventArgs e)
        {
            //首先自动补充结尾的反斜杠
            string shaderCheckLocation = toolStripTextBoxACLFolder.Text;
            if (!shaderCheckLocation.EndsWith("/"))
            {
                shaderCheckLocation = shaderCheckLocation + "/";
            }

            //其次如果路径含有正斜杠，则替换为反斜杠
            shaderCheckLocation = shaderCheckLocation.Replace("\\", "/");
            toolStripTextBoxACLFolder.Text = shaderCheckLocation;
        }


        private void Menu_ACL_AddLock_ACPT_PRO_V2_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run_DBMT_PROTECT("ACPTPRO_Batch_V2");
        }

        private void Menu_Encryption_Obfuscate_Play_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obfuscate("Play");
        }

    
        private void Menu_ACL_AddLock_ACPT_PRO_V3_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run_DBMT_PROTECT("ACPTPRO_Batch_V3");
        }

        private void Menu_Documents_ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.yuque.com/airde/lx53p6?# 《3Dmigoto 知识库》");
        }

        private void Menu_Sponser_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://mbd.pub/o/NicoMico");
        }


        /// <summary>
        /// 指定文件夹下面的所有内容copy到目标文件夹下面
        /// 拷贝CodeFilePath目录下的所有文件到指定目录/build/android-ndk-r20b/jni下
        /// </summary>
        /// <param name="srcPath">原始路径</param>
        /// <param name="aimPath">目标文件夹</param>
        /// <returns></returns>
        private static bool CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                {
                    aimPath += Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建
                if (!Directory.Exists(aimPath))
                {
                    Directory.CreateDirectory(aimPath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理,如果存在这个目录就递归Copy该目录下面的文件
                    if (Directory.Exists(file))
                    {
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    }
                    // 否则直接Copy文件
                    else
                    {
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                string ErrorMessage = e.ToString();
                return false;
            }
        }

        private void Menu_UpdateFromOldVesion_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog1.SelectedPath;

                if (ContainsChinese(selectedPath))
                {
                    ShowMessageBox("Target Path Can't Contains Chinese.", "目标路径中不能含有中文字符");
                    return;
                }

                //拼接处Games目录
                string GamesDirectory = selectedPath + "\\Games\\";

                if (!Directory.Exists(GamesDirectory))
                {
                    MessageBox.Show("未找到Games目录，请选择正确的DBMT路径");
                    return;
                }

                //判断DBMT-GUI.exe是否存在
                if (!File.Exists(selectedPath + "\\DBMT-GUI.exe"))
                {
                    MessageBox.Show("未找到DBMT-GUI.exe，请选择正确的DBMT路径");
                    return;
                }


                //MessageBox.Show(GamesDirectory);
                string[] GameDirectoryList = Directory.GetDirectories(GamesDirectory);

                int ImportCount = 0;
                foreach (string GamePath in GameDirectoryList)
                {
                    string GameName = Path.GetFileName(GamePath);

                    string SrcFilePath = GamePath + "\\3Dmigoto\\d3dx.ini";
                    string TargetFilePath = basePath + "Games\\" + GameName + "\\3Dmigoto\\d3dx.ini";

                    //移动Mods目录
                    string SourceModsFolderPath = GamePath + "\\3Dmigoto\\Mods\\";
                    string TargetModsFolderPath = basePath + "Games\\" + GameName + "\\3Dmigoto\\Mods\\";
                    CopyDir(SourceModsFolderPath, TargetModsFolderPath);


                    if (SrcFilePath != TargetFilePath && File.Exists(TargetFilePath))
                    {
                        File.Copy(SrcFilePath, TargetFilePath, true);
                        ImportCount++;
                    }
                }
                //复制旧版本配置
                File.Copy(selectedPath + "\\Configs\\Setting.json", basePath + "Configs\\Setting.json", true);

                MessageBox.Show("导入旧版本3Dmigoto配置成功，共导入" + ImportCount.ToString() + "个有效配置。");

            }


        }

        private void Menu_ACL_AddLock_ACPT_PRO_V4_Buffer和ini文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run_DBMT_PROTECT("ACPTPRO_Batch_V4");
        }

        private void Menu_ACL_AddLock_ACPT_PRO_V5_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run_DBMT_PROTECT("ACPTPRO_Batch_V5");
        }

        private void Menu_Encryption_BufferFiles_V4_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Encryption_EncryptBufferFiles("encrypt_buffer_acptpro_V4");
        }

        private void Menu_Encryption_IniFile_V5_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Encryption_RunCommand_OpenIni("encrypt_ini_acptpro_V5");
        }

        private void Menu_ModEncryption_All_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //混淆并返回新的ini文件的路径
            string NewModInIPath = obfuscate("Play");
            if(NewModInIPath == "")
            {
                return;
            }

            //调用加密Buffer并加密ini文件
            DBMT_Encryption_RunCommand("encrypt_buffer_ini_v5", NewModInIPath);
        }

        private void Menu_ModEncryption_Obfuscate_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obfuscate("Play");
        }

        private void Menu_ModEncryption_Buffer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Encryption_EncryptBufferFiles("encrypt_buffer_acptpro_V4");
        }

        private void Menu_ModEncryption_Ini_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Encryption_RunCommand_OpenIni("encrypt_ini_acptpro_V5");
        }

        private void Menu_ModEncryption_BufferIni_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Encryption_RunCommand_OpenIni("encrypt_buffer_ini_v5");
        }


        bool SwitchCurrentMode(string ModeString)
        {
            if (!Directory.Exists("3Dmigoto-GameMod-Fork\\"))
            {
                MessageBox.Show("在当前DBMT目录下未找到3Dmigoto-GameMod-Fork目录，无法进行模式切换，请检查您是否正确安装了DBMT");
                return false;
            }


            //切换到Dev模式
            this.CurrentMode = ModeString;

            string[] GameDirectoryList = Directory.GetDirectories("Games\\");

            foreach (string GamePath in GameDirectoryList)
            {
                string GameName = Path.GetFileName(GamePath);
                //MessageBox.Show(GameName);
                string SrcFilePath = "3Dmigoto-GameMod-Fork\\ReleaseX64" + this.CurrentMode + "\\d3d11.dll";
                string TargetFilePath = basePath + "Games\\" + GameName + "\\3Dmigoto\\d3d11.dll";
                //MessageBox.Show(TargetFilePath);

                if (SrcFilePath != TargetFilePath && File.Exists(TargetFilePath))
                {
                    try
                    {
                        File.Copy(SrcFilePath, TargetFilePath, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("转换为" + this.CurrentMode + "模式失败，请检查是否有进程占用了d3d11.dll文件(比如注入了d3d11.dll的游戏进程正在运行或者退出游戏后某米游启动器后台偷偷运行仍然占用d3d11.dll)，被占用的文件路径：" + TargetFilePath);
                        return false;
                    }
                }
            }

            UpdateTitleName();
            return true;
        }

        private void Menu_Mode_Dev_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool SwitchResult = SwitchCurrentMode("Dev");
            if (SwitchResult)
            {
                MessageBox.Show("已切换到 " + this.CurrentMode + " 模式");
            }
        }

        private void Menu_Mode_Play_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool SwitchResult = SwitchCurrentMode("Play");
            if (SwitchResult)
            {
                MessageBox.Show("已切换到 " + this.CurrentMode + " 模式");
            }
        }

        private void Menu_ModReverse_ReverseExtract_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBMT_Reverse_Lv4_ReverseExtract();
        }

        private void Menu_ModReverse_ReverseSingle_ModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ModIniFilePath = RunReverseIniCommand("ReverseSingleLv5");

            string ModFolderPath = Path.GetDirectoryName(ModIniFilePath);
            string ModFolderName = Path.GetFileName(ModFolderPath);
            string ModFolderParentPath = Path.GetDirectoryName(ModFolderPath);
            string ModReverseFolderPath = ModFolderParentPath + "\\" + ModFolderName + "-Reverse\\";
            string TargetTexturesFolderPath = ModReverseFolderPath + "Textures\\";

            Directory.CreateDirectory(TargetTexturesFolderPath);
            ConvertAllTextureFilesToTargetFolder(ModFolderPath, TargetTexturesFolderPath);
            Process.Start(ModReverseFolderPath);
        }

        private void Menu_ModReverse_ReverseToggle_ModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReverseIniCommand("ReverseMergedLv5");
        }

        private void Menu_ModReverse_OutfitCompilerToggle_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReverseIniCommand("ReverseOutfitCompilerLv4");
        }

        private void Menu_Setting_Preferences_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigGame configBasic = new ConfigGame();
            configBasic.ShowDialog();
            setCurrentGame(this.CurrentGameName);
            ReadPreferenceSetting();
        }

        private void Menu_Setting_D3DXINI_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MigotoConfig migorod3dxConfig = new MigotoConfig();
            migorod3dxConfig.ShowDialog();
        }
    }
}
