using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace TestMyApp_AutoUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 初始化自动更新
            //AutoUpdaterExample autoUpdater = new AutoUpdaterExample();
            //autoUpdater.ConfigureAutoUpdater();

            Application.Run(new Form1());
        }

    }
}
