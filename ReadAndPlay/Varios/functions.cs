using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.Varios
{
    public static class functions
    {
        public static string getCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            //return DateTime.Now.ToString("yyyy-MM-dd-HH-mm");//se comento xq puede hacerse una tarea en menos de un minuto
        }
    }
}
