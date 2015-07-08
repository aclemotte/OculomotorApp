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
    static class AWSClass
    {
        public static void Backup(Config config)
        {
            try
            {                
                //zip file name
                var zipfilePath = string.Empty;
                zipfilePath = string.Format("{0}.zip", Path.GetFileName(config.FileToBackup));


                //create zip file                                          
                using (var zip = new ZipFile())
                {
                    foreach (var path in config.Paths)
                    {
                        if (config.IsDir(path))
                            zip.AddDirectory(path);
                        else
                            zip.AddFile(path);
                    }

                    zip.Save(zipfilePath);
                }

                //upload to aws
                //var aws = new AwsWrapper();
                Upload(zipfilePath, config.AwsAccessKey, config.AwsSecretKey, config.AwsS3BucketName);

                //delete local zip file
                File.Delete(zipfilePath);
            }
            catch (Exception ex)
            {
                File.WriteAllText("lastError.txt", string.Format("Last Error @{0}: {1}", DateTime.Now, ex.GetBaseException()));
            }
        }

        private static void Upload(string filename, string accessKey, string secretKey, string bucketName)
        {
            //using (var client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.EUCentral1))
            using (var client = new Amazon.S3.AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.EUCentral1))
            {
                var fs = new FileStream(filename, FileMode.Open);

                var request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.CannedACL = S3CannedACL.Private;
                request.Key = Path.GetFileName(filename);
                request.InputStream = fs;
                client.PutObject(request);
            }
        }
    }
}
