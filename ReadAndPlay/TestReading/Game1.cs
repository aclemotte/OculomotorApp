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
        //EyeXWinForm _ControlFormEyeX;
        TargetPosSize.Target _TargetPS;

        public bool closeApp { get; set; }

        public Game1()
        {
            InitializeComponent();

            //_ControlFormEyeX = ControlForm;

            setPictureBoxStimulus();           
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
            location.X = (int)((double)(Screen.PrimaryScreen.Bounds.Width - pictureBoxStimulus.Size.Width) * (double)0.5);
            location.Y = (int)((double)(Screen.PrimaryScreen.Bounds.Height - pictureBoxStimulus.Size.Height) * (double)0.5);
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
        
       
              


        // Before starting the game a confirmation is expected
        private void Game1_Load(object sender, EventArgs e)
        {

            if (MessageBox.Show("Start test 1?", "Are you ready?!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes                
                Cursor.Hide();
                //_ControlFormEyeX.toogleSaveEyeTrackerDataValue();
                //_ControlFormEyeX.se_grabaron_datos = true;
                Program.eyeTrackingEngine.toogleSaveEyeTrackerDataValue();
                Program.datosCompartidos.no_se_cancelo_el_test = true;
            }
            else// user clicked no
            {
                //_ControlFormEyeX.se_grabaron_datos = false;
                Program.datosCompartidos.no_se_cancelo_el_test = false;
                this.Close();
            }
        }

        //Finalizacion de Game1
        private void Game1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.datosCompartidos.LogEyeTrackerData.AddTargetTraceEyeX(_TargetPS, true);
            end_protocol();
        }


        private void end_protocol()
        {
            //_ControlFormEyeX.toogleSaveEyeTrackerDataValue();
            Program.eyeTrackingEngine.toogleSaveEyeTrackerDataValue();
            this.Close();
        }


        private void Game1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Show();
        }
    }
}
