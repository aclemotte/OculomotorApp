using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace StimuloPersuitHorizontal
{
    class StimuloPersuitEngine
    {
        public delegate void newCoordinateDelegate(int xCoordinate);
        public event newCoordinateDelegate newCoordinate;
        public event EventHandler persuitEnd;

        public int offset_izquierda { get; set; }
        public int offset_arriba { get; set; }
        public int dotSizeX { get; set; }
        public int dotSizeY { get; set; }

        private Form stimuloPersuitForm;
        private int amplitud_movimiento = 1000;
        private int numero_vueltas = 2;
        private int tiempo_1_vuelta = 8;
        private double intervalMseg = 50;
        private double dpix, dpiy;
        private int dotmilimeter = 5;
        private double tiempo;
        private double velocidad;
        private int xCoordinate;      
        private System.Timers.Timer timer;



        public StimuloPersuitEngine(Form StimuloPersuitForm)
        {
            this.stimuloPersuitForm = StimuloPersuitForm;
            timer = new System.Timers.Timer(intervalMseg);
            timer.Elapsed += timer_Elapsed;

            tiempo = 0;
            velocidad = 360 / (double)tiempo_1_vuelta;

            getDPI();
            setDotFeactures();
        }

        private void getDPI()
        {
            Graphics g = stimuloPersuitForm.CreateGraphics();
            try
            {
                dpix = (double)g.DpiX;
                dpiy = (double)g.DpiY;
            }
            finally
            {
                g.Dispose();
            }
        }

        private int milimeter2Pixels(double milimeter, double dpi)
        {
            return (int)(milimeter*dpix/25.4);
        }

        private void setDotFeactures()
        {
            offset_izquierda = (int)((double)(Screen.PrimaryScreen.Bounds.Size.Width - amplitud_movimiento) * (double)0.5);
            offset_arriba = (int)((double)(Screen.PrimaryScreen.Bounds.Size.Height) * (double)0.5);

            dotSizeX = milimeter2Pixels(dotmilimeter, dpix);
            dotSizeY = milimeter2Pixels(dotmilimeter, dpiy);
        }      

        public void persuitStart()
        {
            tiempo = 0;
            timer.Start();
        }

        public void persuitStop()
        {
            timer.Stop();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //xCoordinate = offset_izquierda + (int)((double)amplitud_movimiento * Math.Abs(Math.Sin(Math.PI / 180 * velocidad * tiempo)));
            xCoordinate = offset_izquierda + (int)((double)amplitud_movimiento * (((Math.Sin(rad2Deg(velocidad * tiempo + 270))) * 0.5) + 0.5));

            if (tiempo < (double)(numero_vueltas * tiempo_1_vuelta))
            {
                tiempo += intervalMseg/1000;
                if (newCoordinate != null)
                    newCoordinate(xCoordinate);
            }
            else
            {
                tiempo = 0;
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
