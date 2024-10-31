namespace NMBT_GUI
{
    partial class ConfigMod
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
            this.checkBoxColorRecalculate = new System.Windows.Forms.CheckBox();
            this.checkBoxColorRGBR = new System.Windows.Forms.CheckBox();
            this.checkBoxColorRGBA = new System.Windows.Forms.CheckBox();
            this.textBoxColorRGBA = new System.Windows.Forms.TextBox();
            this.textBoxColorRGBR = new System.Windows.Forms.TextBox();
            this.textBoxColorRGBB = new System.Windows.Forms.TextBox();
            this.checkBoxColorRGBG = new System.Windows.Forms.CheckBox();
            this.textBoxColorRGBG = new System.Windows.Forms.TextBox();
            this.checkBoxColorRGBB = new System.Windows.Forms.CheckBox();
            this.checkBoxTANGENT = new System.Windows.Forms.CheckBox();
            this.labelExtractType = new System.Windows.Forms.Label();
            this.comboBoxGameType = new System.Windows.Forms.ComboBox();
            this.Menu_InitializeConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.groupBoxExtractConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxModGenerateConfig = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxExtractConfig.SuspendLayout();
            this.groupBoxModGenerateConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxColorRecalculate
            // 
            this.checkBoxColorRecalculate.AutoSize = true;
            this.checkBoxColorRecalculate.Location = new System.Drawing.Point(8, 53);
            this.checkBoxColorRecalculate.Name = "checkBoxColorRecalculate";
            this.checkBoxColorRecalculate.Size = new System.Drawing.Size(276, 16);
            this.checkBoxColorRecalculate.TabIndex = 67;
            this.checkBoxColorRecalculate.Text = "使用AverageNormal归一化算法重新计算COLOR值";
            this.checkBoxColorRecalculate.UseVisualStyleBackColor = true;
            // 
            // checkBoxColorRGBR
            // 
            this.checkBoxColorRGBR.AutoSize = true;
            this.checkBoxColorRGBR.Location = new System.Drawing.Point(8, 20);
            this.checkBoxColorRGBR.Name = "checkBoxColorRGBR";
            this.checkBoxColorRGBR.Size = new System.Drawing.Size(72, 16);
            this.checkBoxColorRGBR.TabIndex = 61;
            this.checkBoxColorRGBR.Text = "红通道 R";
            this.checkBoxColorRGBR.UseVisualStyleBackColor = true;
            this.checkBoxColorRGBR.CheckedChanged += new System.EventHandler(this.checkBoxColorRGBR_CheckedChanged);
            // 
            // checkBoxColorRGBA
            // 
            this.checkBoxColorRGBA.AutoSize = true;
            this.checkBoxColorRGBA.Location = new System.Drawing.Point(391, 17);
            this.checkBoxColorRGBA.Name = "checkBoxColorRGBA";
            this.checkBoxColorRGBA.Size = new System.Drawing.Size(138, 16);
            this.checkBoxColorRGBA.TabIndex = 57;
            this.checkBoxColorRGBA.Text = "Alpha通道(轮廓线) A";
            this.checkBoxColorRGBA.UseVisualStyleBackColor = true;
            this.checkBoxColorRGBA.CheckedChanged += new System.EventHandler(this.checkBoxColorRGBA_CheckedChanged);
            // 
            // textBoxColorRGBA
            // 
            this.textBoxColorRGBA.Location = new System.Drawing.Point(526, 15);
            this.textBoxColorRGBA.Name = "textBoxColorRGBA";
            this.textBoxColorRGBA.Size = new System.Drawing.Size(40, 21);
            this.textBoxColorRGBA.TabIndex = 60;
            // 
            // textBoxColorRGBR
            // 
            this.textBoxColorRGBR.Location = new System.Drawing.Point(83, 15);
            this.textBoxColorRGBR.Name = "textBoxColorRGBR";
            this.textBoxColorRGBR.Size = new System.Drawing.Size(40, 21);
            this.textBoxColorRGBR.TabIndex = 62;
            // 
            // textBoxColorRGBB
            // 
            this.textBoxColorRGBB.Location = new System.Drawing.Point(336, 15);
            this.textBoxColorRGBB.Name = "textBoxColorRGBB";
            this.textBoxColorRGBB.Size = new System.Drawing.Size(40, 21);
            this.textBoxColorRGBB.TabIndex = 66;
            // 
            // checkBoxColorRGBG
            // 
            this.checkBoxColorRGBG.AutoSize = true;
            this.checkBoxColorRGBG.Location = new System.Drawing.Point(133, 18);
            this.checkBoxColorRGBG.Name = "checkBoxColorRGBG";
            this.checkBoxColorRGBG.Size = new System.Drawing.Size(72, 16);
            this.checkBoxColorRGBG.TabIndex = 63;
            this.checkBoxColorRGBG.Text = "绿通道 G";
            this.checkBoxColorRGBG.UseVisualStyleBackColor = true;
            this.checkBoxColorRGBG.CheckedChanged += new System.EventHandler(this.checkBoxColorRGBG_CheckedChanged);
            // 
            // textBoxColorRGBG
            // 
            this.textBoxColorRGBG.Location = new System.Drawing.Point(211, 15);
            this.textBoxColorRGBG.Name = "textBoxColorRGBG";
            this.textBoxColorRGBG.Size = new System.Drawing.Size(40, 21);
            this.textBoxColorRGBG.TabIndex = 65;
            // 
            // checkBoxColorRGBB
            // 
            this.checkBoxColorRGBB.AutoSize = true;
            this.checkBoxColorRGBB.Location = new System.Drawing.Point(258, 17);
            this.checkBoxColorRGBB.Name = "checkBoxColorRGBB";
            this.checkBoxColorRGBB.Size = new System.Drawing.Size(72, 16);
            this.checkBoxColorRGBB.TabIndex = 64;
            this.checkBoxColorRGBB.Text = "蓝通道 B";
            this.checkBoxColorRGBB.UseVisualStyleBackColor = true;
            this.checkBoxColorRGBB.CheckedChanged += new System.EventHandler(this.checkBoxColorRGBB_CheckedChanged);
            // 
            // checkBoxTANGENT
            // 
            this.checkBoxTANGENT.AutoSize = true;
            this.checkBoxTANGENT.Location = new System.Drawing.Point(8, 84);
            this.checkBoxTANGENT.Name = "checkBoxTANGENT";
            this.checkBoxTANGENT.Size = new System.Drawing.Size(288, 16);
            this.checkBoxTANGENT.TabIndex = 58;
            this.checkBoxTANGENT.Text = "使用AverageNormal归一化算法重新计算TANGENT值";
            this.checkBoxTANGENT.UseVisualStyleBackColor = true;
            // 
            // labelExtractType
            // 
            this.labelExtractType.AutoSize = true;
            this.labelExtractType.Location = new System.Drawing.Point(6, 17);
            this.labelExtractType.Name = "labelExtractType";
            this.labelExtractType.Size = new System.Drawing.Size(53, 12);
            this.labelExtractType.TabIndex = 42;
            this.labelExtractType.Text = "提取类型";
            // 
            // comboBoxGameType
            // 
            this.comboBoxGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGameType.FormattingEnabled = true;
            this.comboBoxGameType.Location = new System.Drawing.Point(83, 14);
            this.comboBoxGameType.Name = "comboBoxGameType";
            this.comboBoxGameType.Size = new System.Drawing.Size(209, 20);
            this.comboBoxGameType.TabIndex = 41;
            // 
            // Menu_InitializeConfig_ToolStripMenuItem
            // 
            this.Menu_InitializeConfig_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Menu_InitializeConfig_ToolStripMenuItem.Name = "Menu_InitializeConfig_ToolStripMenuItem";
            this.Menu_InitializeConfig_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.Menu_InitializeConfig_ToolStripMenuItem.Text = "初始化配置";
            this.Menu_InitializeConfig_ToolStripMenuItem.Click += new System.EventHandler(this.Menu_InitializeConfig_ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_InitializeConfig_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // groupBoxExtractConfig
            // 
            this.groupBoxExtractConfig.Controls.Add(this.labelExtractType);
            this.groupBoxExtractConfig.Controls.Add(this.comboBoxGameType);
            this.groupBoxExtractConfig.Location = new System.Drawing.Point(11, 28);
            this.groupBoxExtractConfig.Name = "groupBoxExtractConfig";
            this.groupBoxExtractConfig.Size = new System.Drawing.Size(571, 42);
            this.groupBoxExtractConfig.TabIndex = 4;
            this.groupBoxExtractConfig.TabStop = false;
            this.groupBoxExtractConfig.Text = "提取配置";
            // 
            // groupBoxModGenerateConfig
            // 
            this.groupBoxModGenerateConfig.Controls.Add(this.checkBoxColorRGBR);
            this.groupBoxModGenerateConfig.Controls.Add(this.checkBoxColorRGBB);
            this.groupBoxModGenerateConfig.Controls.Add(this.checkBoxTANGENT);
            this.groupBoxModGenerateConfig.Controls.Add(this.textBoxColorRGBG);
            this.groupBoxModGenerateConfig.Controls.Add(this.checkBoxColorRGBG);
            this.groupBoxModGenerateConfig.Controls.Add(this.checkBoxColorRecalculate);
            this.groupBoxModGenerateConfig.Controls.Add(this.textBoxColorRGBB);
            this.groupBoxModGenerateConfig.Controls.Add(this.textBoxColorRGBR);
            this.groupBoxModGenerateConfig.Controls.Add(this.checkBoxColorRGBA);
            this.groupBoxModGenerateConfig.Controls.Add(this.textBoxColorRGBA);
            this.groupBoxModGenerateConfig.Location = new System.Drawing.Point(11, 76);
            this.groupBoxModGenerateConfig.Name = "groupBoxModGenerateConfig";
            this.groupBoxModGenerateConfig.Size = new System.Drawing.Size(571, 117);
            this.groupBoxModGenerateConfig.TabIndex = 5;
            this.groupBoxModGenerateConfig.TabStop = false;
            this.groupBoxModGenerateConfig.Text = "二创模型生成配置";
            // 
            // ConfigMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(589, 200);
            this.Controls.Add(this.groupBoxModGenerateConfig);
            this.Controls.Add(this.groupBoxExtractConfig);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ConfigMod";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DrawIB的配置";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigMod_FormClosed);
            this.Load += new System.EventHandler(this.ConfigMod_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxExtractConfig.ResumeLayout(false);
            this.groupBoxExtractConfig.PerformLayout();
            this.groupBoxModGenerateConfig.ResumeLayout(false);
            this.groupBoxModGenerateConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem Menu_InitializeConfig_ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBoxColorRGBB;
        private System.Windows.Forms.TextBox textBoxColorRGBG;
        private System.Windows.Forms.CheckBox checkBoxColorRGBB;
        private System.Windows.Forms.CheckBox checkBoxColorRGBG;
        private System.Windows.Forms.TextBox textBoxColorRGBR;
        private System.Windows.Forms.CheckBox checkBoxColorRGBR;
        private System.Windows.Forms.TextBox textBoxColorRGBA;
        private System.Windows.Forms.CheckBox checkBoxColorRGBA;
        private System.Windows.Forms.CheckBox checkBoxTANGENT;
        private System.Windows.Forms.Label labelExtractType;
        private System.Windows.Forms.ComboBox comboBoxGameType;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.GroupBox groupBoxExtractConfig;
        private System.Windows.Forms.GroupBox groupBoxModGenerateConfig;
        private System.Windows.Forms.CheckBox checkBoxColorRecalculate;
    }
}