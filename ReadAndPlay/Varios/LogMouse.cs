using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace LookAndPlayForm
{
    class LogMouse
    {
        List<PointI> mouseDataL;
        List<List<PointI>> mouseDataLL;
        
        public LogMouse()
        {
            mouseDataLL = new List<List<PointI>>();
            mouseDataL = new List<PointI>();            
        }

        // metodos publicos 

        public bool startCollectingData()
        {            
            return true;
        }

        public bool addMouseData2List(PointI mouseData)
        {
            mouseDataL.Add(mouseData);
            return true;
        }

        public bool newCollectionOfData()
        {            
            mouseDataLL.Add(mouseDataL);
            mouseDataL = new List<PointI>();
            return true;
        }
        
        public bool stopCollectingData()
        {
            mouseDataLL.Add(mouseDataL);
            return true;
        }

        public bool saveData2File()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(path + @"\mouseData.json", JsonConvert.SerializeObject(mouseDataLL));
            mouseDataL.Clear();
            mouseDataLL.Clear();

            return true;
        }
    }
}
