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
        StimuloPersuitEngine persuitEngine;
        bool screenDimensionsOk, dotSizeOk;
        private int _y, _x;
        EyeXWinForm _ControlFormEyeX;

        public StimuloPersuit(EyeXWinForm ControlForm)
        {
            InitializeComponent();

            _ControlFormEyeX = ControlForm;


            stimuloPersuitSetup = new StimuloPersuitSetup();
            persuitEngine = new StimuloPersuitEngine(stimuloPersuitSetup);
            persuitEngine.newCoordinate += persuitEngine_newCoordinate;
            persuitEngine.persuitEnd += persuitEngine_persuitEnd;

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
                DialogResult dialogResult = MessageBox.Show("Start persuit", "Are you ready?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Hide();
                    _ControlFormEyeX.toogleSaveEyeTrackerDataValue();
                    _ControlFormEyeX.se_grabaron_datos = true;
                    persuitEngine.persuitStart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    _ControlFormEyeX.se_grabaron_datos = false;
                    end_protocol();
                }
            }
            else
            {
                if (!screenDimensionsOk)
                {
                    MessageBox.Show("The test can not be performed. The screen is too small.");
                }
                if (!dotSizeOk)
                {
                    MessageBox.Show("The test can not be performed. The stimulus dot is too small.");
                }

                this.Close();
            }
        }
        
        
        

        //new x, y data from engine
        void persuitEngine_newCoordinate(int xCoordinate, int yCoordinate)
        {
            _x = xCoordinate;
            _y = yCoordinate;
            pictureBoxDotStimulus.Invalidate();
        }

        private void pictureBoxDotStimulus_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxDotStimulus.Location = new Point(_x - (stimuloPersuitSetup.dotDiameterPixelsX / 2), _y - (stimuloPersuitSetup.dotDiameterPixelsX / 2));
        }





        //final del test
        void persuitEngine_persuitEnd(object sender, EventArgs e)
        {
            end_protocol();
        }

        private void end_protocol()
        {            
            persuitEngine.newCoordinate -= persuitEngine_newCoordinate;
            persuitEngine.persuitEnd -= persuitEngine_persuitEnd;

            Program.datosCompartidos.LogEyeTrackerData.AddTargetTraceEyeX(new TargetPosSize.Target(), true);        
            _ControlFormEyeX.toogleSaveEyeTrackerDataValue();
            stimuloPersuitSetup.SavePersuitData();

            this.BeginInvoke((Action)(() =>
                {
                    Cursor.Show();
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
