using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace S3.Lib
{
  public class Credentials
  {
    public static Amazon.Runtime.BasicAWSCredentials GetCredentials()
    {
      string key    = ConfigurationManager.AppSettings["awskey"];
      string secret = ConfigurationManager.AppSettings["awssecret"];
      return new Amazon.Runtime.BasicAWSCredentials(key, secret);
    }
  }
}
