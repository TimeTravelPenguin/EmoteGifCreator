#region Title Header

// Name: Phillip Smith
// 
// Solution: GifAnimator
// Project: GifAnimator
// File Name: MagickImageExtensions.cs
// 
// Current Data:
// 2020-02-01 12:24 AM
// 
// Creation Date:
// 2020-01-31 9:45 PM

#endregion

using ImageMagick;

namespace GifAnimator
{
  internal static class MagickImageExtensions
  {
    public static bool IsSameBaseSize(this IMagickImage thisImage, IMagickImage magickImage)
    {
      return thisImage.BaseHeight == magickImage.BaseHeight
             && thisImage.BaseWidth == magickImage.BaseWidth;
    }

    public static bool IsSameColorSpace(this IMagickImage thisImage, IMagickImage magickImage)
    {
      return thisImage.ColorSpace == magickImage.ColorSpace;
    }

    public static void ApplyGifSettings(this MagickImage image, GifData data)
    {
      image.AnimationDelay = data.AnimationDuration;
      image.AnimationTicksPerSecond = data.AnimationTicksPerSecond;
      image.Quality = data.Quality;
      image.MatteColor = data.MatteColor;
      image.GifDisposeMethod = data.GifDisposeMethod;
    }
  }
}