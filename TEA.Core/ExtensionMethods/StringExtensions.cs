using System.IO;

namespace TEA.Core.ExtensionMethods
{
  public static class StringExtensions
  {
    public static bool IsDirectory(this string path)
    {
      var attributes = File.GetAttributes(path);

      return attributes.HasFlag(FileAttributes.Directory);
    }
  }
}