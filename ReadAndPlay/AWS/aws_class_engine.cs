using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Ionic.Zip;
//using Newtonsoft.Json;

namespace LookAndPlayForm.BackupClass
{
    static class aws_class_engine
    {
        public static void BackupTest(aws_class_data aws_data)
        {
            try
            {
                //zip file name
                var zipfilePath = string.Empty;
                zipfilePath = string.Format("{0}.zip", Path.GetFileName(aws_data.FileToUpload));


                //create zip file                                          
                using (var zip = new ZipFile())
                {
                    zip.AddDirectory(aws_data.FileToUpload);
                    zip.Save(zipfilePath);
                }

                aws_data.FileToUpload = zipfilePath;
                //upload to aws
                UploadFile(aws_data);

                //delete local zip file
                File.Delete(zipfilePath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                //File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
            }
        }

        private static void UploadFile(aws_class_data aws_data)
        {
            using (var client = new Amazon.S3.AmazonS3Client(aws_data.AwsAccessKey, aws_data.AwsSecretKey, Amazon.RegionEndpoint.EUCentral1))
            {
                var fs = new FileStream(aws_data.FileToUpload, FileMode.Open);

                try
                {
                    var request = new PutObjectRequest();
                    request.BucketName = aws_data.AwsS3BucketName + "/" + aws_data.AwsS3FolderName;
                    request.CannedACL = S3CannedACL.Private;
                    request.Key = Path.GetFileName(aws_data.FileToUpload);
                    request.InputStream = fs;
                    client.PutObject(request);
                }
                catch (AmazonS3Exception ex)
                {
                    //File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    Console.WriteLine("Amazon error code: {0}", string.IsNullOrEmpty(ex.ErrorCode) ? "None" : ex.ErrorCode);
                    Console.WriteLine("Exception message: {0}", ex.Message);
                }
            }
        }


        public static void UpdateLogFile(string AwsS3FolderName)
        {
            string fileName = @"log.txt";
            UpdateMetaData(fileName, AwsS3FolderName);
        }

        public static void UpdateErrorFile(string AwsS3FolderName)
        {
            string fileName = @"error.txt";
            UpdateMetaData(fileName, AwsS3FolderName);            
        }

        public static void UpdateTestersFile(string AwsS3FolderName)
        {
            string fileName = @"testers.csv";
            UpdateMetaData(fileName, AwsS3FolderName);
        }

        public static void UpdateUsersFile(string AwsS3FolderName)
        {
            string fileName = @"users.csv";
            UpdateMetaData(fileName, AwsS3FolderName);
        }

        private static void UpdateMetaData(string fileName, string AwsS3FolderName)
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MrPatchData\";
            string fullFileName = rootPath + fileName;
            if (File.Exists(fullFileName))
            {
                aws_class_data aws_data = new aws_class_data();
                aws_data.FileToUpload = fullFileName;
                aws_data.AwsS3FolderName = AwsS3FolderName;
                UploadFile(aws_data);
            }
        }
    }
}
