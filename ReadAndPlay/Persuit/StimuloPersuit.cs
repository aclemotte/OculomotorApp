using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StimuloPersuitHorizontal
{
    public partial class StimuloPersuit : Form
    {
        StimuloPersuitEngine persuitEngine;
        bool screenDimensionsOk, dotSizeOk;
        private int _y;
        private int _x;


        public StimuloPersuit()
        {
            InitializeComponent();


            persuitEngine = new StimuloPersuitEngine(this);
            persuitEngine.newCoordinate += persuitEngine_newCoordinate;
            persuitEngine.persuitEnd += persuitEngine_persuitEnd;

            screenDimensionsOk = setPictureBoxFeattures();
            dotSizeOk = setPictureBoxsize();
        }

        private bool setPictureBoxsize()
        {
            if(persuitEngine.dotSizeX > 1 && persuitEngine.dotSizeY > 1)
            {
                pictureBoxDotStimulus.Size = new Size(persuitEngine.dotSizeX, persuitEngine.dotSizeY);
                return true;
            }
            else
                return false;
        }

        private bool setPictureBoxFeattures()
        {
            if (persuitEngine.offset_izquierda > 0 && persuitEngine.offset_arriba > 0)
            {
                pictureBoxDotStimulus.Location = new Point(persuitEngine.offset_izquierda, persuitEngine.offset_arriba);
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
                    persuitEngine.persuitStart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    closeProtocol();
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
        void persuitEngine_newCoordinate(int xCoordinate)
        {

            _x = xCoordinate;
            _y = Screen.PrimaryScreen.Bounds.Size.Height / 2;

            pictureBoxDotStimulus.Invalidate();
        }

        private void pictureBoxDotStimulus_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxDotStimulus.Location = new Point(_x, _y);
        }





        //final del test
        void persuitEngine_persuitEnd(object sender, EventArgs e)
        {
            closeProtocol();
        }

        private void closeProtocol()
        {            
            persuitEngine.newCoordinate -= persuitEngine_newCoordinate;
            persuitEngine.persuitEnd -= persuitEngine_persuitEnd;
            
            this.BeginInvoke((Action)(() =>
                {
                    Cursor.Show();
                    this.Close();
                }));
        }




        //final del test por teclado
        private void StimuloPersuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            closeProtocol();
            this.Close();
        }
        
    }
}
