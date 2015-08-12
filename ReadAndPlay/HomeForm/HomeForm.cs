using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.SelectTest;
using LookAndPlayForm.TesterID;

namespace LookAndPlayForm.InitialForm
{
    public partial class HomeForm : Form
    {
        HomeFormEngine initial_engine;

            
        public HomeForm(HomeFormEngine initial_engine)
        {
            InitializeComponent();

            this.initial_engine = initial_engine;
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
                    Program.datosCompartidos.activeUser = formPatientID.patientDataSelected.user_id;

                    //ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();

                    formPatientID.Dispose();

                    FormSelectionTest selectionTestForm = new FormSelectionTest();
                    selectionTestForm.ShowDialog();

                    //cambiar: primero user position dsp seleccion del test
                    if (selectionTestForm.closeApp)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Show();
                    }
                }
            }
        }
    }
}
