using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LookAndPlayForm;
using LookAndPlayForm.TestPersuit;

namespace StimuloPersuitHorizontal
{
    public partial class StimuloPersuit : Form
    {
        StimuloPersuitSetup stimuloPersuitSetup;
        bool screenDimensionsOk, dotSizeOk;
        private int xCoordinate, yCoordinate;
        //EyeXWinForm _ControlFormEyeX;
        double tiempoSegundos;


        public bool closeApp { get; set; }

        public StimuloPersuit()
        {
            InitializeComponent();

            closeApp = true;
            //_ControlFormEyeX = ControlForm;


            stimuloPersuitSetup = new StimuloPersuitSetup();

            timerMoveDot.Interval = stimuloPersuitSetup.intervalMseg;
            timerMoveDot.Tick += timerMoveDot_Tick;

            screenDimensionsOk = setPictureBoxLocation();
            dotSizeOk = setPictureBoxsize();
        }









        private bool setPictureBoxsize()
        {
            if (stimuloPersuitSetup.dotDiameterPixelsX > 1 && stimuloPersuitSetup.dotDiameterPixelsY > 1)
            {
                pictureBoxDotStimulus.Size = new Size(stimuloPersuitSetup.dotDiameterPixelsX, stimuloPersuitSetup.dotDiameterPixelsY);
                return true;
            }
            else
                return false;
        }

        private bool setPictureBoxLocation()
        {
            if (stimuloPersuitSetup.offset_izquierda > 0 && stimuloPersuitSetup.offset_arriba > 0)
            {
                pictureBoxDotStimulus.Location = new Point(stimuloPersuitSetup.offset_izquierda - (stimuloPersuitSetup.dotDiameterPixelsX / 2), stimuloPersuitSetup.offset_arriba - (stimuloPersuitSetup.dotDiameterPixelsX / 2));
                return true;
            }
            else
                return false;
        }













        private void StimuloPersuit_Shown(object sender, EventArgs e)
        {
            if (screenDimensionsOk && dotSizeOk)
            {
                DialogResult dialogResult = MessageBox.Show("Start persuit", "Are you ready?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Hide();
                    //_ControlFormEyeX.toogleSaveEyeTrackerDataValue();
                    //_ControlFormEyeX.se_grabaron_datos = true;
                    Program.eyeTrackingEngine.toogleSaveEyeTrackerDataValue();
                    Program.datosCompartidos.se_grabaron_datos = true;
                    timerMoveDot.Enabled = true;
                    tiempoSegundos = 0;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //_ControlFormEyeX.se_grabaron_datos = false;
                    Program.datosCompartidos.se_grabaron_datos = false;
                    end_protocol();
                }
            }
            else
            {
                if (!screenDimensionsOk)
                {
                    MessageBox.Show("The test can not be performed. The screen is too small.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (!dotSizeOk)
                {
                    MessageBox.Show("The test can not be performed. The stimulus dot is too small.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.Close();
            }
        }













        void timerMoveDot_Tick(object sender, EventArgs e)
        {

            xCoordinate = stimuloPersuitSetup.offset_izquierda + (int)((double)stimuloPersuitSetup.amplitudMovimientoPixels * (((Math.Sin(rad2Deg(stimuloPersuitSetup.velocidad * tiempoSegundos + 270))) * 0.5) + 0.5));
            yCoordinate = Screen.PrimaryScreen.Bounds.Size.Height / 2;
            pictureBoxDotStimulus.Refresh();
            

            stimuloPersuitSetup.stimulusDataList.Add(new DataPointPersuit(xCoordinate, yCoordinate, tiempoSegundos));

            if (tiempoSegundos < (double)(stimuloPersuitSetup.numero_vueltas * stimuloPersuitSetup.tiempo_1_vuelta))
            {
                tiempoSegundos += (double)stimuloPersuitSetup.intervalMseg / 1000.0;
            }
            else
            {
                timerMoveDot.Enabled = false;
                end_protocol();
            }

        }

        private double rad2Deg(double deg)
        {
            return (Math.PI / 180 * deg);
        }














        
        
                





        private void pictureBoxDotStimulus_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxDotStimulus.Location = new Point(xCoordinate - (stimuloPersuitSetup.dotDiameterPixelsX / 2), yCoordinate - (stimuloPersuitSetup.dotDiameterPixelsX / 2));
        }

        private void end_protocol()
        {            
            Program.datosCompartidos.LogEyeTrackerData.AddTargetTraceEyeX(new TargetPosSize.Target(), true);        
            //_ControlFormEyeX.toogleSaveEyeTrackerDataValue();
            Program.eyeTrackingEngine.toogleSaveEyeTrackerDataValue();
            stimuloPersuitSetup.SavePersuitData();

            this.BeginInvoke((Action)(() =>
                {
                    Cursor.Show();
                    closeApp = false;
                    this.Close();
                }));
        }
        
        //final del test por teclado. no se guardan datos
        private void StimuloPersuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            end_protocol();
        }
        
    }
}
