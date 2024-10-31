using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMBT_GUI
{
    partial class Main
    {

        public void addLineToDataGridACL(string name)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell textBoxCellName = new DataGridViewTextBoxCell();
            textBoxCellName.Value = name;
            row.Cells.Add(textBoxCellName);

            dataGridViewACL.Rows.Add(row);
        }
        void updateACLList()
        {
            dataGridViewACL.Rows.Clear();
            //遍历ACL 文件夹下面的ini文件

            string directoryPath = toolStripTextBoxACLFolder.Text; // 替换为指定目录的路径

            // 获取目录中以".ini"结尾的所有文件
            string[] iniFiles = Directory.GetFiles(directoryPath, "*.key");

            // 遍历文件并进行处理
            foreach (string file in iniFiles)
            {
                addLineToDataGridACL(file);
            }
        }

        void ReadACLConfig()
        {
            //读取配置文件中的路径
            if (File.Exists(this.Path_ACLFolderJson))
            {
                string json = File.ReadAllText(this.Path_ACLFolderJson); // 读取文件内容
                JObject aclObject = JObject.Parse(json);
                string readPath = (string)aclObject["ACLFolder"];

                //转换为/并设置
                string selectedPathWithForwardSlash = readPath.Replace("\\", "/");
                toolStripTextBoxACLFolder.Text = selectedPathWithForwardSlash;

                //如果结尾没/则添加/防止报错
                if (!toolStripTextBoxACLFolder.Text.EndsWith("/"))
                {
                    toolStripTextBoxACLFolder.Text = selectedPathWithForwardSlash + "/";
                }
             
                if (Directory.Exists(readPath))
                {
                    updateACLList();
                }
            }
        }

        void saveACLFolder()
        {
            //获取游戏类型
            JObject gameObject = new JObject();
            gameObject["ACLFolder"] = toolStripTextBoxACLFolder.Text;
            // 将JObject转换为JSON字符串
            string json_string = gameObject.ToString(Formatting.Indented);

            // 将JSON字符串写入文件
            File.WriteAllText(this.Path_ACLFolderJson, json_string);
        }

        public bool saveBufferConfig(string targetACLFile, string savePath = "Configs\\ACLSetting.json")
        {
            JObject jsonObject = new JObject();
            jsonObject["targetACLFile"] = targetACLFile;

            string json_string = jsonObject.ToString(Formatting.Indented);
            File.WriteAllText(savePath, json_string);

            return true;
        }


        public bool saveACLConfig(string targetACLFile, string savePath = "Configs\\ACLSetting.json")
        {

            JObject jsonObject = new JObject();

            jsonObject["targetACLFile"] = targetACLFile;

            int validCount = 0;
            List<string> accessControlNameList = new List<string>();
            foreach (DataGridViewRow row in dataGridViewACL.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    string name = row.Cells[0].Value.ToString();
                    accessControlNameList.Add(name);
                    validCount++;
                }
            }
            if (validCount == 0)
            {
                MessageBox.Show("无法使用空的权限控制列表配置");
                return false;
            }
            jsonObject["AccessControlList"] = JToken.FromObject(accessControlNameList);
            // 将JObject转换为JSON字符串
            string json_string = jsonObject.ToString(Formatting.Indented);
            // 将JSON字符串写入文件
            File.WriteAllText(savePath, json_string);

            return true;
        }


        string obfuscate(string obfusVersion = "Dev")
        {
            openFileDialog1.Filter = "INI Files (*.ini)|*.ini";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            string readIniPath = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                readIniPath = openFileDialog1.FileName;

                if (ContainsChinese(readIniPath))
                {
                    ShowMessageBox("Target Path Can't Contains Chinese.", "目标路径中不能含有中文字符");
                    return "";
                }
            }

            if (string.IsNullOrEmpty(readIniPath))
            {
                MessageBox.Show("Please select a correct ini file.");
                return "";
            }
            string readDirectoryPath = Path.GetDirectoryName(readIniPath);

            //Read every line and obfuscate every Resource section.
            //need a dict to store the old filename and the new filename.
            string[] readIniLines = File.ReadAllLines(readIniPath);
            List<string> newIniLines = new List<string>();
            Dictionary<string, string> fileNameUuidDict = new Dictionary<string, string>();
            foreach (string iniLine in readIniLines)
            {
                string lowerIniLine = iniLine.ToLower();
                if (lowerIniLine.StartsWith("filename"))
                {
                    int firstEqualSignIndex = iniLine.IndexOf("=");
                    string valSection = iniLine.Substring(firstEqualSignIndex);
                    string resourceFileName = valSection.Substring(1).Trim();
                    //generate a uuid to replace this filename
                    string randomUUID = Guid.NewGuid().ToString();

                    //因为不能有重复键
                    if (!fileNameUuidDict.ContainsKey(resourceFileName))
                    {
                        fileNameUuidDict.Add(resourceFileName, randomUUID);
                    }
                    else
                    {
                        randomUUID = fileNameUuidDict[resourceFileName];
                    }

                    string newIniLine = "";
                    if (resourceFileName.EndsWith(".dds"))
                    {
                        if (obfusVersion == "Dev")
                        {
                            newIniLine = iniLine.Replace(resourceFileName, randomUUID + ".dds");
                        }
                        else
                        {
                            newIniLine = iniLine.Replace(resourceFileName, randomUUID + ".bundle");
                        }
                    }
                    else if (resourceFileName.EndsWith(".png"))
                    {
                        newIniLine = iniLine.Replace(resourceFileName, randomUUID + ".png");
                    }
                    else
                    {
                        newIniLine = iniLine.Replace(resourceFileName, randomUUID + ".assets");
                    }
                    newIniLines.Add(newIniLine);
                }
                else
                {
                    newIniLines.Add(iniLine);

                }
            }


            string parentDirectory = Directory.GetParent(readDirectoryPath).FullName;
            //MessageBox.Show("parentDirectory" + parentDirectory);
            string ModFolderName = Path.GetFileName(readDirectoryPath);
            //MessageBox.Show("ModFolderName" + ModFolderName);

            string newOutputDirectory = parentDirectory + "\\" + ModFolderName + "-Release\\";
            //MessageBox.Show("newOutputDirectory" + newOutputDirectory);

            Directory.CreateDirectory(newOutputDirectory);

            //Create a new ini file.
            string newIniFilePath = newOutputDirectory + Guid.NewGuid().ToString() + ".ini";
            File.WriteAllLines(newIniFilePath, newIniLines);

            foreach (KeyValuePair<string, string> pair in fileNameUuidDict)
            {
                string key = pair.Key;
                string value = pair.Value;

                string oldResourceFilePath = readDirectoryPath + "\\" + key;


                string newResourceFilePath = "";
                if (key.EndsWith(".dds"))
                {
                    if (obfusVersion == "Dev")
                    {
                        newResourceFilePath = newOutputDirectory + value + ".dds";
                    }
                    else
                    {
                        newResourceFilePath = newOutputDirectory + value + ".bundle";
                    }
                }
                else if (key.EndsWith(".png"))
                {
                    newResourceFilePath = newOutputDirectory + value + ".png";
                }
                else
                {
                    newResourceFilePath = newOutputDirectory + value + ".assets";
                }

                if (File.Exists(oldResourceFilePath))
                {
                    File.Copy(oldResourceFilePath, newResourceFilePath, true);
                }

            }

            ShowMessageBox("Obfuscated success.", "混淆成功");


            return newIniFilePath;
        }


        void Run_DBMT_PROTECT(string RunCommand)
        {
            // 批量锁机器码： 递归遍历目录下所有的.ini文件加密
            // 先统计所有文件，ini文件改为.resS后缀，然后创建一个新的目录去生成
            // 这个过程在C++里执行就好了，这里只负责调用
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog1.SelectedPath;

                if (ContainsChinese(selectedPath))
                {
                    ShowMessageBox("Target Path Can't Contains Chinese.", "目标路径中不能含有中文字符");
                    return;
                }


                bool saveResult = saveACLConfig(selectedPath);
                if (saveResult)
                {
                    runCommand(RunCommand, "DBMT-Protect.vmp.exe");
                }
            }
        }

    }
}
