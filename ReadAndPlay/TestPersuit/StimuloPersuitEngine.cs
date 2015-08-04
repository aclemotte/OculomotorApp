﻿using System;
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

        public int offset_izquierda { get; set; }//distancia del stimulo al margen izquierdo de la pantalla
        public int offset_arriba { get; set; }//distancia del stimulo al margen superior de la pantalla
        public int dotDiameterPixelsX { get; set; }//el tamaño del stimulo en pixeles
        public int dotDiameterPixelsY { get; set; }//el tamaño del stimulo en pixeles
        public int amplitudMovimientoPixels { get; set; }
        private Form stimuloPersuitForm;

        private int amplitudMovimientoMilimeter = 100;//10cm
        private int numero_vueltas = 2;
        private int tiempo_1_vuelta = 8;
        private double intervalMseg = 50;
        private double dpix, dpiy;
        private int dotDiameterMilimeter = 5;
        
        private double tiempo, velocidad;
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
            amplitudMovimientoPixels = milimeter2Pixels(amplitudMovimientoMilimeter, dpix);
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
            offset_izquierda = (int)((double)(Screen.PrimaryScreen.Bounds.Size.Width - amplitudMovimientoPixels) * (double)0.5);
            offset_arriba = (int)((double)(Screen.PrimaryScreen.Bounds.Size.Height) * (double)0.5);

            dotDiameterPixelsX = milimeter2Pixels(dotDiameterMilimeter, dpix);
            dotDiameterPixelsY = milimeter2Pixels(dotDiameterMilimeter, dpiy);
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
            xCoordinate = offset_izquierda + (int)((double)amplitudMovimientoPixels * (((Math.Sin(rad2Deg(velocidad * tiempo + 270))) * 0.5) + 0.5));

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
