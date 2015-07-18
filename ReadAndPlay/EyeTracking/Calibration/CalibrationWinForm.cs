using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
//using TETCSharpClient;
//using TETCSharpClient.Data;

namespace LookAndPlayForm
{
    public partial class CalibrationWinForm : Form
    {

        struct calibrationPoint
        {
            public Tobii.Gaze.Core.Point2D positionEyeX;
            public Tobii.Gaze.Core.Point2D positionEyeTribe;
            public Bitmap imagen;
        };

        private enum tamanhoImagen
        {
            big,
            little
        };

        Queue<calibrationPoint> calibrationPoints = new Queue<calibrationPoint>();


        private const int preShowTime = 1000;
        private const int postShowTime = 500;
        
        private int calibrationPointOffset = 200;
        private int numeroPuntosCalibracion;
        private Size bigImage = new Size(80, 80);
        private Size littleImage = new Size(20, 20);
        private Timer timerPreShow;
        private Timer timerPostShow;
        private calibrationPoint currentCalibrationPoint;
        private static readonly Random Random = new Random();
        private EyeTrackingEngine eyeTrackingEngine;


        public CalibrationWinForm(EyeTrackingEngine eyeTrackingEngine)
        {
            InitializeComponent();

            Cursor.Hide();

            //this.eyeXWinForm = eyeXWinForm;
            this.eyeTrackingEngine = eyeTrackingEngine;

            eyeTrackingEngine.onStartCalibrationCompletedEvent += this.onStartCalibrationCompleted;
            eyeTrackingEngine.onAddCalibrationPointCompletedEvent += this.onAddCalibrationPointCompleted;
            eyeTrackingEngine.onComputeandSetCalibrationCompletedEvent += this.onComputeandSetCalibrationCompleted;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent += this.OnGetCalibrationCompleted;

            configTimers();
            generateCalibrationPoints();
            requestStartCalibrationEyeX();

        }

        private void CalibrationWinForm_Load(object sender, EventArgs e)
        {
            pictureBoxCalibrationImage.Size = bigImage;
            currentCalibrationPoint = setCalibrationPoint();
            startTimersEyeX();
        }




        private void configTimers()
        {            
            timerPreShow = new Timer();
            timerPreShow.Interval = preShowTime;
            timerPreShow.Tick += new EventHandler(timerPreShow_Tick_EyeX);

            timerPostShow = new Timer();
            timerPostShow.Interval = postShowTime;
            timerPostShow.Tick += new EventHandler(timerPostShow_Tick_EyeX);
        }

        /// <summary>
        /// Define la posicion del centro de los puntos de calibracion
        /// </summary>
        private void generateCalibrationPoints()
        {
            int Width = Program.datosCompartidos.monitorBounds.Width;
            int Height = Program.datosCompartidos.monitorBounds.Height;
            double offsetX = (double)calibrationPointOffset / (double)Width;
            double offsetY = (double)calibrationPointOffset / (double)Height;
            calibrationPoint puntoCalibracion = new calibrationPoint();
            List<calibrationPoint> puntoCalibracionLista = new List<calibrationPoint>();

            /*
             * (x,y)
             * 
             *  1(offset,offset)        2(Width/2,offset)           3(Width-offset,offset)
             *  4(offset,Height/2)      5(Width/2,Height/2)         6(Width-offset,Height/2)
             *  7(offset,Height-offset) 8(Width/2,Height-offset)    9(Width-offset,Height-offset)
             */

            puntoCalibracion.positionEyeTribe = new Tobii.Gaze.Core.Point2D(calibrationPointOffset, calibrationPointOffset);//1
            puntoCalibracion.positionEyeX = new Tobii.Gaze.Core.Point2D(offsetX, offsetY);
            puntoCalibracion.imagen = Properties.Resources.boxer;
            puntoCalibracionLista.Add(puntoCalibracion);

            puntoCalibracion.positionEyeTribe = new Tobii.Gaze.Core.Point2D(Width - calibrationPointOffset, calibrationPointOffset);//3
            puntoCalibracion.positionEyeX = new Tobii.Gaze.Core.Point2D(1 - offsetX, offsetY);            
            puntoCalibracion.imagen = Properties.Resources.cotorritas;
            puntoCalibracionLista.Add(puntoCalibracion);

            puntoCalibracion.positionEyeTribe = new Tobii.Gaze.Core.Point2D(Width / 2, Height / 2);//5
            puntoCalibracion.positionEyeX = new Tobii.Gaze.Core.Point2D(0.5, 0.5);
            puntoCalibracion.imagen = Properties.Resources.salchicha;//pajaro
            puntoCalibracionLista.Add(puntoCalibracion);

            puntoCalibracion.positionEyeTribe = new Tobii.Gaze.Core.Point2D(calibrationPointOffset, Height - calibrationPointOffset);//7
            puntoCalibracion.positionEyeX = new Tobii.Gaze.Core.Point2D(offsetX, 1 - offsetY);
            puntoCalibracion.imagen = Properties.Resources.cachorritoSubir;
            puntoCalibracionLista.Add(puntoCalibracion);

            puntoCalibracion.positionEyeTribe = new Tobii.Gaze.Core.Point2D(Width - calibrationPointOffset, Height - calibrationPointOffset);//9
            puntoCalibracion.positionEyeX = new Tobii.Gaze.Core.Point2D(1 - offsetX, 1 - offsetY);
            puntoCalibracion.imagen = Properties.Resources.catAndFox;
            puntoCalibracionLista.Add(puntoCalibracion);


            numeroPuntosCalibracion = puntoCalibracionLista.Count;
            int[] order = new int[numeroPuntosCalibracion];

            for (var c = 0; c < numeroPuntosCalibracion; c++)
                order[c] = c;

            Shuffle(order);

            foreach (int number in order)
            {
                puntoCalibracion = puntoCalibracionLista[number];
                calibrationPoints.Enqueue(puntoCalibracion);
            }

        }
        
        private bool requestStartCalibrationEyeX()
        {
            eyeTrackingEngine.requestStartCalibration();
            return true;
        }



        


        private calibrationPoint setCalibrationPoint()
        {
            calibrationPoint calibrationPoint;

            if (calibrationPoints.Count != 0)
            {
                calibrationPoint = calibrationPoints.Dequeue();
                relocateCalibrationImage(calibrationPoint);
                return calibrationPoint;
            }
            else
            {
                calibrationPoint.positionEyeTribe = new Tobii.Gaze.Core.Point2D(double.NaN, double.NaN);
                calibrationPoint.positionEyeX = new Tobii.Gaze.Core.Point2D(double.NaN, double.NaN);
                calibrationPoint.imagen = null;
                return calibrationPoint;
            }
        }

        private void startTimersEyeX()
        {
            this.BeginInvoke((Action)(() =>
            {
                timerPreShow.Start();
            }));
        }





        private void timerPreShow_Tick_EyeX(object sender, EventArgs e)
        {
            timerPreShow.Stop();
            resizeImage(tamanhoImagen.little);
            eyeTrackingEngine.AddCalibrationPoint(currentCalibrationPoint.positionEyeX);            
        }

        private void timerPostShow_Tick_EyeX(object sender, EventArgs e)
        {
            timerPostShow.Stop();            
            currentCalibrationPoint = setCalibrationPoint();

            if (currentCalibrationPoint.imagen != null)
            {
                timerPreShow.Start();            
            }
            else
            {
                timerPreShow.Tick -= new EventHandler(timerPreShow_Tick_EyeX);
                timerPostShow.Tick -= new EventHandler(timerPostShow_Tick_EyeX);

                Console.WriteLine("CalibrationWinForm.timerLatency_Tick_EyeX: final");                
                eyeTrackingEngine.ComputeAndSetCalibration();
            }            
        }






        private void closeProtocol()
        {            
            this.BeginInvoke((Action)(() =>
            {
                this.Close();
            }));
        }

        private void resizeImage(tamanhoImagen imageSize)
        {
            if (imageSize == tamanhoImagen.big)
            {
                pictureBoxCalibrationImage.BeginInvoke((Action)(() =>
                {
                    pictureBoxCalibrationImage.Size = bigImage;
                    pictureBoxCalibrationImage.Location = new Point(
                        Convert.ToInt32(pictureBoxCalibrationImage.Location.X - ((bigImage.Width / 2) - (littleImage.Width / 2))),
                        Convert.ToInt32(pictureBoxCalibrationImage.Location.Y - ((bigImage.Height / 2) - (littleImage.Height / 2)))
                        );
                }));
            }

            if (imageSize == tamanhoImagen.little)
            {
                pictureBoxCalibrationImage.BeginInvoke((Action)(() =>
                {
                    pictureBoxCalibrationImage.Size = littleImage;
                    pictureBoxCalibrationImage.Location = new Point(
                        Convert.ToInt32(pictureBoxCalibrationImage.Location.X + ((bigImage.Width / 2) - (littleImage.Width / 2))),
                        Convert.ToInt32(pictureBoxCalibrationImage.Location.Y + ((bigImage.Height / 2) - (littleImage.Height / 2)))
                        );
                }));
            }
        }

        private void relocateCalibrationImage(calibrationPoint calibrationPoint)
        {
            pictureBoxCalibrationImage.BeginInvoke((Action)(() =>
            {
                pictureBoxCalibrationImage.Location = new Point(
                    Convert.ToInt32(calibrationPoint.positionEyeTribe.X) - (pictureBoxCalibrationImage.Width / 2),
                    Convert.ToInt32(calibrationPoint.positionEyeTribe.Y) - (pictureBoxCalibrationImage.Height / 2)
                    );
                pictureBoxCalibrationImage.Image = calibrationPoint.imagen;
            }));

        }

        private static void Shuffle<T>(IList<T> array)
        {
            if (array == null)
                return;

            var random = Random;

            for (var i = array.Count; i > 1; i--)
            {
                var j = random.Next(i);
                var tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }




        //Eventos del EyeX
        private void onStartCalibrationCompleted(object sender, EventArgs e)
        {
            //eyeTrackerReady2Calibrate = true;

            if(this.Visible)
            {
                Console.WriteLine("CalibrationWinForm.onStartCalibrationCompleted. this.Visible = true");
                startTimersEyeX();
            }
            else
            {
                Console.WriteLine("CalibrationWinForm.onStartCalibrationCompleted. this.Visible = false");
            }
        }

        private void onAddCalibrationPointCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("CalibrationWinForm.onAddCalibrationPointCompleted");
            resizeImage(tamanhoImagen.big);

            this.BeginInvoke((Action)(() =>
            {
                timerPostShow.Start();
            }));
            
        }

        private void onComputeandSetCalibrationCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("CalibrationWinForm.onComputeandSetCalibrationCompleted");
            closeProtocol();
        }

        private void OnGetCalibrationCompleted(object sender, CalibrationReadyEventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                            LookAndPlayForm.Program.datosCompartidos.startTime +
                            @"-us" + Program.datosCompartidos.activeUser + @"\";

            bool exists = System.IO.Directory.Exists(path);

            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            File.WriteAllText(path + @"calibrationData.json", JsonConvert.SerializeObject(e.CalibrationPointDataL));
        }



        
        private void CalibrationWinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            eyeTrackingEngine.onStartCalibrationCompletedEvent -= this.onStartCalibrationCompleted;
            eyeTrackingEngine.onAddCalibrationPointCompletedEvent -= this.onAddCalibrationPointCompleted;
            eyeTrackingEngine.onComputeandSetCalibrationCompletedEvent -= this.onComputeandSetCalibrationCompleted;
            eyeTrackingEngine.OnGetCalibrationCompletedEvent -= this.OnGetCalibrationCompleted;

            Cursor.Show();
        }
        
    }
}
