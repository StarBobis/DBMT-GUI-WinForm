using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMT_GUI
{
    public partial class MigotoConfig : Form
    {

        private string Path_LoaderConfig = "Configs\\LoaderConfig.json";
        private string Path_LoaderSetting = "Configs\\LoaderSetting.json";
        private string Path_MainConfig = "Configs\\Main.json";
        private string CurrentGameName = "";
        private string CurrentLoaderConfigName = "";

        public MigotoConfig()
        {
            InitializeComponent();
        }


        void Read_CurrentGameName()
        {
            if (File.Exists(Path_MainConfig))
            {
                string json = File.ReadAllText(Path_MainConfig); // 读取文件内容
                JObject jsonObject = JObject.Parse(json);
                string gameName = (string)jsonObject["GameName"];
                // 设置当前游戏类型
                if (gameName != "")
                {
                    this.CurrentGameName = gameName;
                }
            }
        }

        void Read_CurrentLoaderConfigName()
        {
            if (File.Exists(Path_LoaderSetting))
            {
                string json = File.ReadAllText(Path_LoaderSetting);
                JObject kvObject = JObject.Parse(json);
                if (kvObject.ContainsKey(this.CurrentGameName))
                {
                    this.CurrentLoaderConfigName = (string)kvObject[this.CurrentGameName];
                }
            }

            
        }

        void Save_CurrentLoaderConfigName()
        {
            if (File.Exists(Path_LoaderSetting))
            {
                string json = File.ReadAllText(Path_LoaderSetting);
                JObject kvObject = JObject.Parse(json);
                
                kvObject[this.CurrentGameName] = this.CurrentLoaderConfigName;

                // 将JObject转换为JSON字符串
                string json_string = kvObject.ToString(Formatting.Indented);

                // 将JSON字符串写入文件
                File.WriteAllText(Path_LoaderSetting, json_string);
            }
            else
            {
                //如果不存在这个配置文件，则新建并保存
                JObject kvObject = new JObject();

                kvObject[this.CurrentGameName] = this.CurrentLoaderConfigName;

                // 将JObject转换为JSON字符串
                string json_string = kvObject.ToString(Formatting.Indented);

                // 将JSON字符串写入文件
                File.WriteAllText(Path_LoaderSetting, json_string);
            }
        }


        private void MigotoConfig_Load(object sender, EventArgs e)
        {
            InitializeToolTip();
            Initialize_Config();
            Initialize_ComboboxLoaderConfig();

            //TODO
            //启动程序后第一时间先读取MainSetting.json来确定当前工作游戏是什么
            Read_CurrentGameName();
            //然后读取LoaderSetting.json来确定当前工作游戏上次保存的配置是什么。
            //LoaderSetting.json中保存了键值对，即每个游戏对应的配置。
            //这样就能确定具体加载哪个配置了。
            //判断MainSetting.json是否存在
            Read_CurrentLoaderConfigName();

            if (this.CurrentLoaderConfigName != "")
            {
                toolStripComboBox_LoaderConfig.Text = this.CurrentLoaderConfigName;
                //这里触发对应的ReadConfig方法
            }

        }

        private void Menu_Initialize_Config_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize_Config();
        }

        private void Menu_Save_Config_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox_LoaderConfig.Text != "" && !string.IsNullOrEmpty(toolStripComboBox_LoaderConfig.Text))
            {
                Save_Config();
                Save_CurrentLoaderConfigName();
                Initialize_ComboboxLoaderConfig();
                Read_CurrentLoaderConfigName();
                MessageBox.Show("配置保存完成");
            }
            else
            {
                MessageBox.Show("请给当前配置起个名字，否则无法保存");
            }

            
        }

      
        private void MigotoConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (toolStripComboBox_LoaderConfig.Text != "" && !string.IsNullOrEmpty(toolStripComboBox_LoaderConfig.Text))
            {
                Save_Config();
                Save_CurrentLoaderConfigName();
            }
        }



        private void toolStripComboBox_LoaderConfig_TextChanged(object sender, EventArgs e)
        {
            //如果当前的名称不属于已有名称，则不进行更新
            if (toolStripComboBox_LoaderConfig.Items.Contains(toolStripComboBox_LoaderConfig.Text))
            {
                //切换当前对应的LoaderConfigName
                this.CurrentLoaderConfigName = toolStripComboBox_LoaderConfig.Text;
                //读取对应配置
                Initialize_Config();
                Read_Config();
            }
           
        }


        private void Menu_SaveD3DXConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaderConfig loaderConfig = new LoaderConfig();
            loaderConfig.target = textBox_target.Text;
            loaderConfig.launch = textBox_launch.Text;
            loaderConfig.launch_args = textBox_launch_args.Text;
            loaderConfig.require_admin = checkBox_require_admin.Checked;
            loaderConfig.module = textBox_module.Text;

            D3DXConfig d3DXConfig = new D3DXConfig();
            d3DXConfig.InitializeStandardD3DXConfig(loaderConfig);
            string d3dxiniPath = "Games\\" + this.CurrentGameName + "\\3Dmigoto\\d3dx.ini";
            d3DXConfig.SaveToD3DXINI(d3dxiniPath);

            ShowMessageBox("","已保存配置到d3dx.ini");
        }

        private string OpenAndGetExeFilePath()
        {
            openFileDialog1.Filter = "Executable Files (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                if (ContainsChinese(filePath))
                {
                    ShowMessageBox("Target mod ini file path can't contains Chinese.", "目标进程exe文件路径中不能出现中文");
                    return "";
                }
                return filePath;
            }
            else
            {
                return "";
            }
        }

        private void button_choose_file_target_Click(object sender, EventArgs e)
        {
            string OpenFilePath = OpenAndGetExeFilePath();
            if (!string.IsNullOrEmpty(OpenFilePath))
            {
                textBox_target.Text = OpenFilePath;
            }
        }

        private void button_choose_file_launch_Click(object sender, EventArgs e)
        {
            string OpenFilePath = OpenAndGetExeFilePath();
            if (!string.IsNullOrEmpty(OpenFilePath))
            {
                textBox_launch.Text = OpenFilePath;
            }
        }
    }
}
