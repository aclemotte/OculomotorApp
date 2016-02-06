using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LookAndPlayForm.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class FileWorker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadTextFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            if (!File.Exists(fileName))
                return null;

            FileStream FS = null;
            StreamReader SR = null;
            string res = null;

            try
            {                
                FS = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                SR = new StreamReader(FS);

                res = SR.ReadToEnd();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
            finally
            {
                if (SR != null)
                    SR.Close();

                if (FS != null)
                    FS.Close();
            }

            return res;
        }
    }
}
