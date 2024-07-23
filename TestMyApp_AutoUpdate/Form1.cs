using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMyApp_AutoUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化自动更新
            //AutoUpdaterExample autoUpdater = new AutoUpdaterExample();
            //autoUpdater.ConfigureAutoUpdater();
            AutoUpdater.InstalledVersion = new Version("1.2");
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 1 * 30 * 1000,
                SynchronizingObject = this
            };
            timer.Elapsed += delegate
            {
                AutoUpdater.Start("https://raw.githubusercontent.com/lushenchon/TestMyApp_AutoUpdate/master/update.xml");
            };
            timer.Start();
        }


    }
}
