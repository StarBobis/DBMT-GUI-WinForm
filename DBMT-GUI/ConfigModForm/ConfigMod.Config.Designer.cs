using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMBT_GUI
{
    partial class ConfigMod
    {
        void ShowMessageBox(string EnglishTip, string ChineseTip)
        {
            MessageBox.Show(ChineseTip);
        }


        public void resetConfig()
        {
            //Merge配置
            comboBoxGameType.SelectedIndex = -1;


            //Split配置
            textBoxColorRGBR.Text = string.Empty;
            checkBoxColorRGBR.Checked = true;
            checkBoxColorRGBR.Checked = false;

            textBoxColorRGBG.Text = string.Empty;
            checkBoxColorRGBG.Checked = true;
            checkBoxColorRGBG.Checked = false;

            textBoxColorRGBB.Text = string.Empty;
            checkBoxColorRGBB.Checked = true;
            checkBoxColorRGBB.Checked = false;

            textBoxColorRGBA.Text = string.Empty;
            checkBoxColorRGBA.Checked = true;
            checkBoxColorRGBA.Checked = false;

            checkBoxTANGENT.Checked = true;
            checkBoxTANGENT.Checked = false;

            checkBoxColorRecalculate.Checked = true;
            checkBoxColorRecalculate.Checked = false;

        }

        public void readConfig()
        {
            if (File.Exists(Path_Game_ConfigJson))
            {
                string jsonData = File.ReadAllText(Path_Game_ConfigJson);
                JArray jsonArray = JArray.Parse(jsonData);

                foreach (JObject obj in jsonArray)
                {
                    string drawIB = (string)obj["DrawIB"];
                    if (this.DrawIB != drawIB)
                    {
                        continue;
                    }


                    //读取Merge配置
                    string gameType = (string)obj["GameType"];
                    
                    string forcePointlistIndex = (string)obj["ForcePointlistIndex"];
                    string forceTrianglelistIndex = (string)obj["ForceTrianglelistIndex"];
                    comboBoxGameType.SelectedItem = gameType;
                   

                    //读取Split配置
                    JObject colorDict = (JObject)obj["Color"];
                    string rgb_r = (string)colorDict["rgb_r"];
                    string rgb_g = (string)colorDict["rgb_g"];
                    string rgb_b = (string)colorDict["rgb_b"];
                    string rgb_a = (string)colorDict["rgb_a"];
                    if (rgb_r != "default")
                    {
                        checkBoxColorRGBR.Checked = true;
                        textBoxColorRGBR.Text = rgb_r;
                    }
                    if (rgb_g != "default")
                    {
                        checkBoxColorRGBG.Checked = true;
                        textBoxColorRGBG.Text = rgb_g;
                    }
                    if (rgb_b != "default")
                    {
                        checkBoxColorRGBB.Checked = true;
                        textBoxColorRGBB.Text = rgb_b;
                    }
                    if (rgb_a != "default")
                    {
                        checkBoxColorRGBA.Checked = true;
                        textBoxColorRGBA.Text = rgb_a;
                    }

                    if (obj.ContainsKey("AverageNormalTANGENT"))
                    {
                        checkBoxTANGENT.Checked = (bool)obj["AverageNormalTANGENT"];

                    }
                    if (obj.ContainsKey("AverageNormalCOLOR"))
                    { 
                        checkBoxColorRecalculate.Checked = (bool)obj["AverageNormalCOLOR"];
                    }

                }
            }

        }

        public void saveConfig()
        {
            // 创建一个空的JObject对象，用来保存配置
            JArray jsonArray = new JArray();
            if (File.Exists(Path_Game_ConfigJson))
            {
                // 文件存在，读取文件内容
                string jsonData = File.ReadAllText(Path_Game_ConfigJson);
                jsonArray = JArray.Parse(jsonData);
            }

            //1.查找是否存在该DrawIB，如果存在，就进行修改，否则新建一个添加到Jarray里，然后保存。
            bool findDrawIB = false;
            for (int i = 0; i < jsonArray.Count; i++)
            {
                // 使用[i]获取并修改JArray里的东西会影响到 jsonArray 中的元素，而使用foreach不会。
                JObject obj = (JObject)jsonArray[i];
                string drawIB = (string)obj["DrawIB"];
                if (drawIB  == DrawIB)
                {
                    findDrawIB = true;
                    break;
                }
            }

            if (findDrawIB)
            {
                //如果存在该DrawIB，那就修改这个DrawIB的值
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    JObject obj = (JObject)jsonArray[i];
                    string drawIB = (string)obj["DrawIB"];
                    if (drawIB != DrawIB)
                    {
                        continue;
                    }
                    
                    saveMergeConfig(obj);
                    saveSplitConfig(obj);

                }
            }
            else
            {
                //如果没找到，那就新建一个JObject来装载各个属性，然后放到这个JArray里
                JObject obj = new JObject();
                obj["DrawIB"] = DrawIB;
                saveMergeConfig(obj);
                saveSplitConfig(obj);
                jsonArray.Add(obj);
            }

            // 将JObject转换为JSON字符串
            string json_string = jsonArray.ToString(Formatting.Indented);

            // 将JSON字符串写入文件
            File.WriteAllText(Path_Game_ConfigJson, json_string);


        }
   

        //保存Merge配置
        public void saveMergeConfig(JObject obj)
        {
            //C#的参数是传递引用，所以直接修改会影响传递过来的obj
            obj["GameType"] = comboBoxGameType.Text;
        }

        public void saveSplitConfig(JObject obj)
        {
            JObject colorObject = new JObject();
            if (checkBoxColorRGBR.Checked)
            {
                colorObject["rgb_r"] = textBoxColorRGBR.Text; 
            }
            else
            {
                colorObject["rgb_r"] = "default";
            }
            if (checkBoxColorRGBG.Checked)
            {
                colorObject["rgb_g"] = textBoxColorRGBG.Text;
            }
            else
            {
                colorObject["rgb_g"] = "default";
            }
            if (checkBoxColorRGBB.Checked)
            {
                colorObject["rgb_b"] = textBoxColorRGBB.Text;
            }
            else
            {
                colorObject["rgb_b"] = "default";
            }
            if (checkBoxColorRGBA.Checked)
            {
                colorObject["rgb_a"] = textBoxColorRGBA.Text;
            }
            else
            {
                colorObject["rgb_a"] = "default";
            }
            obj["Color"] = colorObject;

            obj["AverageNormalTANGENT"] = checkBoxTANGENT.Checked;
            obj["AverageNormalCOLOR"] = checkBoxColorRecalculate.Checked;

        }
      

    }
}
