using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using PolledDevices;

namespace LookAndPlayForm
{
    public partial class Game1 : Form
    {
        EyeXWinForm _ControlFormEyeX;
        sharedData _datosCompartidos;
        TargetPosSize.Target _TargetPS;
        LogEyeTracker.eyetrackerDataEyeX generalDataEyeX;
        LogTest logTest;



    


        public Game1(EyeXWinForm ControlForm)
        {
            InitializeComponent();

            _ControlFormEyeX = ControlForm;
            _datosCompartidos = LookAndPlayForm.Program.datosCompartidos;

            setPictureBoxStimulus();           

            //para avisar a _ControlFormEyeX si se cancelo la tarea (cuando se pregunta Are you ready?)
            _ControlFormEyeX.se_grabaron_datos = false;

            generalDataEyeX = new LogEyeTracker.eyetrackerDataEyeX();
            logTest = new LogTest();
        }

        private void setPictureBoxStimulus()
        {
            pictureBoxStimulus.Size = new Size(1000, 600);
            pictureBoxStimulus.Location = initPictureBoxLocation();
            pictureBoxStimulus.Image = getPictureBoxImage();

            //save init target position and size            
            _TargetPS.position = pictureBoxStimulus.Location;
            _TargetPS.size = new Point(pictureBoxStimulus.Size.Width, pictureBoxStimulus.Size.Height);
        }

        private Point initPictureBoxLocation()
        {
            Point location = new Point();
            location.X = (int)((double)(Program.datosCompartidos.monitorBounds.Width - pictureBoxStimulus.Size.Width) * (double)0.5);
            location.Y = (int)((double)(Program.datosCompartidos.monitorBounds.Height - pictureBoxStimulus.Size.Height) * (double)0.5);
            return location;
        }

        private Image getPictureBoxImage()
        {
            if (Varios.ImageDictionary.Image2ReadDictionary.ContainsKey(Program.datosCompartidos.image2read))
            {
                Console.WriteLine("Program.datosCompartidos.image2read:" + Program.datosCompartidos.image2read + " encontrada");
                return Varios.ImageDictionary.Image2ReadDictionary[Program.datosCompartidos.image2read].imagen;
            }
            else
            {
                Console.WriteLine("Program.datosCompartidos.image2read:" + Program.datosCompartidos.image2read + " NO encontrada");
                return null;
            }
        }
        



       



        
     
     

        private void end_protocol()
        {
            _ControlFormEyeX.toogleGameStatus();
            save_protocol();
            _ControlFormEyeX.se_grabaron_datos = true;
            this.Close();
        }

        private void save_protocol()
        {
            logTest.testData.screen_Height = Screen.PrimaryScreen.Bounds.Height;
            logTest.testData.screen_Width = Screen.PrimaryScreen.Bounds.Width;
            logTest.testData.date = String.Format("{0:u}", DateTime.Now);//yyyy'-'MM'-'dd HH':'mm':'ss'Z'
            logTest.testData.eyetracker = _datosCompartidos.EyeTrackerInfo;
            logTest.testData.pointer_type = "eyetracker"; // settings.pointercontroltypeSelected.ToString();
            logTest.testData.blink_time_min = 0;
            logTest.testData.blink_time_max = 0;
            logTest.testData.dwell_area = settings.DwellArea;
            logTest.testData.dwell_time = settings.DwellTime;
            logTest.testData.dewll_time_latency = settings.DwellLatency;
            logTest.testData.filter_type = settings.filtertypeSelected.ToString();
            logTest.testData.calibration_error_left_px = _datosCompartidos.meanCalibrationErrorLeftPx;
            logTest.testData.calibration_error_right_px = _datosCompartidos.meanCalibrationErrorRightPx;
            logTest.testData.image2read = Program.datosCompartidos.image2read;
            

            _datosCompartidos.LogData.saveData2File(generalDataEyeX);
            _datosCompartidos.LogData.ClearList();

            logTest.saveData2File();

            _datosCompartidos.updateCsv = true;
        }

        

        //vuelve a mostrar el cursor
        private void Game1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Show();
        }

       // Before starting the game a confirmation is expected
        private void Game1_Load(object sender, EventArgs e)
        {

            if (MessageBox.Show("Start test 1?", "Are you ready?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes                
                Cursor.Hide();
                _ControlFormEyeX.toogleGameStatus(true);
            }
            else// user clicked no
            {
                _ControlFormEyeX.se_grabaron_datos = false;
                this.Close();
            }
        }

        //Finalizacion de Game1
        private void Game1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _datosCompartidos.LogData.AddTargetTraceEyeX(_TargetPS, true);
            end_protocol();
        }

               
    }
}
