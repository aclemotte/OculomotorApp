using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAndPlayForm.BackupClass
{
    /// <summary>
    /// Mapps to the config.json file.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// The default parameterless constructor.
        /// </summary>
        public Config()
        {
         
        }

        /// <summary>
        /// An overload constructor to build a Config object 
        /// that holds the Aws information required
        /// </summary>
        /// <param name="FileToBackup"></param>
        /// <param name="NamingConvention"></param>
        /// <param name="AwsAccessKey"></param>
        /// <param name="AwsSecretKey"></param>
        /// <param name="AwsS3BucketName"></param>

        public Config(string FileToBackup, string AwsAccessKey, string AwsSecretKey, string AwsS3BucketName)
        {
            this.FileToBackup = FileToBackup;
            //this.NamingConvention = NamingConvention;
            this.AwsAccessKey = AwsAccessKey;
            this.AwsSecretKey = AwsSecretKey;
            this.AwsS3BucketName = AwsS3BucketName;

        }
        /// <summary>
        /// Filename of the configuration file.
        /// </summary>
        public static readonly string FILENAME = "config.json";

        public string FileToBackup { get; set; }
        //public string NamingConvention { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretKey { get; set; }
        public string AwsS3BucketName { get; set; }

        public IEnumerable<string> Paths
        {
            get
            {
                var rv = new List<string>();
                if (FileToBackup.Contains(";"))
                    rv = FileToBackup.Split(';').ToList();
                else
                    rv.Add(FileToBackup);

                return rv;
            }
        }

        public bool IsDir(string path)
        {
            var isDir = false;

            //Check if the user wants to back up a full directory, or just a single file.
            //original code from:
            //http://stackoverflow.com/questions/1395205/better-way-to-check-if-path-is-a-file-or-a-directory
            //http://stackoverflow.com/questions/1896973/is-path-a-directory
            var attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory && Directory.Exists(path))
                isDir = true;

            return isDir;
        }
    }
}