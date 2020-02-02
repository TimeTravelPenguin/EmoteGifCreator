using System.Collections.Generic;
using System.Linq;

namespace TEA.Core.ExtensionMethods
{
  internal static class EnumerableExtensions
  {
    public static bool AreValidImageTypes(this IEnumerable<string> files)
    {
      return files.All(file => file.ToLowerInvariant().EndsWith(".png"));
    }
  }
}