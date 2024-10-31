using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMT_GUI
{
    partial class MigotoConfig
    {
        void Initialize_ComboboxLoaderConfig()
        {

            toolStripComboBox_LoaderConfig.Items.Clear();
            //读取Combobox里的配置
            if (File.Exists(Path_LoaderConfig))
            {
                string jsonData = File.ReadAllText(Path_LoaderConfig);
                JArray jsonArray = JArray.Parse(jsonData);

                foreach (JObject obj in jsonArray)
                {
                    string LoaderConfigName = (string)obj["LoaderConfigName"];
                    toolStripComboBox_LoaderConfig.Items.Add(LoaderConfigName);
                }
            }
        }

        void Initialize_Config()
        {
            //简单的把各个组件内容恢复默认即可
            textBox_target.Text = string.Empty;
            textBox_launch.Text = string.Empty;
            textBox_launch_args.Text = string.Empty;
            textBox_module.Text = "d3d11.dll";
            checkBox_require_admin.Checked = true;
        }

        void Read_Config()
        {
            if (File.Exists(Path_LoaderConfig))
            {
                string jsonData = File.ReadAllText(Path_LoaderConfig);
                JArray jsonArray = JArray.Parse(jsonData);

                foreach (JObject obj in jsonArray)
                {
                    string LoaderConfigName = (string)obj["LoaderConfigName"];
                    if (toolStripComboBox_LoaderConfig.Text != LoaderConfigName)
                    {
                        continue;
                    }


                    //读取Merge配置
                    if (obj.ContainsKey("target"))
                    {
                        textBox_target.Text = (string)obj["target"];
                    }

                    if (obj.ContainsKey("module"))
                    {
                        textBox_module.Text = (string)obj["module"];
                    }

                    if (obj.ContainsKey("launch"))
                    {
                        textBox_launch.Text = (string)obj["launch"];
                    }

                    if (obj.ContainsKey("launch_args"))
                    {
                        textBox_launch_args.Text = (string)obj["launch_args"];
                    }

                    if (obj.ContainsKey("require_admin"))
                    {
                        checkBox_require_admin.Checked = (bool)obj["require_admin"];
                    }

                }
            }
        }


        void Save_Config()
        {
            // 创建一个空的JObject对象，用来保存配置
            JArray jsonArray = new JArray();
            if (File.Exists(Path_LoaderConfig))
            {
                // 文件存在，读取文件内容
                string jsonData = File.ReadAllText(Path_LoaderConfig);
                jsonArray = JArray.Parse(jsonData);
            }

            //1.查找是否存在该名称，如果存在，就进行修改，否则新建一个添加到Jarray里，然后保存。
            bool findLoaderConfigName = false;
            for (int i = 0; i < jsonArray.Count; i++)
            {
                // 使用[i]获取并修改JArray里的东西会影响到 jsonArray 中的元素，而使用foreach不会。
                JObject obj = (JObject)jsonArray[i];
                string LoaderConfigName = (string)obj["LoaderConfigName"];
                if (LoaderConfigName == toolStripComboBox_LoaderConfig.Text)
                {
                    findLoaderConfigName = true;
                    break;
                }
            }

            if (findLoaderConfigName)
            {
                //如果存在该DrawIB，那就修改这个DrawIB的值
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    JObject obj = (JObject)jsonArray[i];
                    string LoaderConfigName = (string)obj["LoaderConfigName"];
                    if (LoaderConfigName != toolStripComboBox_LoaderConfig.Text)
                    {
                        continue;
                    }

                    obj["module"] = textBox_module.Text;
                    obj["target"] = textBox_target.Text;
                    obj["launch_args"] = textBox_launch_args.Text;
                    obj["launch"] = textBox_launch.Text;
                    obj["require_admin"] = checkBox_require_admin.Checked;
                }
            }
            else
            {
                //如果没找到，那就新建一个JObject来装载各个属性，然后放到这个JArray里
                JObject obj = new JObject();
                obj["LoaderConfigName"] = toolStripComboBox_LoaderConfig.Text;
                obj["module"] = textBox_module.Text;
                obj["target"] = textBox_target.Text;
                obj["launch_args"] = textBox_launch_args.Text;
                obj["launch"] = textBox_launch.Text;
                obj["require_admin"] = checkBox_require_admin.Checked;
                jsonArray.Add(obj);
            }

            // 将JObject转换为JSON字符串
            string json_string = jsonArray.ToString(Formatting.Indented);

            // 将JSON字符串写入文件
            File.WriteAllText(Path_LoaderConfig, json_string);
        }

    }
}
