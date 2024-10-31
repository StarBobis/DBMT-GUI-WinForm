using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMBT_GUI
{
    partial class Main
    {

        void preDoBeforeMerge()
        {
            if (this.DeleteOutputFolder)
            {
                if (Directory.Exists(this.Path_OutputFolder))
                {
                    Directory.Delete(this.Path_OutputFolder, true);
                    Directory.CreateDirectory(this.Path_OutputFolder);
                }

            }

            if (DataGridView_BasicIBList.Rows.Count == 1)
            {
                ShowMessageBox("Please fill your DrawIB and config it before run.", "在运行之前请填写您的绘制IB的哈希值并进行配置");
                return;
            }

            initializeFolders();
        }




    }
}
