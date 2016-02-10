using System;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.InitialForm;
using LookAndPlayForm.InstitutionID;
using LookAndPlayForm.LogData;
using LookAndPlayForm.SelectTest;
using LookAndPlayForm.TesterID;
using LookAndPlayForm.Varios;
using Tobii.Gaze.Core;
using LookAndPlayForm.DataBase;
using System.Globalization;
using LookAndPlayForm.Utility;
using System.Data;

namespace LookAndPlayForm
{
    /// <summary>
    /// 
    /// </summary>
    public static class Program
    {
        /// Variables
        #region Variables

        /// <summary>
        /// 
        /// </summary>
        public static EyeTrackingEngine eyeTrackingEngine;       

        public static SharedData datosCompartidos;

        #endregion

        /// Main
        #region Main

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);               

                datosCompartidos = new SharedData();

                SplashScreen sscreen = new SplashScreen();
                sscreen.ShowDialog();

                //DataBaseWorker.SaveFixData("New", "1", DataConverter.GetCurrentTime());
                
                institution_class_engine institution_engine = new institution_class_engine();
                FormInstitutionID fInstitution = new FormInstitutionID(institution_engine);

                if ((institution_engine.institutionsList != null && institution_engine.institutionsList.Count > 0) || fInstitution.ShowDialog() == DialogResult.OK)
                {
                    fInstitution.updateDB();

                    datosCompartidos.institutionName = institution_engine.institutionsList[0].institution_name;
                    HomeForm homeForm = new HomeForm();
                    Application.Run(homeForm);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            finally
            {
                Close();
            }

        }

        private static void Close()
        {
            DataBaseWorker.Close();
        }

        #endregion
    }
}
