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

namespace LookAndPlayForm
{

    public static class Program
    {
        public static EyeTrackingEngine eyeTrackingEngine;

        public static sharedData datosCompartidos;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            datosCompartidos = new sharedData();

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
            
            if (institution_engine.institutionsList != null || fInstitution.ShowDialog() == DialogResult.OK)
            {
                fInstitution.updateCsv();

                datosCompartidos.institutionName = institution_engine.institutionsList[0].institution_name;

                HomeFormEngine homeFormEngine = new HomeFormEngine();
                HomeForm homeForm = new HomeForm(homeFormEngine);
                Application.Run(homeForm);
            }
        }

        //private static void probarLogError()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
