using AutoUpdaterDotNET;
using System;
using System.Windows.Forms;
using System.Timers;

namespace TestMyApp_AutoUpdate
{
    public  class AutoUpdaterExample
    {
        public void ConfigureAutoUpdater()
        {
            // 设置更新检查频率（例如：每天一次）
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.Start("https://github.com/lushenchon/TestMyApp_AutoUpdate/blob/master/TestMyApp_AutoUpdate/bin/Debug/update.xml");

            // 如果需要设置检查频率，可以使用静态计时器类
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 24 * 60 * 60 * 1000 // 每24小时检查一次
            };
            timer.Elapsed += (sender, args) => AutoUpdater.Start("https://github.com/lushenchon/TestMyApp_AutoUpdate/blob/master/TestMyApp_AutoUpdate/bin/Debug/update.xml");
            timer.Start();
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult = MessageBox.Show(
                            $@"有一个新版本 {args.CurrentVersion} 可用。您正在使用版本 {args.InstalledVersion}。点击确认开始更新",
                            @"更新可用",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult = MessageBox.Show(
                            $@"有一个新版本 {args.CurrentVersion} 可用。您正在使用版本 {args.InstalledVersion}。确认要更新吗？",
                            @"更新可用",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);
                    }

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"没有可用更新。请稍后再试。", @"没有更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is System.Net.WebException)
                {
                    MessageBox.Show(
                        @"连接更新服务器失败，请检查网络连接。",
                        @"更新检查失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message, args.Error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
