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
            { "TextoIn4.png",  new imageProperties(LookAndPlayForm.Properties.Resources.TextoIn4, 63)},            
            { "TextoIn5.png",  new imageProperties(LookAndPlayForm.Properties.Resources.TextoIn5, 62)},            

            //{ "visagraphText1.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText1, 62)},            
            //{ "visagraphText2.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText2, 62)},            
            //{ "visagraphText3.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText3, 62)},            
            //{ "visagraphText15.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText15, 62)},            
            //{ "visagraphText16.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText16, 62)},            
            //{ "visagraphText17.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText17, 62)},            
            //{ "visagraphText29.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText29, 62)},            
            //{ "visagraphText30.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText30, 62)},            
            //{ "visagraphText31.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText31, 62)},            
            //{ "visagraphText87.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText87, 62)},            
            //{ "visagraphText88.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText88, 62)},            
            //{ "visagraphText89.png",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText89, 62)},            
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
