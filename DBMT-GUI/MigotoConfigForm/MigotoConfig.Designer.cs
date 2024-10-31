namespace DBMT_GUI
{
    partial class MigotoConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Initialize_Config_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save_Config_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_LoaderConfig = new System.Windows.Forms.ToolStripComboBox();
            this.Menu_SaveD3DXConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_target = new System.Windows.Forms.Label();
            this.label_launch = new System.Windows.Forms.Label();
            this.textBox_target = new System.Windows.Forms.TextBox();
            this.textBox_launch = new System.Windows.Forms.TextBox();
            this.button_choose_file_target = new System.Windows.Forms.Button();
            this.button_choose_file_launch = new System.Windows.Forms.Button();
            this.label_launch_args = new System.Windows.Forms.Label();
            this.textBox_launch_args = new System.Windows.Forms.TextBox();
            this.checkBox_require_admin = new System.Windows.Forms.CheckBox();
            this.label_module = new System.Windows.Forms.Label();
            this.textBox_module = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Initialize_Config_ToolStripMenuItem,
            this.Menu_Save_Config_ToolStripMenuItem,
            this.toolStripComboBox_LoaderConfig,
            this.Menu_SaveD3DXConfig_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Initialize_Config_ToolStripMenuItem
            // 
            this.Menu_Initialize_Config_ToolStripMenuItem.Name = "Menu_Initialize_Config_ToolStripMenuItem";
            this.Menu_Initialize_Config_ToolStripMenuItem.Size = new System.Drawing.Size(80, 25);
            this.Menu_Initialize_Config_ToolStripMenuItem.Text = "初始化配置";
            this.Menu_Initialize_Config_ToolStripMenuItem.Click += new System.EventHandler(this.Menu_Initialize_Config_ToolStripMenuItem_Click);
            // 
            // Menu_Save_Config_ToolStripMenuItem
            // 
            this.Menu_Save_Config_ToolStripMenuItem.Name = "Menu_Save_Config_ToolStripMenuItem";
            this.Menu_Save_Config_ToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.Menu_Save_Config_ToolStripMenuItem.Text = "保存配置";
            this.Menu_Save_Config_ToolStripMenuItem.Click += new System.EventHandler(this.Menu_Save_Config_ToolStripMenuItem_Click);
            // 
            // toolStripComboBox_LoaderConfig
            // 
            this.toolStripComboBox_LoaderConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox_LoaderConfig.Name = "toolStripComboBox_LoaderConfig";
            this.toolStripComboBox_LoaderConfig.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox_LoaderConfig.TextChanged += new System.EventHandler(this.toolStripComboBox_LoaderConfig_TextChanged);
            // 
            // Menu_SaveD3DXConfig_ToolStripMenuItem
            // 
            this.Menu_SaveD3DXConfig_ToolStripMenuItem.Name = "Menu_SaveD3DXConfig_ToolStripMenuItem";
            this.Menu_SaveD3DXConfig_ToolStripMenuItem.Size = new System.Drawing.Size(129, 25);
            this.Menu_SaveD3DXConfig_ToolStripMenuItem.Text = "应用到当前d3dx.ini";
            this.Menu_SaveD3DXConfig_ToolStripMenuItem.Click += new System.EventHandler(this.Menu_SaveD3DXConfig_ToolStripMenuItem_Click);
            // 
            // label_target
            // 
            this.label_target.AutoSize = true;
            this.label_target.Location = new System.Drawing.Point(12, 45);
            this.label_target.Name = "label_target";
            this.label_target.Size = new System.Drawing.Size(77, 12);
            this.label_target.TabIndex = 1;
            this.label_target.Text = "目标进程路径";
            // 
            // label_launch
            // 
            this.label_launch.AutoSize = true;
            this.label_launch.Location = new System.Drawing.Point(12, 79);
            this.label_launch.Name = "label_launch";
            this.label_launch.Size = new System.Drawing.Size(77, 12);
            this.label_launch.TabIndex = 2;
            this.label_launch.Text = "启动进程路径";
            // 
            // textBox_target
            // 
            this.textBox_target.Location = new System.Drawing.Point(104, 42);
            this.textBox_target.Name = "textBox_target";
            this.textBox_target.Size = new System.Drawing.Size(454, 21);
            this.textBox_target.TabIndex = 3;
            // 
            // textBox_launch
            // 
            this.textBox_launch.Location = new System.Drawing.Point(104, 74);
            this.textBox_launch.Name = "textBox_launch";
            this.textBox_launch.Size = new System.Drawing.Size(454, 21);
            this.textBox_launch.TabIndex = 4;
            // 
            // button_choose_file_target
            // 
            this.button_choose_file_target.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_choose_file_target.Location = new System.Drawing.Point(576, 40);
            this.button_choose_file_target.Name = "button_choose_file_target";
            this.button_choose_file_target.Size = new System.Drawing.Size(75, 23);
            this.button_choose_file_target.TabIndex = 5;
            this.button_choose_file_target.Text = "选择文件";
            this.button_choose_file_target.UseVisualStyleBackColor = true;
            this.button_choose_file_target.Click += new System.EventHandler(this.button_choose_file_target_Click);
            // 
            // button_choose_file_launch
            // 
            this.button_choose_file_launch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_choose_file_launch.Location = new System.Drawing.Point(576, 74);
            this.button_choose_file_launch.Name = "button_choose_file_launch";
            this.button_choose_file_launch.Size = new System.Drawing.Size(75, 23);
            this.button_choose_file_launch.TabIndex = 6;
            this.button_choose_file_launch.Text = "选择文件";
            this.button_choose_file_launch.UseVisualStyleBackColor = true;
            this.button_choose_file_launch.Click += new System.EventHandler(this.button_choose_file_launch_Click);
            // 
            // label_launch_args
            // 
            this.label_launch_args.AutoSize = true;
            this.label_launch_args.Location = new System.Drawing.Point(36, 107);
            this.label_launch_args.Name = "label_launch_args";
            this.label_launch_args.Size = new System.Drawing.Size(53, 12);
            this.label_launch_args.TabIndex = 7;
            this.label_launch_args.Text = "启动参数";
            // 
            // textBox_launch_args
            // 
            this.textBox_launch_args.Location = new System.Drawing.Point(104, 104);
            this.textBox_launch_args.Name = "textBox_launch_args";
            this.textBox_launch_args.Size = new System.Drawing.Size(454, 21);
            this.textBox_launch_args.TabIndex = 8;
            // 
            // checkBox_require_admin
            // 
            this.checkBox_require_admin.AutoSize = true;
            this.checkBox_require_admin.Location = new System.Drawing.Point(38, 174);
            this.checkBox_require_admin.Name = "checkBox_require_admin";
            this.checkBox_require_admin.Size = new System.Drawing.Size(144, 16);
            this.checkBox_require_admin.TabIndex = 9;
            this.checkBox_require_admin.Text = "加载器使用管理员权限";
            this.checkBox_require_admin.UseVisualStyleBackColor = true;
            // 
            // label_module
            // 
            this.label_module.AutoSize = true;
            this.label_module.Location = new System.Drawing.Point(36, 141);
            this.label_module.Name = "label_module";
            this.label_module.Size = new System.Drawing.Size(53, 12);
            this.label_module.TabIndex = 10;
            this.label_module.Text = "注入模块";
            // 
            // textBox_module
            // 
            this.textBox_module.Location = new System.Drawing.Point(104, 138);
            this.textBox_module.Name = "textBox_module";
            this.textBox_module.Size = new System.Drawing.Size(105, 21);
            this.textBox_module.TabIndex = 11;
            this.textBox_module.Text = "d3d11.dll";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MigotoConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 207);
            this.Controls.Add(this.textBox_module);
            this.Controls.Add(this.label_module);
            this.Controls.Add(this.checkBox_require_admin);
            this.Controls.Add(this.textBox_launch_args);
            this.Controls.Add(this.label_launch_args);
            this.Controls.Add(this.button_choose_file_launch);
            this.Controls.Add(this.button_choose_file_target);
            this.Controls.Add(this.textBox_launch);
            this.Controls.Add(this.textBox_target);
            this.Controls.Add(this.label_launch);
            this.Controls.Add(this.label_target);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MigotoConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MigotoConfig";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MigotoConfig_FormClosed);
            this.Load += new System.EventHandler(this.MigotoConfig_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Initialize_Config_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save_Config_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_LoaderConfig;
        private System.Windows.Forms.Label label_target;
        private System.Windows.Forms.Label label_launch;
        private System.Windows.Forms.TextBox textBox_target;
        private System.Windows.Forms.TextBox textBox_launch;
        private System.Windows.Forms.Button button_choose_file_target;
        private System.Windows.Forms.Button button_choose_file_launch;
        private System.Windows.Forms.Label label_launch_args;
        private System.Windows.Forms.TextBox textBox_launch_args;
        private System.Windows.Forms.CheckBox checkBox_require_admin;
        private System.Windows.Forms.Label label_module;
        private System.Windows.Forms.TextBox textBox_module;
        private System.Windows.Forms.ToolStripMenuItem Menu_SaveD3DXConfig_ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}