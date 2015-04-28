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
        TargetPosSize _TargetPosSize;
        TargetPosSize.Target _TargetPS;
        Dwell clickDwell;
        LogEyeTracker.eyetrackerDataEyeX generalDataEyeX;
        LogTest logTest;
        PolledDevices.PolledMouse _mouse;
        LogMouse mouseRecord;



    


        public Game1(EyeXWinForm ControlForm)
        {
            InitializeComponent();

            _ControlFormEyeX = ControlForm;
            _datosCompartidos = LookAndPlayForm.Program.datosCompartidos;
            _TargetPosSize = new TargetPosSize();
            
            Point initStimulusPosition = _TargetPosSize.generateInitTargetPosition();
            
            pictureBoxStimulus.Location = initStimulusPosition;
            pictureBoxStimulus.Size = new Size(_TargetPosSize.initTargetSize);
            loadSetImage2PictureBox();

            //save init target position and size            
            _TargetPS.position = pictureBoxStimulus.Location;
            _TargetPS.size = _TargetPosSize.initTargetSize;

            //selectClicType();
            selectPointerControlType();

            generalDataEyeX = new LogEyeTracker.eyetrackerDataEyeX();
            logTest = new LogTest();
        }

        private void loadSetImage2PictureBox()
        {

            if (Varios.ImageDictionary.Image2ReadDictionary.ContainsKey(settings.image2read))
            {
                pictureBoxStimulus.Image = Varios.ImageDictionary.Image2ReadDictionary[settings.image2read].imagen;
                Console.WriteLine("settings.image2read:" + settings.image2read + " encontrada");
            }
            else
            {
                Console.WriteLine("settings.image2read:" + settings.image2read + " NO encontrada");
            }
        }

        private void selectPointerControlType()
        {
            switch (settings.pointercontroltypeSelected)
            {
                case pointercontroltype.eyetracker:
                    break;
                case pointercontroltype.mouse:
                    _mouse = new PolledMouse(this);
                    _mouse.MouseMoveEvent += new PolledMouseEventHandler(OnMouseMove);
                    mouseRecord = new LogMouse();
                    break;
                default:
                    break;
            }
        }
        
        //private void selectClicType()
        //{
        //    switch (settings.clictypeSelected)
        //    {
        //        case clictype.dwell:
        //            clickDwell = new Dwell(LookAndPlayForm.Program.datosCompartidos);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void OnMouseMove(object sender, PolledMouseEventArgs e)
        {
            //almacenar movimiento del mouse e.ScreenPos.X, e.ScreenPos.Y
            mouseRecord.addMouseData2List(new PointI(e.ScreenPos.X, e.ScreenPos.Y));
        }










        // Before starting the game a confirmation is expected
        private void Game1_Load(object sender, EventArgs e)
        {
            //if(headTracker.startCollectingData() == false)
            //{
            //    MessageBox.Show("Headtracker not connected");
            //}

            if (MessageBox.Show("Starting test 1?", "Are you ready?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes                

                if (!settings.cursorVisibleGame)
                    Cursor.Hide();

                
                if(settings.pointercontroltypeSelected == pointercontroltype.eyetracker)
                    //switch(settings.eyetrackerSelected)
                    //{
                    //    case eyetrackertype.tobii:
                            _ControlFormEyeX.toogleGameStatus(true);
                    //        break;
                    //    case eyetrackertype.eyetribe:
                    //        _ControlFormEyeTribe.toogleGameStatus(true);
                    //        break;
                    //    default:
                    //        break;
                    //}
                else
                    //switch (settings.eyetrackerSelected)
                    //{
                    //    case eyetrackertype.tobii:
                            _ControlFormEyeX.toogleGameStatus(false);
                    //        break;
                    //    case eyetrackertype.eyetribe:
                    //        _ControlFormEyeTribe.toogleGameStatus(false);
                    //        break;
                    //    default:
                    //        break;
                    //}                    

                if (settings.pointercontroltypeSelected == pointercontroltype.mouse)
                {
                    mouseRecord.startCollectingData();
                    _mouse.Acquire();
                }

                //if (settings.clictypeSelected == clictype.dwell)
                //    clickDwell.startDwelling();
            }
            else// user clicked no
                this.Close();
        }

        private void Game1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!settings.cursorVisibleGame)
                Cursor.Show();
        }



        
     
     
        // Finalizacion de Game1

        /// <summary>
        /// The game or task 1 has a exit button. When is pressed: (1) stop the eyetracker and (2) save the captured data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            _datosCompartidos.LogData.AddTargetTraceEyeX(_TargetPS, true);
            end_protocol();
        }

        /// <summary>
        /// Para el Eyetracker y Pregunta si quiere almacenar los datos
        /// </summary>
        private void stop_protocol()
        {
            if (settings.pointercontroltypeSelected == pointercontroltype.eyetracker)
            {
                _ControlFormEyeX.toogleGameStatus();
            }

            if (settings.pointercontroltypeSelected == pointercontroltype.mouse)
            {
                _mouse.Release();
                mouseRecord.stopCollectingData();
            }
            
        }

        private void save_protocol()
        {
                logTest.testData.screen_Height = Screen.PrimaryScreen.Bounds.Height;
                logTest.testData.screen_Width = Screen.PrimaryScreen.Bounds.Width;
                logTest.testData.date = String.Format("{0:u}", DateTime.Now);//yyyy'-'MM'-'dd HH':'mm':'ss'Z'
                logTest.testData.eyetracker = _datosCompartidos.EyeTrackerInfo;
                logTest.testData.pointer_type = settings.pointercontroltypeSelected.ToString();
                logTest.testData.blink_time_min = 0;
                logTest.testData.blink_time_max = 0;
                logTest.testData.dwell_area = settings.DwellArea;
                logTest.testData.dwell_time = settings.DwellTime;
                logTest.testData.dewll_time_latency = settings.DwellLatency;
                logTest.testData.filter_type = settings.filtertypeSelected.ToString();
                logTest.testData.calibration_error_left_px = _datosCompartidos.meanCalibrationErrorLeftPx;
                logTest.testData.calibration_error_right_px = _datosCompartidos.meanCalibrationErrorRightPx;
                logTest.testData.image2read = settings.image2read;

                _datosCompartidos.LogData.saveData2File(generalDataEyeX);
                _datosCompartidos.LogData.ClearList();

                logTest.saveData2File();

                _datosCompartidos.updateCsv = true;
                //FixDetector.FixDetector detectorFijaciones = new FixDetector.FixDetector();
        }

        private void end_protocol()
        {
            stop_protocol();
            //playEndSound();
            save_protocol();
            Close();
        }

               
    }
}
