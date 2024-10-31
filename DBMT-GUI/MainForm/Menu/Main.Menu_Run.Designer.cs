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

        void Menu_Run_3DmigotoLoaderPython()
        {
            string LoaderExePath = this.Path_LoaderFolder + "3Dmigoto Loader.py";
            if (File.Exists(LoaderExePath))
            {
                Process.Start(LoaderExePath);
            }
            else
            {
                ShowMessageBox("Can't find 3Dmigoto Loader.py in your game's [3Dmigoto] folder.", "在您当前游戏的[3Dmigoto]目录中未找到3Dmigoto Loader.py");
            }
        }


        void Menu_Run_3DmigotoLoaderExe()
        {
            string LoaderExePath = this.Path_LoaderFolder + "3Dmigoto Loader.exe";
            if (File.Exists(LoaderExePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(LoaderExePath);
                startInfo.Verb = "runas";
                startInfo.UseShellExecute = false;
                startInfo.WorkingDirectory = Path.GetDirectoryName(LoaderExePath);
                Process.Start(startInfo);
            }
            else
            {
                ShowMessageBox("Can't find 3Dmigoto Loader.exe in your game's [3Dmigoto] folder.", "在您当前游戏的[3Dmigoto]目录中未找到3Dmigoto Loader.exe");
            }
        }

        void Menu_Run_3DmigotoLoaderByPassACE()
        {
            string LoaderExePath = this.Path_LoaderFolder + "3Dmigoto Loader-ByPassACE.exe";
            if (File.Exists(LoaderExePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(LoaderExePath);
                startInfo.Verb = "runas";
                startInfo.WorkingDirectory = Path.GetDirectoryName(LoaderExePath);
                startInfo.UseShellExecute = false;
                Process.Start(startInfo);
            }
            else
            {
                ShowMessageBox("Can't find 3Dmigoto Loader-ByPassACE.exe in your game's [3Dmigoto] folder.", "在您当前游戏的[3Dmigoto]目录中未找到3Dmigoto Loader-ByPassACE.exe");
            }
        }


    }
}
