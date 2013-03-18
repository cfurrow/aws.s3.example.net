using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3.Lib
{
  public class Store
  {
    public static S3Response StoreFile(string bucket,string path)
    {
      AmazonS3Client client = new AmazonS3Client(Credentials.GetCredentials());
      PutObjectRequest request = new PutObjectRequest();

      string key = PathTransform.Transform(path);

      request
        .WithFilePath(path)
        .WithKey(key)
        .WithBucketName(bucket);

      return client.PutObject(request);
    }
  }
}
