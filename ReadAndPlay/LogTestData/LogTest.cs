using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LookAndPlayForm
{
    class LogTest
    {
        public TestData testData;

        public LogTest()
        {
            testData = new TestData();
        }

        public void saveData2File()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\" +
                            LookAndPlayForm.Program.datosCompartidos.startTimeTest + 
                            @"-us" + Program.datosCompartidos.activeUser + @"\";

            bool exists = System.IO.Directory.Exists(path);

            if (!exists)
                System.IO.Directory.CreateDirectory(path);

            File.WriteAllText(path + @"testData.json", JsonConvert.SerializeObject(testData));
        }
    }
}
