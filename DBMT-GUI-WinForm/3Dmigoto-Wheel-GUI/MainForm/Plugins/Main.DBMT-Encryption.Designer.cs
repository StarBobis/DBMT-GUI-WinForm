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
        public bool DBMT_Encryption_SaveBufferConfig(string targetACLFile, string savePath = "Configs\\ACLSetting.json")
        {
            JObject jsonObject = new JObject();
            jsonObject["targetACLFile"] = targetACLFile;

            string json_string = jsonObject.ToString(Formatting.Indented);
            File.WriteAllText(savePath, json_string);

            return true;
        }


        void DBMT_Encryption_RunCommand(string CommandString, string IniPath)
        {
            if (ContainsChinese(IniPath))
            {
                ShowMessageBox("Target Path Can't Contains Chinese.", "目标路径中不能含有中文字符");
                return;
            }
            //MessageBox.Show(reverse_setting_path);
            JObject jsonObject = new JObject();
            jsonObject["EncryptFilePath"] = IniPath;
            File.WriteAllText("Configs\\ArmorSetting.json", jsonObject.ToString());

            runCommand(CommandString, "DBMT-Encryptor.vmp.exe");
        }


        void DBMT_Encryption_RunCommand_OpenIni(string command)
        {
            openFileDialog1.Filter = "INI Files (*.ini)|*.ini";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                DBMT_Encryption_RunCommand(command, filePath);
            }
        }


        void DBMT_Encryption_EncryptBufferFiles(string EncryptCommand)
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
                bool saveResult = DBMT_Encryption_SaveBufferConfig(selectedPath);
                if (saveResult)
                {
                    runCommand(EncryptCommand, "DBMT-Encryptor.vmp.exe");
                }
            }
        }

    }
}
