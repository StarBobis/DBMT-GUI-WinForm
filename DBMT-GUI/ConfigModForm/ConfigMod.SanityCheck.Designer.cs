using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NMBT_GUI
{
    partial class ConfigMod
    {

        public bool ContainsChinese(string input)
        {
            // 使用正则表达式匹配中文字符
            Regex regex = new Regex(@"[\u4e00-\u9fa5]");
            return regex.IsMatch(input);
        }

        public bool HashFormatCheck(string name, string value)
        {
            if (!StringSanityCheck(name, value))
            {
                return false;
            }
            else if (value.Contains(" "))
            {
                ShowMessageBox(name + " can't contains Space character", name + "不能出现空格");
                //MessageBox.Show(name + "不能出现空格", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (value.Length != 8)
            {
                ShowMessageBox(name + " is a hash value so length must be 8", name + "是Hash值，长度必须为8");
                //MessageBox.Show(name + "是Hash值，长度必须为8", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool StringSanityCheck(string name, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                ShowMessageBox(name + " can't be empty", name + "不能为空");
                //MessageBox.Show(name + "不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (ContainsChinese(value))
            {
                ShowMessageBox(name + " can't contains Chinese", name + "不能出现中文");
                //MessageBox.Show(name + "不能出现中文", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        public bool IsInRange(string input)
        {
            if (int.TryParse(input, out int number))
            {
                // 检查数字是否在0到255之间
                if (number >= 0 && number <= 255)
                {
                    return true;
                }
            }

            return false;
        }

        public bool checkConfig()
        {
            if (checkBoxColorRGBR.Checked)
            {
                string rgbr = textBoxColorRGBR.Text;
                if (!IsInRange(rgbr))
                {
                    ShowMessageBox("Color rgb_r must between 0 to 255", "Color值rgb_r必须位于0-255之间");
                    //MessageBox.Show("Color值rgb_r必须位于0-255之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (checkBoxColorRGBG.Checked)
            {
                string rgbg = textBoxColorRGBG.Text;
                if (!IsInRange(rgbg))
                {
                    ShowMessageBox("Color rgb_g must between 0 to 255", "Color值rgb_g必须位于0-255之间");

                    //MessageBox.Show("Color值rgb_g必须位于0-255之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (checkBoxColorRGBB.Checked)
            {
                string rgbb = textBoxColorRGBB.Text;
                if (!IsInRange(rgbb))
                {
                    ShowMessageBox("Color rgb_b must between 0 to 255", "Color值rgb_b必须位于0-255之间");

                    //MessageBox.Show("Color值rgb_b必须位于0-255之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (checkBoxColorRGBA.Checked)
            {
                string rgba = textBoxColorRGBA.Text;
                if (!IsInRange(rgba))
                {

                    ShowMessageBox("Color rgb_a must between 0 to 255", "Color值rgb_a必须位于0-255之间");

                    //MessageBox.Show("Color值rgb_a必须位于0-255之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
