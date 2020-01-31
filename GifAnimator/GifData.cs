#region Title Header

// Name: Phillip Smith
// 
// Solution: GifAnimator
// Project: GifAnimator
// File Name: GifData.cs
// 
// Current Data:
// 2020-02-01 12:24 AM
// 
// Creation Date:
// 2020-01-31 9:51 PM

#endregion

using ImageMagick;

namespace GifAnimator
{
  internal class GifData
  {
    public int AnimationDuration { get; set; }
    public int AnimationTicksPerSecond { get; set; }
    public int Quality { get; set; }
    public MagickColor MatteColor { get; set; }
    public GifDisposeMethod GifDisposeMethod { get; set; }
    public string[] FrameFileLocations { get; set; }
    public string OutputLocation { get; set; }
    public string FileName { get; set; }

    public GifData(int animationDuration, int animationTicksPerSecond, string fileName, string[] frameFileLocations,
      GifDisposeMethod gifDisposeMethod, MagickColor matteColor, string outputLocation, int quality)
    {
      AnimationDuration = animationDuration;
      AnimationTicksPerSecond = animationTicksPerSecond;
      FileName = fileName;
      FrameFileLocations = frameFileLocations;
      GifDisposeMethod = gifDisposeMethod;
      MatteColor = matteColor;
      OutputLocation = outputLocation;
      Quality = quality;
    }
  }
}