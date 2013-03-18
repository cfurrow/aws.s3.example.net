using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

using MbUnit.Framework;

namespace S3.Lib.Tests
{
  [TestFixture]
  public class StoreAndRetrieveTests
  {
    string _storeFileName    = @"images\subfolder\test-image.jpg";
    string _retrieveFileName = @"aws-got-test-image.jpg";

    [TearDown]
    public void Teardown()
    {
      if(File.Exists(_retrieveFileName))
      {
        File.Delete(_retrieveFileName);
      }
    }

    string s3bucket = ConfigurationManager.AppSettings["s3bucket"];
    [Test]
    public void TestStore()
    {
      // Store file in current output dir, under folder "images\subfolder"
      Store.StoreFile(s3bucket,_storeFileName);

      // Retrieve the file we just stored, using the same "key"/"directory"
      using (Amazon.S3.Model.GetObjectResponse response = Retrieve.GetFile(s3bucket, _storeFileName ))
      {
        // Write the file to a new file in the output directory
        response.WriteResponseStreamToFile(_retrieveFileName);
      }

      // Verify the file exists
      Assert.IsTrue(File.Exists(_retrieveFileName));
    } 
  }
}
