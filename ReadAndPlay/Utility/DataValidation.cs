﻿using System;
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
        public static bool DirectoryHasFiles(string path, SearchOption option = SearchOption.AllDirectories)
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
                return true;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static bool CheckDirectoryPath(string path, bool create, FileAttributes attributes = FileAttributes.Directory)
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
                    {
                        DirectoryInfo di = Directory.CreateDirectory(rpath);
                        //di.Attributes |= attributes;
                    }
                    else
                        throw new DirectoryNotFoundException();
                }

                if (create)
                {
                    if (string.IsNullOrWhiteSpace(Path.GetExtension(path)))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                        di.Attributes |= attributes;
                    }
                }
                else
                    throw new DirectoryNotFoundException();
            }            

            return true;
        }

        #endregion

        public static string DateValidation(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return "";

            DateTime dt;
            if (!DateTime.TryParse(date, out dt))
                return "";

            return date;
        }
    }
}
