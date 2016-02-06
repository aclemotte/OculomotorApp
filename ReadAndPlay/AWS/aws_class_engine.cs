using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Ionic.Zip;
using LookAndPlayForm.Utility;
using System.Windows.Forms;
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
                var fs = new FileStream(aws_data.FileToUpload, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

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
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    Console.WriteLine("Amazon error code: {0}", string.IsNullOrEmpty(ex.ErrorCode) ? "None" : ex.ErrorCode);
                    Console.WriteLine("Exception message: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    Console.WriteLine("Exception message: {0}", ex.Message);
                }
            }
        }

        public static void UpdateDataBaseFile(string AwsS3FolderName)
        {
            UpdateMetaData(CData.DataBasePath, AwsS3FolderName);
        }


        public static void UpdateLogFile(string AwsS3FolderName)
        {
            string fileName = CData.DataFolder + @"\log.txt";
            UpdateMetaData(fileName, AwsS3FolderName);
        }

        public static void UpdateErrorFile(string AwsS3FolderName)
        {
            string fileName = CData.DataFolder + @"\error.txt";
            UpdateMetaData(fileName, AwsS3FolderName);
        }

        /// <summary>
        /// Updates meta data AWS; with non-bllocking update
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="AwsS3FolderName"></param>
        private static void UpdateMetaData(string fileName, string AwsS3FolderName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    aws_class_data aws_data = new aws_class_data();
                    aws_data.FileToUpload = fileName;
                    aws_data.AwsS3FolderName = AwsS3FolderName;
                    UploadFile(aws_data);
                }
            }
            catch (IOException ex)
            {
                try
                {
                    string tmpd = Path.GetDirectoryName(fileName) + @"\tmp";
                    DirectoryInfo di = Directory.CreateDirectory(tmpd);
                    di.Attributes = FileAttributes.Hidden | FileAttributes.Directory;
                    string tmp = tmpd + @"\" + Path.GetFileName(fileName);
                    File.Copy(CData.DataBasePath, tmp);
                    aws_class_data aws_data = new aws_class_data();
                    aws_data.FileToUpload = tmp;
                    aws_data.AwsS3FolderName = AwsS3FolderName;
                    UploadFile(aws_data);
                    Directory.Delete(tmpd, true);
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Can't update DB (AWS, UpdateMetaData).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ErrorLog.ErrorLog.toErrorFile(exx.GetBaseException().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't update DB (AWS, UpdateMetaData).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }
    }
}
