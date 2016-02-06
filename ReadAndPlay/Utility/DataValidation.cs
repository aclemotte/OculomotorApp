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
    public sealed class DataValidation
    {
        /// Directory Validation
        #region Directory Validation

        /// <summary>
        /// Checks if the directory has files
        /// </summary>
        /// <param name="path"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static bool DirectoryHasFiles(string path, SearchOption option = SearchOption.TopDirectoryOnly)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            try
            {
                if (!Directory.Exists(path))
                    return false;

                string[] files = Directory.GetFiles(path, "*.*", option);
                if (files == null || files.Length < 1)
                    return false;
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static bool CheckDirectoryPath(string path, bool create)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Path cannot be empty");

            if (File.Exists(path))
                return true;

            if (!Directory.Exists(path))
            {
                string rpath = Path.GetDirectoryName(path);
                if (!Directory.Exists(rpath))
                {
                    if (create)
                        Directory.CreateDirectory(rpath);
                    else
                        throw new DirectoryNotFoundException();
                }

                if (create)
                {
                    if (string.IsNullOrWhiteSpace(Path.GetExtension(path)))
                        Directory.CreateDirectory(path);
                }
                else
                    throw new DirectoryNotFoundException();
            }            

            return true;
        }

        #endregion
    }
}
