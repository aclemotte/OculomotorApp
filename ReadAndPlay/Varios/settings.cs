using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LookAndPlayForm
{
    class settings
    {
        //eyesDetector
        public const int maxNumberOfDataReceived = 15;
                
        //dwell
        public const int DwellArea = 50;//0pix
        public const int DwellTime = 1000;//mseg
        public const int DwellLatency = 1000;

        //control puntero
        //public const pointercontroltype pointercontroltypeSelected = pointercontroltype.eyetracker; //podria comentarse

        //filtro
        public const FilterType filtertypeSelected = FilterType.median;
        public const int filterBufferSize = 15;//numero impar mayor a 3
        public const double thresholdFilterNormalized = 2000;//numero de pixeles
       
        //puntero
        //public const bool cursorVisibleGame = false;

        //calibration error
        public const int maxCalibracionError = 50;

        public const int indiceTrial = 0;//en mi sw base habian varios target. En esta app hay un solo target. por defecto será siempre cero

        public static Color leftEyeColor = Color.Green;
        public static Color rightEyeColor = Color.Blue; 
    }
}
