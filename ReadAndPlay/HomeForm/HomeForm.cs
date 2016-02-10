using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LookAndPlayForm.BackupClass;
using LookAndPlayForm.LogData;
using LookAndPlayForm.SelectTest;
using LookAndPlayForm.TesterID;
using Newtonsoft.Json;
using LookAndPlayForm.Utility;
using LookAndPlayForm.Review;

namespace LookAndPlayForm.InitialForm
{
    public partial class HomeForm : Form
    {
        ClassLogData data2Log;
        bool loginForms;


        public HomeForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.languageSelected);
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            data2Log = new ClassLogData();
            DateTime now = DateTime.Now;
            data2Log.Date = now.ToString("dd/MM/yyyy");
            data2Log.Time_start = now.ToString("HH:mm:ss");
            loginForms = true;
        }

        private void buttonReviewTest_Click(object sender, EventArgs e)
        {
            try
            {
                //throw new NotImplementedException();
                this.Hide();

                SearchTestForm searchTest = new SearchTestForm();
                if (searchTest.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(searchTest.EyeTrackerData) || searchTest.TestData == null)
                        throw new ArgumentNullException("No eye tracker or test data was found");

                    switch (searchTest.TestType)
                    {
                        case LookAndPlayForm.TestType.reading:

                            //if (string.IsNullOrWhiteSpace(searchTest.FixData))
                                //throw new ArgumentNullException("No reading data was found");

                            Resumen.Resumen resumenGame1 = new Resumen.Resumen(false, true, searchTest.FixData, searchTest.EyeTrackerData, searchTest.TestData);
                            resumenGame1.ShowDialog();

                            if (resumenGame1.closeApp)
                                this.Close();
                            else
                                this.Show();
                            break;
                        case LookAndPlayForm.TestType.persuit:

                            if (string.IsNullOrWhiteSpace(searchTest.PursuitData))
                                throw new ArgumentNullException("No pursuit data was found");

                            ReviewPersuit.ReviewPersuit reviewPersuit = new ReviewPersuit.ReviewPersuit(false, true, searchTest.PursuitData, searchTest.EyeTrackerData, searchTest.TestData);
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
                else
                    this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.GetBaseException().ToString()), "Review Test Error");
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                this.Show();
                //this.Close();
            }
        }
        
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

                    //aws_class_engine.UpdateDataBaseFile(Program.datosCompartidos.institutionName);
                    data2Log.Tester = fTester.testerDataSelected.tester_name;
                    Program.datosCompartidos.activeTester = fTester.testerDataSelected.tester_id;
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

                    //aws_class_engine.UpdateDataBaseFile(Program.datosCompartidos.institutionName);
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
                    case TestType.reading:

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
                            Resumen.Resumen reviewReading = new Resumen.Resumen(true, true, null, null, null);
                            reviewReading.ShowDialog();

                            if (reviewReading.closeApp)
                            {
                                reviewReading.Dispose();
                                reviewReading = null;
                                this.Close();
                            }
                            else
                            {
                                if (reviewReading.toHome)
                                {
                                    loginForms = true;
                                    reviewReading.Dispose();
                                    reviewReading = null;
                                    this.Show();
                                }
                                else
                                {
                                    loginForms = false;
                                    reviewReading.Dispose();
                                    reviewReading = null;
                                    buttonNewTest_Click(this, EventArgs.Empty);
                                }
                            }
                        }
                        else
                        {
                            this.Show();
                        }
                        break;

                    case TestType.persuit:

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
                            ReviewPersuit.ReviewPersuit reviewPersuit = new ReviewPersuit.ReviewPersuit(true, true, null, null, null);
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
            aws_data.FileToUpload = CData.DataFolder;
            //if ()

            aws_class_engine.BackupTest(aws_data);

            Program.datosCompartidos.number_of_screening_done++;
        }

        #endregion



        //cerrando app      
        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateLogFile();
            aws_class_engine.UpdateErrorFile(Program.datosCompartidos.institutionName);
            aws_class_engine.UpdateDataBaseFile(Program.datosCompartidos.institutionName);
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

        private void pictureBoxIngles_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en", this);
        }

        private void pictureBoxEspanhol_Click(object sender, EventArgs e)
        {
            ChangeLanguage("es", this);
        }

        private void pictureBoxAleman_Click(object sender, EventArgs e)
        {

        }

        private void ChangeLanguage(string lang, Form form)
        {
            Properties.Settings.Default.languageSelected = lang;
            Properties.Settings.Default.Save();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            System.Resources.ResourceManager resourcesMan = new System.Resources.ResourceManager(form.GetType());
            form.Text = resourcesMan.GetString("$this.Text", new CultureInfo(lang));

            foreach (Control c in this.Controls)
            {
                if (c.Name != "labelVersion")
                {
                    ComponentResourceManager compResourcesMan = new ComponentResourceManager(this.GetType());
                    compResourcesMan.ApplyResources(c, c.Name, new CultureInfo(lang));
                }
            }
        }
    }
}
