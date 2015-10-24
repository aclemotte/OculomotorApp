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
            { "Level 1. Text 1",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText1, 61)},           
            { "Level 1. Text 2",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText2, 63)},
            { "Level 1. Text 3",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText3, 64)},            
            { "Level 2. Text 15",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText15, 61)},            
            { "Level 2. Text 16",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText16, 62)},            
            { "Level 2. Text 17",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText17, 62)},            
            { "Level 3. Text 29",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText29, 60)},            
            { "Level 3. Text 30",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText30, 62)},            
            { "Level 3. Text 31",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText31, 62)},            
            { "Level 7. Text 87",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText87, 100)},            
            { "Level 7. Text 88",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText88, 109)},            
            { "Level 7. Text 89",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText89, 116)},     
            //español
            { "Nivel 1. Texto 1",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText1Esp, 64)},
            { "Nivel 1. Texto 2",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText2Esp, 62)},            
            { "Nivel 1. Texto 3",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText3Esp, 60)},            
            { "Nivel 1. Texto 4",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText4Esp, 60)},            
            { "Nivel 2. Texto 5",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText5Esp, 61)},            
            { "Nivel 2. Texto 6",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText6Esp, 61)},            
            { "Nivel 3. Texto 7",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText7Esp, 61)},            
            { "Nivel 3. Texto 8",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText8Esp, 60)},            
            { "Nivel 4. Texto 9",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText9Esp, 121)},            
            { "Nivel 4. Texto 10",  new imageProperties(LookAndPlayForm.Properties.Resources.visagraphText10Esp, 122)}

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
