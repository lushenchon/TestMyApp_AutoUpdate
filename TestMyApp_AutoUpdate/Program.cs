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

            // 配置 AutoUpdater.NET
            AutoUpdater.Start("https://yourserver.com/updates.xml");

            // 你可以选择在应用启动时检查更新
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.Start("https://yourserver.com/updates.xml");

            Application.Run(new Form1());
        }

        private static void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {
                // 弹出更新提示
                DialogResult dialogResult = MessageBox.Show("New version available. Do you want to update now?", "Update Available", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // 启动更新程序
                    AutoUpdater.DownloadUpdate(args);
                }
            }
            else
            {
                MessageBox.Show("No updates available.");
            }
        }
    }
}
