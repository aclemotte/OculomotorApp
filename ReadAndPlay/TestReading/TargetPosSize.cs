using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace LookAndPlayForm
{
    public class TargetPosSize
    {
        public struct Target
        {
            public Point position;
            public Point size;
        }


        //Point _screensize;        
        //public Point initTargetSize = new Point(1000, 600);
        
        //public TargetPosSize()
        //{
        //    //_screensize = new Point(LookAndPlayForm.Program.datosCompartidos.monitorBounds.Width, LookAndPlayForm.Program.datosCompartidos.monitorBounds.Height);
        //    //numberOfTargets = 1;
        //    //finished = false;

        //    //Console.WriteLine("Screen size X:" + _screensize.X.ToString() + " Y: " + _screensize.Y.ToString());
        //    //Console.WriteLine("Init target size X: " + initTargetSize.X.ToString() + " Y: " + initTargetSize.Y.ToString());

        //}
                
        //public Point generateInitTargetPosition()
        //{
        //    Point InitTargetPosition = new Point(100, 100);
        //    Console.WriteLine("Init target pos X: " + InitTargetPosition.X.ToString() + " Y: " + InitTargetPosition.Y.ToString());
        //    return InitTargetPosition;
        //}

    }
}
