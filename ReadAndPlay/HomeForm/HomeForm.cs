using System;
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
        HomeFormEngine homeFormEngine;
        ClassLogData data2Log;
        bool loginForms;




        public HomeForm(HomeFormEngine homeFormEngine)
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.homeFormEngine = homeFormEngine;

            data2Log = new ClassLogData();
            data2Log.Date = DateTime.Now.ToString("dd/MM/yyyy");
            data2Log.Time_start = DateTime.Now.ToString("HH:mm:ss");
            loginForms = true;
        }










        //review test
        private void buttonReviewTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                string selectedPath = selectionOfFolder();

                if(string.IsNullOrEmpty(selectedPath))
                {
                    this.Show();
                    return;
                }

                if (!directorioValido(selectedPath))
                {
                    this.Show();
                    return;
                }
                   
                testType testType = checkTipoTest(selectedPath);

                switch (testType)
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
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                this.Close();
            }
        }

        #region review test methods

        private string selectionOfFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedPath = fbd.SelectedPath;
                return selectedPath;
            }
            else
                return null;
        }

        private bool directorioValido(string path)
        {
            string fileTestData = @"\testData.json";
            string fileEyeTrackerData = @"\eyetrackerData.json";

            if (File.Exists(path + fileTestData) && File.Exists(path + fileEyeTrackerData))
            {
                return true; ;
            }
            else
            {
                MessageBox.Show("Missing some data files in the selected directory. Please select another directory. ", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                MessageBox.Show("Missing testData.json data files in the selected directory", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion











        //new test
        private void buttonNewTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                if (loginForms)
                {
                    //tester search
                    TesterLoginForm fTester = new TesterLoginForm();
                    fTester.ShowDialog();

                    if (fTester.closeApp)
                    {
                        fTester.Dispose();
                        fTester = null;
                        this.Close();
                        return;
                    }

                    aws_class_engine.UpdateTestersFile(Program.datosCompartidos.institutionName);
                    data2Log.Tester = fTester.testerDataSelected.tester_name;
                    fTester.Dispose();
                    fTester = null;

                    //patient search
                    PatientLoginForm patientLoginForm = new PatientLoginForm();
                    patientLoginForm.ShowDialog();

                    if (patientLoginForm.closeApp)
                    {
                        patientLoginForm.Dispose();
                        patientLoginForm = null;
                        this.Close();
                        return;
                    }

                    if (patientLoginForm.newUser)
                    {
                        //nuevo patient
                        ConsentForm.consentForm formularioConsentimiento = new ConsentForm.consentForm();
                        formularioConsentimiento.ShowDialog();

                        if (formularioConsentimiento.closeApp)
                        {
                            patientLoginForm.Dispose();
                            patientLoginForm = null;
                            formularioConsentimiento.Dispose();
                            formularioConsentimiento = null;
                            this.Close();//no acepto las condiciones
                            return;
                        }
                        else
                        {                //si acepto las condiciones
                            formularioConsentimiento.Dispose();
                            formularioConsentimiento = null;
                        }
                    }

                    aws_class_engine.UpdateUsersFile(Program.datosCompartidos.institutionName);
                    data2Log.Patient = patientLoginForm.patientDataSelected.user_name;
                    Program.datosCompartidos.activeUser = patientLoginForm.patientDataSelected.user_id;

                    patientLoginForm.Dispose();
                    patientLoginForm = null;
                }







                //user position
                Program.eyeTrackingEngine = new EyeTrackingEngine();
                EyeXWinForm eyeXWinForm = new EyeXWinForm(Program.eyeTrackingEngine);
                eyeXWinForm.ShowDialog();

                if (eyeXWinForm.closeApp)
                {
                    releaseEyeTracker();
                    eyeXWinForm.Dispose();
                    eyeXWinForm = null;
                    this.Close();
                    return;
                }

                eyeXWinForm.Dispose();
                eyeXWinForm = null;

                //test selection
                FormSelectionTest selectionTestForm = new FormSelectionTest();
                selectionTestForm.ShowDialog();

                if (selectionTestForm.closeApp)
                {
                    releaseEyeTracker();
                    selectionTestForm.Dispose();
                    selectionTestForm = null;
                    this.Close();
                    return;
                }

                selectionTestForm.Dispose();
                selectionTestForm = null;

                switch (Program.datosCompartidos.testSelected)
                {
                    case testType.reading:

                        //configuration reading test
                        ConfigurationReadingForm.ConfigurationReadingForm configurationReadingForm = new ConfigurationReadingForm.ConfigurationReadingForm();
                        configurationReadingForm.ShowDialog();

                        if (configurationReadingForm.closeApp)
                        {
                            releaseEyeTracker();
                            configurationReadingForm.Dispose();
                            configurationReadingForm = null;
                            this.Close();
                            return;
                        }

                        configurationReadingForm.Dispose();
                        configurationReadingForm = null;

                        //instruction reading test
                        InstructionReadingForm.InstructionReadingForm instructionReadingForm = new InstructionReadingForm.InstructionReadingForm();
                        instructionReadingForm.ShowDialog();

                        if (instructionReadingForm.closeApp)
                        {
                            releaseEyeTracker();
                            instructionReadingForm.Dispose();
                            instructionReadingForm = null;
                            this.Close();
                            return;
                        }

                        instructionReadingForm.Dispose();
                        instructionReadingForm = null;

                        //test reading
                        Game1 game1 = new Game1();
                        game1.ShowDialog();

                        if (game1.closeApp)
                        {
                            game1.Dispose();
                            game1 = null;
                            releaseEyeTracker();
                            this.Close();
                            return;
                        }

                        game1.Dispose();
                        game1 = null;
                        releaseEyeTracker();

                        if (Program.datosCompartidos.no_se_cancelo_el_test)
                        {
                            saveData();

                            //review reading test
                            Resumen.Resumen resumenGame1 = new Resumen.Resumen(true, true, null);
                            resumenGame1.ShowDialog();

                            if (resumenGame1.closeApp)
                            {
                                resumenGame1.Dispose();
                                resumenGame1 = null;
                                this.Close();
                            }
                            else
                            {
                                if (resumenGame1.toHome)
                                {
                                    loginForms = true;
                                    resumenGame1.Dispose();
                                    resumenGame1 = null;
                                    this.Show();
                                }
                                else
                                {
                                    loginForms = false;
                                    resumenGame1.Dispose();
                                    resumenGame1 = null;
                                    buttonNewTest_Click(this, EventArgs.Empty);
                                }
                            }
                        }
                        else
                        {
                            this.Show();
                        }
                        break;

                    case testType.persuit:

                        //instruction pursuit test
                        InstructionPursuitForm.InstructionPursuit instructionPursuit = new InstructionPursuitForm.InstructionPursuit();
                        instructionPursuit.ShowDialog();

                        if (instructionPursuit.closeApp)
                        {
                            releaseEyeTracker();
                            instructionPursuit.Dispose();
                            instructionPursuit = null;
                            this.Close();
                            return;
                        }

                        instructionPursuit.Dispose();
                        instructionPursuit = null;

                        //test pursuit
                        StimuloPersuitHorizontal.StimuloPersuit persuit = new StimuloPersuitHorizontal.StimuloPersuit();
                        persuit.ShowDialog();

                        if (persuit.closeApp)
                        {
                            persuit.Dispose();
                            persuit = null;
                            releaseEyeTracker();
                            this.Close();
                            return;
                        }

                        persuit.Dispose();
                        persuit = null;
                        releaseEyeTracker();

                        if (Program.datosCompartidos.no_se_cancelo_el_test)
                        {
                            saveData();

                            //review pursuit test
                            ReviewPersuit.ReviewPersuit reviewPersuit = new ReviewPersuit.ReviewPersuit(true, true, null);
                            reviewPersuit.ShowDialog();

                            if (reviewPersuit.closeApp)
                            {
                                reviewPersuit.Dispose();
                                reviewPersuit = null;
                                this.Close();
                            }
                            else
                            {
                                if (reviewPersuit.toHome)
                                {
                                    loginForms = true;
                                    reviewPersuit.Dispose();
                                    reviewPersuit = null;
                                    this.Show();
                                }
                                else
                                {
                                    loginForms = false;
                                    reviewPersuit.Dispose();
                                    reviewPersuit = null;
                                    buttonNewTest_Click(this, EventArgs.Empty);
                                }
                            }
                        }
                        else
                        {
                            this.Show();
                        }
                        break;
                    default:
                        releaseEyeTracker();
                        MessageBox.Show("Error. Unknow test.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Mr. Patch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                this.Close();
            }
        }


        #region new test methods

        private void releaseEyeTracker()
        {
            Program.eyeTrackingEngine.Dispose();
            Program.eyeTrackingEngine = null;
        }

        private void saveData()
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

        #endregion



        //cerrando app      
        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateLogFile();
            aws_class_engine.UpdateErrorFile(Program.datosCompartidos.institutionName);
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
    }
}
