using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.Varios
{
    public static class ImageDictionary
    {
        //public Dictionary<string, Bitmap> Image2ReadDictionary = new Dictionary<string, Bitmap>
        //{
        //    { "TextoEs1.png",  LookAndPlayForm.Properties.Resources.TextoEs1},
        //    { "TextoIn1.png",  LookAndPlayForm.Properties.Resources.TextoIn1},
        //};

        public static readonly Dictionary<string, imageProperties> Image2ReadDictionary = new Dictionary<string, imageProperties>
        {
            { "TextoEs1.png",  new imageProperties(LookAndPlayForm.Properties.Resources.TextoEs1, 35)},
            { "TextoIn1.png",  new imageProperties(LookAndPlayForm.Properties.Resources.TextoIn1, 41)},
            { "TextoIn2.png",  new imageProperties(LookAndPlayForm.Properties.Resources.TextoIn2, 100)},            
            { "TextoIn3.png",  new imageProperties(LookAndPlayForm.Properties.Resources.TextoIn3, 100)},            
        };

        public struct imageProperties
        {
            public Bitmap imagen;
            public int numeroPalabras;

            public imageProperties(Bitmap image, int numeroPalabras)
            {
                this.imagen = image;
                this.numeroPalabras = numeroPalabras;
            }
        }
    }
}
