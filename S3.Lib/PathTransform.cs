using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S3.Lib
{
  public class PathTransform
  {
    public static string Transform(string path)
    {
      if (!path.StartsWith("\\"))
      {
        path = "\\" + path;
      }
      return path.Replace(":","").Replace("\\","/");
    }
  }
}
