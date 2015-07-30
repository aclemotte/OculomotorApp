using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Enabled = false;
            this.Close();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            timerSplash.Enabled = true;
        }
    }
}
