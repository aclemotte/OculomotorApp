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

namespace LookAndPlayForm
{

    public static class Program
    {
        public static EyeTrackingEngine eyeTrackingEngine;

        public static SharedData datosCompartidos;

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

                institution_class_engine institution_engine = new institution_class_engine();
                FormInstitutionID fInstitution = new FormInstitutionID(institution_engine);

                //try
                //{
                //    probarLogError();
                //}
                //catch (Exception ex)
                //{
                //    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                //}

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

        //private static void probarLogError()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
