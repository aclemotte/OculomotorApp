using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAndPlayForm.LogData
{
    class ClassLogData
    {
        public string Date;
        public string Time_start;
        public string Time_end;
        public string Tester;
        public string Patient;
        public int number_of_screening_done;

        public ClassLogData()
        {
            this.number_of_screening_done = 0;
        }
    }
}
