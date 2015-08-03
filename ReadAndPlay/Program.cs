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
        private static EyeTrackingEngine _eyeTrackingEngine;

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


            ClassLogData data2Log = new ClassLogData();

            data2Log.Date = DateTime.Now.ToString("dd/MM/yyyy");
            data2Log.Time_start = DateTime.Now.ToString("HH:mm:ss");

            SplashScreen sscreen = new SplashScreen();
            sscreen.ShowDialog();


            //initial_class_engine initial_engine = new initial_class_engine();
            //initialForm finitial = new initialForm(initial_engine);

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

            //aws_class_engine.UpdateErrorFile(institution_engine.institutionsList[0].institution_name);

            
            if (institution_engine.institutionsList != null || fInstitution.ShowDialog() == DialogResult.OK)
            {
                fInstitution.updateCsv();

            
                
                tester_class_engine tester_engine = new tester_class_engine();
                FormTesterID fTester = new FormTesterID(tester_engine);

                if (fTester.ShowDialog() == DialogResult.OK)
                {
                    fTester.updateCsv();
                    //aws_class_engine.UpdateTestersFile(institution_engine.institutionsList[0].institution_name);
                                        



                    FormPatientID formPatientID = new FormPatientID(institution_engine.institutionsList[0].institution_name);

                    if (formPatientID.ShowDialog() == DialogResult.OK)
                    {
                        formPatientID.updateCsv();//almacena los datos del usuario al pasar el formulario
                        //aws_class_engine.UpdateUsersFile(institution_engine.institutionsList[0].institution_name);

                        datosCompartidos.activeUser = formPatientID.patientDataSelected.user_id;

                        ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();

                        //si es no es un usuario nuevo o 
                        //(si es un usuario nuevo y acepta las clausulas)
                        if (!formPatientID.newUser ||
                                (formPatientID.newUser && formularioConsentimiento.ShowDialog() == DialogResult.OK))
                        {

                            FormSelectionTest selectionTestForm = new FormSelectionTest();

                            if (selectionTestForm.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    using (_eyeTrackingEngine = new EyeTrackingEngine())
                                    {
                                        
                                        EyeXWinForm eyeXWinForm = new EyeXWinForm(_eyeTrackingEngine, institution_engine);
                                        eyeXWinForm.ShowDialog();

                                        //Application.Run(new EyeXWinForm(_eyeTrackingEngine, institution_engine));

                                        //eyeXWinForm.Dispose();

                                        data2Log.Time_end = DateTime.Now.ToString("HH:mm:ss");
                                        data2Log.Tester = fTester.testerDataSelected.tester_name;
                                        data2Log.Patient = formPatientID.patientDataSelected.user_name;
                                        data2Log.number_of_screening_done = datosCompartidos.number_of_screening_done;
                                        data2Log.AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                                        ClassLogEngine.Log(data2Log);

                                        //aws_class_engine.UpdateLogFile(institution_engine.institutionsList[0].institution_name);
                                        
                                    }
                                }

                                catch (EyeTrackerException ex)
                                {
                                    MessageBox.Show(ex.Message, "Failed loading application!");
                                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Error!");
                                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                                }

                                //aws_class_engine.UpdateErrorFile(institution_engine.institutionsList[0].institution_name);
                            }
                        }
                    }
                }
            }
        }

        //private static void probarLogError()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
