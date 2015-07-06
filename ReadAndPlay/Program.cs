//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

using System;
using System.Windows.Forms;
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
            
            //switch(settings.eyetrackerSelected)
            //{
            //    case eyetrackertype.eyetribe:
            //        // EYETRIBE
            //        Application.Run(new EyeTribeWinForm());
            //        break;
                //case eyetrackertype.tobii:
                    //TOBII

            FormUserID formUserID = new FormUserID();
            
            if (formUserID.ShowDialog() == DialogResult.OK)
            {
                formUserID.updateCsv();//almacena los datos del usuario al pasar el formulario
                datosCompartidos.activeUser = formUserID.userDataSelected.user_id;

                ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();

                //if (formularioConsentimiento.ShowDialog() == DialogResult.OK)
                //{

                //si es no es un usuario nuevo o 
                //(si es un usuario nuevo y acepta las clausulas)
                if (    !formUserID.newUser ||
                        (formUserID.newUser && formularioConsentimiento.ShowDialog() == DialogResult.OK))
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

            formUserID.Dispose();
            
        }
    }
}
