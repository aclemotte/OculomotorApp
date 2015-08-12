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
        public string Tester;//el ultimo
        public string Patient;//el ultimo
        public string testDone;//el ultimo
        public int number_of_screening_done;
        public string AssemblyVersion;

        public ClassLogData()
        {
            this.number_of_screening_done = 0;
        }
    }
}
