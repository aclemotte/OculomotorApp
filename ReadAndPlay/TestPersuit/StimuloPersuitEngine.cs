using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using LookAndPlayForm.TestPersuit;


namespace StimuloPersuitHorizontal
{
    class StimuloPersuitEngine
    {
        public delegate void newCoordinateDelegate(int xCoordinate, int yCoordinate);
        public event newCoordinateDelegate newCoordinate;
        public event EventHandler persuitEnd;

        StimuloPersuitSetup stimuloPersuitSetup;
        private System.Timers.Timer timer;


        private double tiempoSegundos;
        private int xCoordinate;
        private int yCoordinate;




        public StimuloPersuitEngine(StimuloPersuitSetup stimuloPersuitSetup)
        {
            this.stimuloPersuitSetup = stimuloPersuitSetup;

            setTimer();
            tiempoSegundos = 0;
        }

        private void setTimer()
        {
            timer = new System.Timers.Timer(stimuloPersuitSetup.intervalMseg);
            timer.Elapsed += timer_Elapsed;
        }

        public void persuitStart()
        {
            tiempoSegundos = 0;
            timer.Start();
        }

        public void persuitStop()
        {
            timer.Stop();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            xCoordinate = stimuloPersuitSetup.offset_izquierda + (int)((double)stimuloPersuitSetup.amplitudMovimientoPixels * (((Math.Sin(rad2Deg(stimuloPersuitSetup.velocidad * tiempoSegundos + 270))) * 0.5) + 0.5));
            yCoordinate = Screen.PrimaryScreen.Bounds.Size.Height / 2;

            stimuloPersuitSetup.stimulusDataList.Add(new DataPointPersuit(xCoordinate, yCoordinate, tiempoSegundos));

            if (tiempoSegundos < (double)(stimuloPersuitSetup.numero_vueltas * stimuloPersuitSetup.tiempo_1_vuelta))
            {
                tiempoSegundos += stimuloPersuitSetup.intervalMseg / 1000;
                if (newCoordinate != null)
                    newCoordinate(xCoordinate, yCoordinate);
            }
            else
            {
                tiempoSegundos = 0;
                persuitStop();
                if (persuitEnd != null)
                    persuitEnd(this, null);
            }
        }
        
        private double rad2Deg(double deg)
        {
            return (Math.PI / 180 * deg);
        }

    }
}
