using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.TesterID
{
    public class TesterLoginEngineData
    {
        public string tester_id { get; set; }
        public string tester_name { get; set; }

        public TesterLoginEngineData() { }

        public TesterLoginEngineData(string id, string name)
        {
            tester_id = id;
            tester_name = name;
        }
    }
}
