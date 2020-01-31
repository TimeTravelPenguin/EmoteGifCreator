#region Title Header

// Name: Phillip Smith
// 
// Solution: GifAnimator
// Project: GifAnimator
// File Name: ImageProcessing.cs
// 
// Current Data:
// 2020-02-01 12:24 AM
// 
// Creation Date:
// 2020-02-01 12:22 AM

#endregion

using System;
using System.IO;
using System.Linq;
using ImageMagick;

namespace GifAnimator
{
  internal static class ImageProcessing
  {
    public static void CreateCollection(GifData gifData)
    {
      using var imgCollection = new MagickImageCollection();

      foreach (var frameLocation in gifData.FrameFileLocations)
      {
        var frame = new MagickImage(frameLocation);
        frame.ApplyGifSettings(gifData);
        imgCollection.Add(frame);
      }

      if (!imgCollection.All(img => img.IsSameBaseSize(imgCollection[0])))
      {
        Console.WriteLine("Please ensure all image frames have the same size dimensions");
        return;
      }

      var settings = new QuantizeSettings
      {
        Colors = 256,
        DitherMethod = DitherMethod.No
      };

      imgCollection.Quantize(settings);

      Console.WriteLine("Rendering gif...");

      var path = Path.Combine(gifData.OutputLocation, gifData.FileName);
      imgCollection.Write(path, MagickFormat.Gif);
    }
  }
}