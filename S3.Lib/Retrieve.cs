using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3.Lib
{
  public class Retrieve
  {
    public static GetObjectResponse GetFile(string bucket, string key)
    {
      AmazonS3Client client = new AmazonS3Client(Credentials.GetCredentials());

      GetObjectRequest request = new GetObjectRequest()
                                      .WithBucketName(bucket)
                                      .WithKey(PathTransform.Transform(key));

      GetObjectResponse response = client.GetObject(request);
      return response;
    }
  }
}
