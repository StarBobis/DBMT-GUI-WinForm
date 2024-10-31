using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMT_GUI
{
    partial class MigotoConfig
    {
        void ShowMessageBox(string EnglishTip, string ChineseTip)
        {
            MessageBox.Show(ChineseTip);
        }

        public bool ContainsChinese(string input)
        {
            // 使用正则表达式匹配中文字符
            Regex regex = new Regex(@"[\u4e00-\u9fa5]");
            return regex.IsMatch(input);
        }

        void InitializeToolTip()
        {
            //Include
            //在DBMT的设计中为固定值，不是用户需要考虑的东西

            //Logging
            //toolTip1.SetToolTip(checkBox_logging_calls, "Log all API usage");
            

        }



    }
}
