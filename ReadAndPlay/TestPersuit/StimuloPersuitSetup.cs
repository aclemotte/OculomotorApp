﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.TestPersuit
{
    public class StimuloPersuitSetup
    {
        //variables independientes
        public int amplitudMovimientoMilimeter { get; set; }
        public int numero_vueltas { get; set; }
        public int tiempo_1_vuelta { get; set; }
        public double intervalMseg { get; set; }
        public int dotDiameterMilimeter { get; set; }


        //variables dependientes
        public int offset_izquierda { get; set; }//distancia del stimulo al margen izquierdo de la pantalla
        public int offset_arriba { get; set; }//distancia del stimulo al margen superior de la pantalla
        public int dotDiameterPixelsX { get; set; }//el tamaño del stimulo en pixeles
        public int dotDiameterPixelsY { get; set; }//el tamaño del stimulo en pixeles
        public int amplitudMovimientoPixels { get; set; }
        public  double dpix { get; set; }
        public  double dpiy { get; set; }
        public double velocidad { get; set; }
        

        public  double tiempo { get; set; }
        public  int xCoordinate { get; set; }
   
        public StimuloPersuitSetup()
        {
            //variables independientes
            amplitudMovimientoMilimeter = 200;//20cm
            numero_vueltas = 2;
            tiempo_1_vuelta = 8;
            intervalMseg = 50;
            dotDiameterMilimeter = 5;

            //variables dependientes
            velocidad = 360 / (double)tiempo_1_vuelta;//grados por segundo
            getDPI();
            amplitudMovimientoPixels = milimeter2Pixels(amplitudMovimientoMilimeter, dpix);
            setMargenes();
            setDotFeactures();
        }

        private void getDPI()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpix = (double)graphics.DpiX;
                dpiy = (double)graphics.DpiY;
            }
        }

        private int milimeter2Pixels(double milimeter, double dpi)
        {
            return (int)(milimeter * dpix / 25.4);
        }

        private void setMargenes()
        {
            offset_izquierda = (int)((double)(Screen.PrimaryScreen.Bounds.Size.Width - amplitudMovimientoPixels) * (double)0.5);
            offset_arriba = (int)((double)(Screen.PrimaryScreen.Bounds.Size.Height) * (double)0.5);
        }
        private void setDotFeactures()
        {
            dotDiameterPixelsX = milimeter2Pixels(dotDiameterMilimeter, dpix);
            dotDiameterPixelsY = milimeter2Pixels(dotDiameterMilimeter, dpiy);
        } 
    }
}
