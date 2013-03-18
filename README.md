# aws.s3.net

Example of storing/retrieving files in S3 using the AWS SDK.

## Features
  * Store a file given a key
  * Retrieve a file given a key
  * Translate file-paths to keys 
    * stores in folder structure automatically on S3 bucket


## Example
    // Store file in current output dir, under folder "images\subfolder"
    Store.StoreFile(s3bucket,@"images\subfolder\test-image.jpg");

    // Retrieve the file we just stored, using the same "key"/"directory"
    using (Amazon.S3.Model.GetObjectResponse response = Retrieve.GetFile(s3bucket, @"images\subfolder\test-image.jpg" ))
    {
      // Write the file to a new file in the output directory
      response.WriteResponseStreamToFile(@"aws-got-test-image.jpg");
    }

    // Verify the file exists
    Assert.IsTrue(File.Exists(@"aws-got-test-image.jpg"));

