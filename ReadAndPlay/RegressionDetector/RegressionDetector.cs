using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.RegressionDetector
{
    static class RegressionDetector
    {
        static public bool esUnaRegresion(Point currentFix, Point previousFix)
        {
            int umbralSaltoRegression = 50;
            double umbralAnguloRegression = 30.0;

            //se supone que cumple todos los requisitos al principio
            bool fijacionRetrocedio = true;
            bool fijacionSaltoPoco = true;
            bool fijacionAnguloOk = true;

            //a continuacion se verifica si no cumplen los requisitos

            //si fijacion no retrocedio, malo
            if (currentFix.X > previousFix.X)
                fijacionRetrocedio = false;

            //si fijacion salto por encima del umbral, malo
            double deltaX = (double)(currentFix.X - previousFix.X);
            double deltaY = (double)(currentFix.Y - previousFix.Y);
            int distanciaSalto = (int)(Math.Sqrt(deltaX * deltaX + deltaY * deltaY));
            if (distanciaSalto > umbralSaltoRegression)
                fijacionSaltoPoco = false;

            //si fijacion salto fuera del rango entre [150 y 210] grados (para atras)
            double anguloSalto = Math.Atan(Math.Abs(deltaY) / Math.Abs(deltaX)) * 180 / Math.PI;
            if (anguloSalto > umbralAnguloRegression)
                fijacionAnguloOk = false;


            //si se cumplen todas las condiciones se retorna true
            if (fijacionRetrocedio && fijacionSaltoPoco && fijacionAnguloOk)
                return true;
            else
                return false;

        }
    }
}
