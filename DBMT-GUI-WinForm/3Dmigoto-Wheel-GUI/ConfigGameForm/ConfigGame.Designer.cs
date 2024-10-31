namespace NMBT_GUI
{
    partial class ConfigGame
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
            this.checkBoxDeleteOutputFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxBackUp = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxAutoCleanLog = new System.Windows.Forms.CheckBox();
            this.textBoxLogReserveNumber = new System.Windows.Forms.TextBox();
            this.checkBoxAutoCleanFrameAnalysisFolder = new System.Windows.Forms.CheckBox();
            this.textBoxFrameAnalysisFolderReserveNumber = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox_AutoTextureOnlyConvertDiffuseMap = new System.Windows.Forms.CheckBox();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.checkBoxShareSourceModel = new System.Windows.Forms.CheckBox();
            this.groupBoxCreditInfo = new System.Windows.Forms.GroupBox();
            this.textBoxAuthorLink = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelAuthorLink = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.checkBoxOpenModOutputFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxDynamicVertexLimitBreak = new System.Windows.Forms.CheckBox();
            this.groupBoxTexture = new System.Windows.Forms.GroupBox();
            this.checkBoxUseHashTexture = new System.Windows.Forms.CheckBox();
            this.checkBox_ForbidAutoTexture = new System.Windows.Forms.CheckBox();
            this.checkBoxConvertDedupedTextures = new System.Windows.Forms.CheckBox();
            this.labelTextureFormat = new System.Windows.Forms.Label();
            this.comboBoxTextureFormat = new System.Windows.Forms.ComboBox();
            this.groupBoxAutoClean = new System.Windows.Forms.GroupBox();
            this.groupBoxOthers = new System.Windows.Forms.GroupBox();
            this.labelNameStyle = new System.Windows.Forms.Label();
            this.comboBoxModelFileNameStyle = new System.Windows.Forms.ComboBox();
            this.groupBoxTestSetting = new System.Windows.Forms.GroupBox();
            this.checkBoxDontSplitModelByMatchFirstIndex = new System.Windows.Forms.CheckBox();
            this.checkBoxMoveIBRelatedFiles = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxCreditInfo.SuspendLayout();
            this.groupBoxTexture.SuspendLayout();
            this.groupBoxAutoClean.SuspendLayout();
            this.groupBoxOthers.SuspendLayout();
            this.groupBoxTestSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxDeleteOutputFolder
            // 
            this.checkBoxDeleteOutputFolder.AutoSize = true;
            this.checkBoxDeleteOutputFolder.Location = new System.Drawing.Point(8, 64);
            this.checkBoxDeleteOutputFolder.Name = "checkBoxDeleteOutputFolder";
            this.checkBoxDeleteOutputFolder.Size = new System.Drawing.Size(228, 16);
            this.checkBoxDeleteOutputFolder.TabIndex = 56;
            this.checkBoxDeleteOutputFolder.Text = "在提取模型之前自动删除output文件夹";
            this.checkBoxDeleteOutputFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackUp
            // 
            this.checkBoxBackUp.AutoSize = true;
            this.checkBoxBackUp.Location = new System.Drawing.Point(8, 20);
            this.checkBoxBackUp.Name = "checkBoxBackUp";
            this.checkBoxBackUp.Size = new System.Drawing.Size(390, 16);
            this.checkBoxBackUp.TabIndex = 58;
            this.checkBoxBackUp.Text = "在生成二创模型之前自动备份之前的output文件夹到Backups文件夹中";
            this.checkBoxBackUp.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoCleanLog
            // 
            this.checkBoxAutoCleanLog.AutoSize = true;
            this.checkBoxAutoCleanLog.Location = new System.Drawing.Point(8, 20);
            this.checkBoxAutoCleanLog.Name = "checkBoxAutoCleanLog";
            this.checkBoxAutoCleanLog.Size = new System.Drawing.Size(312, 16);
            this.checkBoxAutoCleanLog.TabIndex = 78;
            this.checkBoxAutoCleanLog.Text = "在退出DBMT之前自动清理生成的日志文件，保留数量：";
            this.checkBoxAutoCleanLog.UseVisualStyleBackColor = true;
            this.checkBoxAutoCleanLog.CheckedChanged += new System.EventHandler(this.checkBoxAutoCleanLog_CheckedChanged);
            // 
            // textBoxLogReserveNumber
            // 
            this.textBoxLogReserveNumber.Location = new System.Drawing.Point(319, 15);
            this.textBoxLogReserveNumber.Name = "textBoxLogReserveNumber";
            this.textBoxLogReserveNumber.Size = new System.Drawing.Size(43, 21);
            this.textBoxLogReserveNumber.TabIndex = 79;
            // 
            // checkBoxAutoCleanFrameAnalysisFolder
            // 
            this.checkBoxAutoCleanFrameAnalysisFolder.AutoSize = true;
            this.checkBoxAutoCleanFrameAnalysisFolder.Location = new System.Drawing.Point(8, 42);
            this.checkBoxAutoCleanFrameAnalysisFolder.Name = "checkBoxAutoCleanFrameAnalysisFolder";
            this.checkBoxAutoCleanFrameAnalysisFolder.Size = new System.Drawing.Size(336, 16);
            this.checkBoxAutoCleanFrameAnalysisFolder.TabIndex = 80;
            this.checkBoxAutoCleanFrameAnalysisFolder.Text = "在退出DBMT之前自动清理生成的帧分析文件夹，保留数量：";
            this.checkBoxAutoCleanFrameAnalysisFolder.UseVisualStyleBackColor = true;
            this.checkBoxAutoCleanFrameAnalysisFolder.CheckedChanged += new System.EventHandler(this.checkBoxAutoCleanFrameAnalysisFolder_CheckedChanged);
            // 
            // textBoxFrameAnalysisFolderReserveNumber
            // 
            this.textBoxFrameAnalysisFolderReserveNumber.Location = new System.Drawing.Point(340, 40);
            this.textBoxFrameAnalysisFolderReserveNumber.Name = "textBoxFrameAnalysisFolderReserveNumber";
            this.textBoxFrameAnalysisFolderReserveNumber.Size = new System.Drawing.Size(43, 21);
            this.textBoxFrameAnalysisFolderReserveNumber.TabIndex = 81;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox_AutoTextureOnlyConvertDiffuseMap
            // 
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.AutoSize = true;
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.Location = new System.Drawing.Point(8, 20);
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.Name = "checkBox_AutoTextureOnlyConvertDiffuseMap";
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.Size = new System.Drawing.Size(264, 16);
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.TabIndex = 82;
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.Text = "自动上贴图仅转换DiffuseMap.dds为目标格式";
            this.checkBox_AutoTextureOnlyConvertDiffuseMap.UseVisualStyleBackColor = true;
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(8, 64);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(354, 16);
            this.checkBoxTopMost.TabIndex = 83;
            this.checkBoxTopMost.Text = "保持MMT窗口总是在屏幕最高层级显示，确保一直处于可视状态";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            // 
            // checkBoxShareSourceModel
            // 
            this.checkBoxShareSourceModel.AutoSize = true;
            this.checkBoxShareSourceModel.Location = new System.Drawing.Point(6, 47);
            this.checkBoxShareSourceModel.Name = "checkBoxShareSourceModel";
            this.checkBoxShareSourceModel.Size = new System.Drawing.Size(348, 16);
            this.checkBoxShareSourceModel.TabIndex = 84;
            this.checkBoxShareSourceModel.Text = "在生成二创模型文件时分享导出的源模型方便他人使用和修改";
            this.checkBoxShareSourceModel.UseVisualStyleBackColor = true;
            // 
            // groupBoxCreditInfo
            // 
            this.groupBoxCreditInfo.Controls.Add(this.textBoxAuthorLink);
            this.groupBoxCreditInfo.Controls.Add(this.textBoxAuthor);
            this.groupBoxCreditInfo.Controls.Add(this.labelAuthorLink);
            this.groupBoxCreditInfo.Controls.Add(this.labelAuthor);
            this.groupBoxCreditInfo.Controls.Add(this.checkBoxShareSourceModel);
            this.groupBoxCreditInfo.Location = new System.Drawing.Point(12, 197);
            this.groupBoxCreditInfo.Name = "groupBoxCreditInfo";
            this.groupBoxCreditInfo.Size = new System.Drawing.Size(769, 72);
            this.groupBoxCreditInfo.TabIndex = 85;
            this.groupBoxCreditInfo.TabStop = false;
            this.groupBoxCreditInfo.Text = "版权设置";
            // 
            // textBoxAuthorLink
            // 
            this.textBoxAuthorLink.Location = new System.Drawing.Point(292, 20);
            this.textBoxAuthorLink.Name = "textBoxAuthorLink";
            this.textBoxAuthorLink.Size = new System.Drawing.Size(468, 21);
            this.textBoxAuthorLink.TabIndex = 3;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(64, 20);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(164, 21);
            this.textBoxAuthor.TabIndex = 2;
            // 
            // labelAuthorLink
            // 
            this.labelAuthorLink.AutoSize = true;
            this.labelAuthorLink.Location = new System.Drawing.Point(234, 23);
            this.labelAuthorLink.Name = "labelAuthorLink";
            this.labelAuthorLink.Size = new System.Drawing.Size(53, 12);
            this.labelAuthorLink.TabIndex = 1;
            this.labelAuthorLink.Text = "赞助链接";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(6, 23);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(53, 12);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "作者名称";
            // 
            // checkBoxOpenModOutputFolder
            // 
            this.checkBoxOpenModOutputFolder.AutoSize = true;
            this.checkBoxOpenModOutputFolder.Location = new System.Drawing.Point(8, 42);
            this.checkBoxOpenModOutputFolder.Name = "checkBoxOpenModOutputFolder";
            this.checkBoxOpenModOutputFolder.Size = new System.Drawing.Size(246, 16);
            this.checkBoxOpenModOutputFolder.TabIndex = 86;
            this.checkBoxOpenModOutputFolder.Text = "在生成二创模型后自动打开Mod生成文件夹";
            this.checkBoxOpenModOutputFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxDynamicVertexLimitBreak
            // 
            this.checkBoxDynamicVertexLimitBreak.AutoSize = true;
            this.checkBoxDynamicVertexLimitBreak.Location = new System.Drawing.Point(8, 86);
            this.checkBoxDynamicVertexLimitBreak.Name = "checkBoxDynamicVertexLimitBreak";
            this.checkBoxDynamicVertexLimitBreak.Size = new System.Drawing.Size(144, 16);
            this.checkBoxDynamicVertexLimitBreak.TabIndex = 87;
            this.checkBoxDynamicVertexLimitBreak.Text = "动态突破顶点数量限制";
            this.checkBoxDynamicVertexLimitBreak.UseVisualStyleBackColor = true;
            // 
            // groupBoxTexture
            // 
            this.groupBoxTexture.Controls.Add(this.checkBoxUseHashTexture);
            this.groupBoxTexture.Controls.Add(this.checkBox_ForbidAutoTexture);
            this.groupBoxTexture.Controls.Add(this.checkBoxConvertDedupedTextures);
            this.groupBoxTexture.Controls.Add(this.labelTextureFormat);
            this.groupBoxTexture.Controls.Add(this.comboBoxTextureFormat);
            this.groupBoxTexture.Controls.Add(this.checkBox_AutoTextureOnlyConvertDiffuseMap);
            this.groupBoxTexture.Location = new System.Drawing.Point(12, 108);
            this.groupBoxTexture.Name = "groupBoxTexture";
            this.groupBoxTexture.Size = new System.Drawing.Size(769, 78);
            this.groupBoxTexture.TabIndex = 88;
            this.groupBoxTexture.TabStop = false;
            this.groupBoxTexture.Text = "贴图设置";
            // 
            // checkBoxUseHashTexture
            // 
            this.checkBoxUseHashTexture.AutoSize = true;
            this.checkBoxUseHashTexture.Location = new System.Drawing.Point(504, 49);
            this.checkBoxUseHashTexture.Name = "checkBoxUseHashTexture";
            this.checkBoxUseHashTexture.Size = new System.Drawing.Size(144, 16);
            this.checkBoxUseHashTexture.TabIndex = 87;
            this.checkBoxUseHashTexture.Text = "使用Hash风格替换贴图";
            this.checkBoxUseHashTexture.UseVisualStyleBackColor = true;
            // 
            // checkBox_ForbidAutoTexture
            // 
            this.checkBox_ForbidAutoTexture.AutoSize = true;
            this.checkBox_ForbidAutoTexture.Location = new System.Drawing.Point(311, 50);
            this.checkBox_ForbidAutoTexture.Name = "checkBox_ForbidAutoTexture";
            this.checkBox_ForbidAutoTexture.Size = new System.Drawing.Size(150, 16);
            this.checkBox_ForbidAutoTexture.TabIndex = 86;
            this.checkBox_ForbidAutoTexture.Text = "禁止全自动ini贴图生成";
            this.checkBox_ForbidAutoTexture.UseVisualStyleBackColor = true;
            // 
            // checkBoxConvertDedupedTextures
            // 
            this.checkBoxConvertDedupedTextures.AutoSize = true;
            this.checkBoxConvertDedupedTextures.Location = new System.Drawing.Point(311, 20);
            this.checkBoxConvertDedupedTextures.Name = "checkBoxConvertDedupedTextures";
            this.checkBoxConvertDedupedTextures.Size = new System.Drawing.Size(390, 16);
            this.checkBoxConvertDedupedTextures.TabIndex = 85;
            this.checkBoxConvertDedupedTextures.Text = "把提取出的DedupedTextures中的贴图转换为目标格式方便手动上贴图";
            this.checkBoxConvertDedupedTextures.UseVisualStyleBackColor = true;
            // 
            // labelTextureFormat
            // 
            this.labelTextureFormat.AutoSize = true;
            this.labelTextureFormat.Location = new System.Drawing.Point(6, 50);
            this.labelTextureFormat.Name = "labelTextureFormat";
            this.labelTextureFormat.Size = new System.Drawing.Size(113, 12);
            this.labelTextureFormat.TabIndex = 84;
            this.labelTextureFormat.Text = "自动贴图提取格式：";
            // 
            // comboBoxTextureFormat
            // 
            this.comboBoxTextureFormat.FormattingEnabled = true;
            this.comboBoxTextureFormat.Items.AddRange(new object[] {
            ".jpg",
            ".tga",
            ".png"});
            this.comboBoxTextureFormat.Location = new System.Drawing.Point(119, 47);
            this.comboBoxTextureFormat.Name = "comboBoxTextureFormat";
            this.comboBoxTextureFormat.Size = new System.Drawing.Size(121, 20);
            this.comboBoxTextureFormat.TabIndex = 83;
            // 
            // groupBoxAutoClean
            // 
            this.groupBoxAutoClean.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxAutoClean.Controls.Add(this.checkBoxAutoCleanLog);
            this.groupBoxAutoClean.Controls.Add(this.checkBoxAutoCleanFrameAnalysisFolder);
            this.groupBoxAutoClean.Controls.Add(this.textBoxLogReserveNumber);
            this.groupBoxAutoClean.Controls.Add(this.textBoxFrameAnalysisFolderReserveNumber);
            this.groupBoxAutoClean.Controls.Add(this.checkBoxDeleteOutputFolder);
            this.groupBoxAutoClean.Location = new System.Drawing.Point(12, 13);
            this.groupBoxAutoClean.Name = "groupBoxAutoClean";
            this.groupBoxAutoClean.Size = new System.Drawing.Size(769, 89);
            this.groupBoxAutoClean.TabIndex = 89;
            this.groupBoxAutoClean.TabStop = false;
            this.groupBoxAutoClean.Text = "自动清理";
            // 
            // groupBoxOthers
            // 
            this.groupBoxOthers.Controls.Add(this.labelNameStyle);
            this.groupBoxOthers.Controls.Add(this.comboBoxModelFileNameStyle);
            this.groupBoxOthers.Controls.Add(this.checkBoxBackUp);
            this.groupBoxOthers.Controls.Add(this.checkBoxTopMost);
            this.groupBoxOthers.Controls.Add(this.checkBoxOpenModOutputFolder);
            this.groupBoxOthers.Controls.Add(this.checkBoxDynamicVertexLimitBreak);
            this.groupBoxOthers.Location = new System.Drawing.Point(12, 275);
            this.groupBoxOthers.Name = "groupBoxOthers";
            this.groupBoxOthers.Size = new System.Drawing.Size(769, 141);
            this.groupBoxOthers.TabIndex = 90;
            this.groupBoxOthers.TabStop = false;
            this.groupBoxOthers.Text = "其它设置";
            // 
            // labelNameStyle
            // 
            this.labelNameStyle.AutoSize = true;
            this.labelNameStyle.Location = new System.Drawing.Point(6, 116);
            this.labelNameStyle.Name = "labelNameStyle";
            this.labelNameStyle.Size = new System.Drawing.Size(197, 12);
            this.labelNameStyle.TabIndex = 89;
            this.labelNameStyle.Text = "一键逆向时生成模型文件的命名风格";
            // 
            // comboBoxModelFileNameStyle
            // 
            this.comboBoxModelFileNameStyle.FormattingEnabled = true;
            this.comboBoxModelFileNameStyle.Items.AddRange(new object[] {
            "Number",
            "GIMI"});
            this.comboBoxModelFileNameStyle.Location = new System.Drawing.Point(209, 113);
            this.comboBoxModelFileNameStyle.Name = "comboBoxModelFileNameStyle";
            this.comboBoxModelFileNameStyle.Size = new System.Drawing.Size(121, 20);
            this.comboBoxModelFileNameStyle.TabIndex = 88;
            // 
            // groupBoxTestSetting
            // 
            this.groupBoxTestSetting.Controls.Add(this.checkBoxDontSplitModelByMatchFirstIndex);
            this.groupBoxTestSetting.Controls.Add(this.checkBoxMoveIBRelatedFiles);
            this.groupBoxTestSetting.Location = new System.Drawing.Point(12, 422);
            this.groupBoxTestSetting.Name = "groupBoxTestSetting";
            this.groupBoxTestSetting.Size = new System.Drawing.Size(769, 74);
            this.groupBoxTestSetting.TabIndex = 91;
            this.groupBoxTestSetting.TabStop = false;
            this.groupBoxTestSetting.Text = "测试设置";
            // 
            // checkBoxDontSplitModelByMatchFirstIndex
            // 
            this.checkBoxDontSplitModelByMatchFirstIndex.AutoSize = true;
            this.checkBoxDontSplitModelByMatchFirstIndex.Location = new System.Drawing.Point(8, 42);
            this.checkBoxDontSplitModelByMatchFirstIndex.Name = "checkBoxDontSplitModelByMatchFirstIndex";
            this.checkBoxDontSplitModelByMatchFirstIndex.Size = new System.Drawing.Size(750, 16);
            this.checkBoxDontSplitModelByMatchFirstIndex.TabIndex = 60;
            this.checkBoxDontSplitModelByMatchFirstIndex.Text = "CPU-PreSkinning游戏禁止根据IB的MatchFirstIndex来分割模型文件为不同部位，防止拆分后IB的UniqueVertexCount导致总顶" +
    "点数量增加";
            this.checkBoxDontSplitModelByMatchFirstIndex.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoveIBRelatedFiles
            // 
            this.checkBoxMoveIBRelatedFiles.AutoSize = true;
            this.checkBoxMoveIBRelatedFiles.Location = new System.Drawing.Point(8, 20);
            this.checkBoxMoveIBRelatedFiles.Name = "checkBoxMoveIBRelatedFiles";
            this.checkBoxMoveIBRelatedFiles.Size = new System.Drawing.Size(360, 16);
            this.checkBoxMoveIBRelatedFiles.TabIndex = 59;
            this.checkBoxMoveIBRelatedFiles.Text = "移动DrawIB相关文件到output文件夹的IBRelatedFiles文件夹中";
            this.checkBoxMoveIBRelatedFiles.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // ConfigGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 507);
            this.Controls.Add(this.groupBoxTestSetting);
            this.Controls.Add(this.groupBoxOthers);
            this.Controls.Add(this.groupBoxAutoClean);
            this.Controls.Add(this.groupBoxTexture);
            this.Controls.Add(this.groupBoxCreditInfo);
            this.Name = "ConfigGame";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "首选项";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigGame_FormClosed);
            this.Load += new System.EventHandler(this.ConfigBasic_Load);
            this.groupBoxCreditInfo.ResumeLayout(false);
            this.groupBoxCreditInfo.PerformLayout();
            this.groupBoxTexture.ResumeLayout(false);
            this.groupBoxTexture.PerformLayout();
            this.groupBoxAutoClean.ResumeLayout(false);
            this.groupBoxAutoClean.PerformLayout();
            this.groupBoxOthers.ResumeLayout(false);
            this.groupBoxOthers.PerformLayout();
            this.groupBoxTestSetting.ResumeLayout(false);
            this.groupBoxTestSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxDeleteOutputFolder;
        private System.Windows.Forms.CheckBox checkBoxBackUp;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBoxAutoCleanLog;
        private System.Windows.Forms.TextBox textBoxLogReserveNumber;
        private System.Windows.Forms.CheckBox checkBoxAutoCleanFrameAnalysisFolder;
        private System.Windows.Forms.TextBox textBoxFrameAnalysisFolderReserveNumber;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox_AutoTextureOnlyConvertDiffuseMap;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.CheckBox checkBoxShareSourceModel;
        private System.Windows.Forms.GroupBox groupBoxCreditInfo;
        private System.Windows.Forms.Label labelAuthorLink;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxAuthorLink;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.CheckBox checkBoxOpenModOutputFolder;
        private System.Windows.Forms.CheckBox checkBoxDynamicVertexLimitBreak;
        private System.Windows.Forms.GroupBox groupBoxTexture;
        private System.Windows.Forms.Label labelTextureFormat;
        private System.Windows.Forms.ComboBox comboBoxTextureFormat;
        private System.Windows.Forms.GroupBox groupBoxAutoClean;
        private System.Windows.Forms.GroupBox groupBoxOthers;
        private System.Windows.Forms.GroupBox groupBoxTestSetting;
        private System.Windows.Forms.CheckBox checkBoxMoveIBRelatedFiles;
        private System.Windows.Forms.CheckBox checkBoxConvertDedupedTextures;
        private System.Windows.Forms.CheckBox checkBoxDontSplitModelByMatchFirstIndex;
        private System.Windows.Forms.CheckBox checkBoxUseHashTexture;
        private System.Windows.Forms.CheckBox checkBox_ForbidAutoTexture;
        private System.Windows.Forms.Label labelNameStyle;
        private System.Windows.Forms.ComboBox comboBoxModelFileNameStyle;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}