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
        double tiempoSegundos;
        double tiempoDemoraInicial;
        bool iniciarMovimiento;

        public bool closeApp { get; set; }

        public StimuloPersuit()
        {
            InitializeComponent();

            closeApp = true;


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
                xCoordinate = stimuloPersuitSetup.offset_izquierda;
                yCoordinate = Screen.PrimaryScreen.Bounds.Size.Height / 2;
                pictureBoxDotStimulus.Refresh();
            
                return true;
            }
            else
                return false;
        }













        private void StimuloPersuit_Shown(object sender, EventArgs e)
        {
            if (screenDimensionsOk && dotSizeOk)
            {
                DialogResult dialogResult = MessageBox.Show("Start pursuit", "Are you ready?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Hide();
                    Program.eyeTrackingEngine.toogleSaveEyeTrackerDataValue();
                    Program.datosCompartidos.no_se_cancelo_el_test = true;

                    tiempoDemoraInicial = ((double)timerPausaInicial.Interval)/1000.0;
                    iniciarMovimiento = false;
                    timerPausaInicial.Enabled = true;
                    timerMoveDot.Enabled = true;
                    tiempoSegundos = 0;
                }
                else if (dialogResult == DialogResult.No)
                {
                    Program.datosCompartidos.no_se_cancelo_el_test = false;
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












        private void timerPausaInicial_Tick(object sender, EventArgs e)
        {
            timerPausaInicial.Enabled = false;
            iniciarMovimiento = true;
        }

        private void timerMoveDot_Tick(object sender, EventArgs e)
        {
            if (tiempoSegundos < (double)(stimuloPersuitSetup.numero_vueltas * stimuloPersuitSetup.segundos_1_vuelta))
            {
                tiempoSegundos += (double)stimuloPersuitSetup.intervalMseg / 1000.0;

                if (iniciarMovimiento)
                {
                    xCoordinate = stimuloPersuitSetup.offset_izquierda + (int)((double)stimuloPersuitSetup.amplitudMovimientoPixels * (((Math.Sin(rad2Deg(stimuloPersuitSetup.velocidad * (tiempoSegundos - tiempoDemoraInicial) + 270))) * 0.5) + 0.5));
                    yCoordinate = Screen.PrimaryScreen.Bounds.Size.Height / 2;
                    pictureBoxDotStimulus.Refresh();
                }

                stimuloPersuitSetup.stimulusDataList.Add(new DataPointPersuit(xCoordinate, yCoordinate, tiempoSegundos));

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
            Program.eyeTrackingEngine.toogleSaveEyeTrackerDataValue();
            stimuloPersuitSetup.SavePersuitData();

            this.BeginInvoke((Action)(() =>
                {
                    Cursor.Show();
                    closeApp = false;
                    this.Close();
                }));
        }
        
        //final del test por teclado.
        private void StimuloPersuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            end_protocol();
        }

        
    }
}
