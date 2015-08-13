﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.LogData;
using LookAndPlayForm.SelectTest;
using LookAndPlayForm.TesterID;
using Newtonsoft.Json;

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
            this.Hide();

            string selectedPath = selectionOfFolder();
            testType testType = checkTipoTest(selectedPath);

            switch(testType)
            {
                case LookAndPlayForm.testType.reading:

                    Resumen.Resumen resumenGame1 = new Resumen.Resumen(false, true, selectedPath);
                    resumenGame1.ShowDialog();

                    if (resumenGame1.closeApp)
                        this.Close();
                    else
                        this.Show();
                    break;
                case LookAndPlayForm.testType.persuit:

                    ReviewPersuit.ReviewPersuit reviewPersuit = new ReviewPersuit.ReviewPersuit(false, true, selectedPath);
                    reviewPersuit.ShowDialog();

                    if (reviewPersuit.closeApp)
                        this.Close();
                    else
                        this.Show();
                    break;
                default:
                    MessageBox.Show("Error. Test type not identified.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }

        private string selectionOfFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
            DialogResult result = fbd.ShowDialog();
            string selectedPath = fbd.SelectedPath;
            return selectedPath;
        }

        private string openTestDatajsonAndGetField(string path)
        {
            TestData1 testData;
            string file = @"\testData.json";

            if (File.Exists(path + file))
            {
                string json = File.ReadAllText(path + file);
                testData = JsonConvert.DeserializeObject<TestData1>(json);
                return testData.image2read;
            }
            else
            {
                MessageBox.Show("El archivo " + file + " no existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private testType checkTipoTest(string selectedPath)
        {
            string image2read = openTestDatajsonAndGetField(selectedPath);

            if (string.IsNullOrEmpty(image2read))
                return testType.persuit;
            else
                return testType.reading;//aca se puede ir mas y buscar la forma de saber si es silent o outloud
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
                    if(formPatientID.newUser)
                    {
                        ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();
                        formularioConsentimiento.ShowDialog();

                        if (formularioConsentimiento.closeApp)
                        {
                            this.Close();//no acepto las condiciones
                            return;
                        }
                        else
                        {                //si acepto las condiciones
                            formularioConsentimiento.Dispose();
                            formularioConsentimiento = null;
                        }
                    }

                    formPatientID.updateCsv();//almacena los datos del usuario al pasar el formulario
                    aws_class_engine.UpdateUsersFile(Program.datosCompartidos.institutionName);
                    data2Log.Patient = formPatientID.patientDataSelected.user_name;
                    Program.datosCompartidos.activeUser = formPatientID.patientDataSelected.user_id;

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
                                if (Program.eyeTrackingEngine.State == EyeTrackingState.Tracking)
                                {

                                    eyeXWinForm.Dispose();
                                    eyeXWinForm = null;

                                    switch (Program.datosCompartidos.testSelected)
                                    {
                                        case testType.reading:

                                            Game1 game1 = new Game1();
                                            game1.ShowDialog();

                                            if (game1.closeApp)
                                                this.Close();
                                            else
                                            {
                                                game1.Dispose();
                                                game1 = null;

                                                saveData();

                                                Resumen.Resumen resumenGame1 = new Resumen.Resumen(true, true, null);
                                                resumenGame1.ShowDialog();

                                                if (resumenGame1.closeApp)
                                                    this.Close();
                                                else
                                                    this.Show();
                                            }
                                            break;

                                        case testType.persuit:
                                            StimuloPersuitHorizontal.StimuloPersuit persuit = new StimuloPersuitHorizontal.StimuloPersuit();
                                            persuit.ShowDialog();

                                            if (persuit.closeApp)
                                                this.Close();
                                            else
                                            {
                                                persuit.Dispose();
                                                persuit = null;

                                                saveData();

                                                ReviewPersuit.ReviewPersuit reviewPersuit = new ReviewPersuit.ReviewPersuit(true, true, null);
                                                reviewPersuit.ShowDialog();

                                                if (reviewPersuit.closeApp)
                                                    this.Close();
                                                else
                                                    this.Show();
                                            }
                                            break;
                                        default:
                                            MessageBox.Show("Test unknow");
                                            break;
                                    }
                                }
                                else
                                    MessageBox.Show("Eye tracker not connected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }                        
                }                                    
            }
        }

        private void saveData()
        {
            //Show the resume window
            if (Program.datosCompartidos.se_grabaron_datos)
            {
                //datos del test
                Program.datosCompartidos.logTestData.saveData2File();

                //datos del tracker
                Program.datosCompartidos.LogEyeTrackerData.saveData2File();


                //subir los datos a la nube
                aws_class_data aws_data = new aws_class_data();
                aws_data.AwsS3FolderName = Program.datosCompartidos.institutionName;
                aws_data.FileToUpload = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                                            Program.datosCompartidos.startTimeTest +
                                            @"-us" + Program.datosCompartidos.activeUser;

                aws_class_engine.BackupTest(aws_data);

                Program.datosCompartidos.number_of_screening_done++;
            }
        }

        private void updateLogFile()
        {
            data2Log.Time_end = DateTime.Now.ToString("HH:mm:ss");
            data2Log.testDone = Program.datosCompartidos.testSelected.ToString();
            data2Log.number_of_screening_done = Program.datosCompartidos.number_of_screening_done;
            data2Log.AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            ClassLogEngine.Log(data2Log);

            aws_class_engine.UpdateLogFile(Program.datosCompartidos.institutionName);
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateLogFile();
        }
    }
}
