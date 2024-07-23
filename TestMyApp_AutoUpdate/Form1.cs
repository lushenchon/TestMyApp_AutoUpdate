using AutoUpdaterDotNET;
using Sunny.UI;
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
            UILocalizeHelper.SetEN();
            UIStyles.DPIScale = true;
            UIStyles.GlobalFont = true;
            UIStyles.GlobalFontName = "Microsoft YaHei UI";
            UIStyles.GlobalFontScale = 100;
            UIStyles.SetDPIScale();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AutoUpdater.Start("https://raw.githubusercontent.com/lushenchon/TestMyApp_AutoUpdate/master/update.xml");
            
            // 当前版本号
            AutoUpdater.InstalledVersion = new Version("1.0.4");
            // 初始化自动更新
            AutoUpdaterExample autoUpdater = new AutoUpdaterExample();
            autoUpdater.ConfigureAutoUpdater();
        }
    }
}
