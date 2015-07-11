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
        public static void Backup(aws_class_data aws_data)
        {
            try
            {
                //zip file name
                var zipfilePath = string.Empty;
                zipfilePath = string.Format("{0}.zip", Path.GetFileName(aws_data.FolderToUpload));


                //create zip file                                          
                using (var zip = new ZipFile())
                {
                    zip.AddDirectory(aws_data.FolderToUpload);
                    zip.Save(zipfilePath);
                }

                aws_data.FolderToUpload = zipfilePath;
                //upload to aws
                UploadFolder(aws_data);

                //delete local zip file
                File.Delete(zipfilePath);
            }
            catch (Exception ex)
            {
                File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
            }
        }

        private static void UploadFolder(aws_class_data aws_data)
        {
            using (var client = new Amazon.S3.AmazonS3Client(aws_data.AwsAccessKey, aws_data.AwsSecretKey, Amazon.RegionEndpoint.EUCentral1))
            {
                var fs = new FileStream(aws_data.FolderToUpload, FileMode.Open);

                try
                {

                    var request = new PutObjectRequest();
                    request.BucketName = aws_data.AwsS3BucketName + "/" + aws_data.AwsS3FolderName;
                    request.CannedACL = S3CannedACL.Private;
                    request.Key = Path.GetFileName(aws_data.FolderToUpload);
                    request.InputStream = fs;
                    client.PutObject(request);
                }
                catch (AmazonS3Exception ex)
                {
                    File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
                    Console.WriteLine("Amazon error code: {0}", string.IsNullOrEmpty(ex.ErrorCode) ? "None" : ex.ErrorCode);
                    Console.WriteLine("Exception message: {0}", ex.Message);
                }
            }
        }

    }
}
