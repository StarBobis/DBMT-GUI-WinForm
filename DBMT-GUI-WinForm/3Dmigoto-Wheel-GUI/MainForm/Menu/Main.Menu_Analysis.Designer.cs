using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMBT_GUI
{
    partial class Main
    {

        void Menu_Analysis_SkipIB()
        {
            //这里不需要区分match_first_index,这是因为我们实际测试中不再需要用到match_first_index的过滤了。
            //直接分割然后输出即可
            List<string> strings = new List<string>();
            if (textBoxSkipIBList.Text.Contains(","))
            {
                strings = textBoxSkipIBList.Text.Split(',').ToList();
            }
            else
            {
                strings.Add(textBoxSkipIBList.Text);
            }

            string outputContent = "";
            foreach (string DrawIB in strings)
            {
                outputContent = outputContent + "[TextureOverride_IB_" + DrawIB + "]\r\n";
                outputContent = outputContent + "hash = " + DrawIB + "\r\n";
                outputContent = outputContent + "handling = skip\r\n";
                outputContent = outputContent + "\r\n";
            }

            string outputPath = this.Path_OutputFolder + "IBSkip.ini";
            File.WriteAllText(outputPath, outputContent);

            Process.Start(this.Path_OutputFolder);
            //ShowMessageBox("Run Success.", "生成成功");
        }


        void Menu_Analysis_GenerateShaderCheck()
        {
            Dictionary<string, List<string>> buffHash_vsShaderHashValues_Dict = GetBuffHash_VSShaderHashValues_Dict();
            List<string> DrawIBList = GetDrawIBListFromTwoInput();
            //TODO 写入json配置，并触发Update
            //(1) 检查游戏类型是否设置
            if (CurrentGameName == "")
            {
                ShowMessageBox("Please select your current game before you save.", "请选择您的游戏类型");
            }
            JObject jsonObject = new JObject();

            if (File.Exists(this.Path_Game_VSCheck_Json))
            {
                string jsonData = File.ReadAllText(this.Path_Game_VSCheck_Json);
                jsonObject = JObject.Parse(jsonData);
            }

            JArray gameJarray = new JArray();
            // 获取当前游戏的JObject

            HashSet<string> VSHashList = new HashSet<string>();
            //统计一下新的
            foreach (KeyValuePair<string, List<string>> kvp in buffHash_vsShaderHashValues_Dict)
            {
                string indexBufferHash = kvp.Key;
                List<string> values = kvp.Value;

                //这里IB必须存在于两个DrawIB的列表里
                if (DrawIBList.Contains(indexBufferHash))
                {
                    foreach (string VSHash in values)
                    {
                        VSHashList.Add(VSHash);
                    }
                }
                else
                {
                    //MessageBox.Show(DrawIBList[0]);
                }

            }
            //再统计一下旧的,只有在包含的时候统计
            if (jsonObject.ContainsKey(CurrentGameName))
            {
                JArray gameJarrayRead = (JArray)jsonObject[CurrentGameName];
                foreach (JObject property in gameJarrayRead)
                {
                    string hash = (string)property["ShaderHash"];
                    VSHashList.Add(hash);
                }
            }


            //写出
            foreach (string VSHash in VSHashList)
            {
                JObject jobj = new JObject();
                jobj["ShaderHash"] = VSHash;
                jobj["CheckSlots"] = textBoxVertexShaderCheckList.Text;
                jobj["forbiden"] = "false";
                gameJarray.Add(jobj);
            }


            //保存覆盖
            jsonObject[CurrentGameName] = gameJarray;
            // 将JObject转换为JSON字符串
            string json_string = jsonObject.ToString(Formatting.Indented);
            // 将JSON字符串写入文件
            File.WriteAllText(this.Path_Game_VSCheck_Json, json_string);


            bool readResult = updateShaderCheckList();
            if (readResult)
            {
                ShowMessageBox("Update Success.", "更新成功");
            }
        }




    }
}
