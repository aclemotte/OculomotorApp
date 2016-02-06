using LookAndPlayForm.DataBase;
using LookAndPlayForm.Utility;
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
    /// <summary>
    /// 
    /// </summary>
    public partial class SplashScreen : Form
    {
        /// Private Variables
        #region Private Variables

        /// <summary>
        /// 
        /// </summary>
        BackgroundWorker worker = new BackgroundWorker();

        #endregion

        /// Init
        #region Init

        /// <summary>
        /// 
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();

            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        #endregion

        /// Events
        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs args)
        {
            DataBaseWorker.CreateDataBase(CData.DataBasePath);
            DataBaseWorker.ConvertExistingDataFrom(CData.DataFolder);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            if (timerSplash.Enabled)
                return;

            this.Close();
        }                

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Enabled = false;
            if (worker.IsBusy)
                return;

            this.Close();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            timerSplash.Enabled = true;
            worker.RunWorkerAsync();
        }

        #endregion
    }
}
