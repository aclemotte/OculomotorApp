//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.InstitutionID;
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

            if (!institution_class_engine.InstitutionSet())
            {
                intitution_class_data institutionData = new intitution_class_data();
                FormInstitutionID fInstitution = new FormInstitutionID(institutionData);
                fInstitution.ShowDialog();//Problema si se cierra la ventana
                institution_class_engine.setInstitutionName(fInstitution.institutionData);
            }

            FormTesterID fTester = new FormTesterID();

            if (fTester.ShowDialog() == DialogResult.OK)
            {

                FormPatientID formPatientID = new FormPatientID();

                if (formPatientID.ShowDialog() == DialogResult.OK)
                {
                    formPatientID.updateCsv();//almacena los datos del usuario al pasar el formulario
                    datosCompartidos.activeUser = formPatientID.userDataSelected.user_id;

                    ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();
                    
                    //si es no es un usuario nuevo o 
                    //(si es un usuario nuevo y acepta las clausulas)
                    if (!formPatientID.newUser ||
                            (formPatientID.newUser && formularioConsentimiento.ShowDialog() == DialogResult.OK))
                    {

                        try
                        {
                            using (_eyeTrackingEngine = new EyeTrackingEngine())
                            {
                                //EyeXWinForm eyeXWinForm = new EyeXWinForm(_eyeTrackingEngine);
                                //Application.Run(eyeXWinForm);

                                Application.Run(new EyeXWinForm(_eyeTrackingEngine));

                                ////agregar dato de nuevo usuario al final del juego
                                //if (datosCompartidos.updateCsv)
                                //{
                                //    datosCompartidos.updateCsv = false;
                                //    formUserID.updateCsv();
                                //}

                                //eyeXWinForm.Dispose();

                                //subir los datos a la nube
                                AWSClass.Backup(new Config(
                                                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                                                    LookAndPlayForm.Program.datosCompartidos.startTime +
                                                    @"-us" + Program.datosCompartidos.activeUser,
                                                    AwsCredentials.AwsAccessKey,
                                                    AwsCredentials.AwsSecretKey,
                                                    AwsCredentials.AwsS3BucketName));
                            }
                        }

                        catch (EyeTrackerException e)
                        {
                            MessageBox.Show(e.Message, "Failed loading application!");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString(), "Error!");
                        }
                    }
                }
                formPatientID.Dispose();
            }
        }
    }
}
