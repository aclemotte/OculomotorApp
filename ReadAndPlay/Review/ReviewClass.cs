using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LookAndPlayForm.Review
{
    public static class ReviewClass
    {
        public static bool loadEyetrackerDataFromJson(string path)
        {
            //eyetrackerDataEyeX eyetrackerDataL;
            ////string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string file = @"\eyetrackerData.json";

            //if (File.Exists(path + file))
            //{
            //    string json = File.ReadAllText(path + file);
            //    eyetrackerDataL = JsonConvert.DeserializeObject<eyetrackerDataEyeX>(json);
            //    return true;
            //}
            //else
            //{
            //    MessageBox.Show("El archivo " + file + " no existe");
            //    return false;
            //}
            return true;
        }
    }
}
