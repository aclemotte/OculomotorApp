using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.LogData;
using LookAndPlayForm.SelectTest;
using LookAndPlayForm.TesterID;

namespace LookAndPlayForm.InitialForm
{
    public partial class HomeForm : Form
    {
        HomeFormEngine initial_engine;

        ClassLogData data2Log;



            
        public HomeForm(HomeFormEngine initial_engine)
        {
            InitializeComponent();

            this.initial_engine = initial_engine;

            data2Log = new ClassLogData();
            data2Log.Date = DateTime.Now.ToString("dd/MM/yyyy");
            data2Log.Time_start = DateTime.Now.ToString("HH:mm:ss");
        }

        private void buttonReviewTest_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            this.Hide();

            tester_class_engine tester_engine = new tester_class_engine();
            FormTesterID fTester = new FormTesterID(tester_engine);
            fTester.ShowDialog();

            if(fTester.closeApp)
                this.Close();
            else
            {

                fTester.updateCsv();
                aws_class_engine.UpdateTestersFile(Program.datosCompartidos.institutionName);
                data2Log.Tester = fTester.testerDataSelected.tester_name;
                fTester.Dispose();
                fTester = null;

                FormPatientID formPatientID = new FormPatientID(Program.datosCompartidos.institutionName);
                formPatientID.ShowDialog();

                if (formPatientID.closeApp)
                    this.Close();
                else
                {
                    formPatientID.updateCsv();//almacena los datos del usuario al pasar el formulario
                    aws_class_engine.UpdateUsersFile(Program.datosCompartidos.institutionName);
                    data2Log.Patient = formPatientID.patientDataSelected.user_name;
                    Program.datosCompartidos.activeUser = formPatientID.patientDataSelected.user_id;

                    //ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();

                    formPatientID.Dispose();
                    formPatientID = null;

                    FormSelectionTest selectionTestForm = new FormSelectionTest();
                    selectionTestForm.ShowDialog();

                    //cambiar: primero user position dsp seleccion del test
                    if (selectionTestForm.closeApp)
                    {
                        this.Close();
                    }
                    else
                    {
                        selectionTestForm.Dispose();
                        selectionTestForm = null;

                        using (Program.eyeTrackingEngine = new EyeTrackingEngine())
                        {

                            EyeXWinForm eyeXWinForm = new EyeXWinForm(Program.eyeTrackingEngine);
                            eyeXWinForm.ShowDialog();

                            if (eyeXWinForm.closeApp)
                                this.Close();
                            else
                            {
                                eyeXWinForm.Dispose();

                                data2Log.Time_end = DateTime.Now.ToString("HH:mm:ss");
                                data2Log.testDone = Program.datosCompartidos.testSelected.ToString();
                                data2Log.number_of_screening_done = Program.datosCompartidos.number_of_screening_done;
                                data2Log.AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                                ClassLogEngine.Log(data2Log);

                                aws_class_engine.UpdateLogFile(Program.datosCompartidos.institutionName);

                                this.Show();
                            }
                        }                        
                    }
                }
            }
        }
    }
}
