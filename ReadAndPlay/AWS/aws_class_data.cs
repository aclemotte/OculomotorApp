using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookAndPlayForm.Varios;

namespace LookAndPlayForm.BackupClass
{
    /// <summary>
    /// Mapps to the config.json file.
    /// </summary>
    public class aws_class_data
    {
        public string AwsS3BucketName { get; set; }
        public string AwsS3FolderName { get; set; }
        public string FolderToUpload { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretKey { get; set; }

        public aws_class_data()
        {
            this.AwsAccessKey = AwsCredentials.AwsAccessKey;
            this.AwsSecretKey = AwsCredentials.AwsSecretKey;
            this.AwsS3BucketName = AwsCredentials.AwsS3BucketName;
        }

        //public aws_class_data(string AwsS3BucketName, string AwsS3FolderName, string FolderToUpload, string AwsAccessKey, string AwsSecretKey)
        //{
        //    this.AwsS3BucketName = AwsS3BucketName;
        //    this.AwsS3FolderName = AwsS3FolderName;
        //    this.FolderToUpload = FolderToUpload;
        //    this.AwsAccessKey = AwsAccessKey;
        //    this.AwsSecretKey = AwsSecretKey;
        //}
    }
}