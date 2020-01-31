#region Title Header

// Name: Phillip Smith
// 
// Solution: GifAnimator
// Project: GifAnimator
// File Name: UserInput.cs
// 
// Current Data:
// 2020-02-01 12:24 AM
// 
// Creation Date:
// 2020-01-31 10:12 PM

#endregion

using System;
using System.Globalization;
using System.IO;
using ImageMagick;

namespace GifAnimator
{
  internal static class UserInput
  {
    public static string UserInputString(string message, string defaultVal = default)
    {
      Console.WriteLine(message);
      Console.Write("> ");

      var input = Console.ReadLine();

      return string.IsNullOrWhiteSpace(input)
        ? defaultVal
        : input;
    }

    public static int UserInputInt(string message, int defaultVal = default)
    {
      while (true)
      {
        var valString = UserInputString(message);

        if (valString == default)
        {
          return defaultVal;
        }

        if (!string.IsNullOrWhiteSpace(valString) && int.TryParse(valString, NumberStyles.Integer,
              CultureInfo.InvariantCulture, out var intResult))
        {
          return intResult;
        }

        OutputError("Please enter an integer value...");
      }
    }

    public static string UserInputPath(string message, string defaultVal = default)
    {
      while (true)
      {
        var path = UserInputString(message);

        if (Directory.Exists(path))
        {
          return path;
        }

        if (path == default && Directory.Exists(defaultVal))
        {
          return defaultVal;
        }

        OutputError("Please enter a valid path...");
      }
    }

    public static GifData UserCreateGifData(string[] imageFrames)
    {
      if (imageFrames == null)
      {
        throw new ArgumentNullException(nameof(imageFrames));
      }

      if (imageFrames.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(imageFrames));
      }

      var filename =
        UserInputString("Output filename (blank if \"AnimationExport.gif\"):", "AnimationExport.gif");
      Console.WriteLine();

      var outputDir = UserInputPath("Output directory (blank if same as input directory):",
        Directory.GetParent(imageFrames[0]).FullName);
      Console.WriteLine();

      int animationDuration;
      do
      {
        animationDuration =
          UserInputInt("Frame duration in 1/100th seconds (blank if 1 => 0.01 second):", 1);

        if (animationDuration < 1)
        {
          Console.WriteLine("Frame duration must be at least 1/100th second");
        }

        Console.WriteLine();
      } while (animationDuration < 1);

      int animationTicksPerSecond;
      do
      {
        animationTicksPerSecond = UserInputInt(
          $"Animation ticks per second (blank if {imageFrames.Length}/second):",
          imageFrames.Length);

        if (animationTicksPerSecond < 1)
        {
          Console.WriteLine("Ticks per second must be at least 1");
        }

        Console.WriteLine();
      } while (animationTicksPerSecond < 1);

      int quality;
      do
      {
        quality = UserInputInt("Render quality (blank if 100%):", 100);

        if (quality < 1 || quality > 100)
        {
          Console.WriteLine("Quality can not be less than 1% or more than 100% the original image frames");
        }

        Console.WriteLine();
      } while (quality < 1 || quality > 100);


      return new GifData(animationDuration, animationTicksPerSecond, filename, imageFrames, GifDisposeMethod.Previous,
        MagickColor.FromRgba(0, 0, 0, 0), outputDir, quality);
    }

    private static void OutputError(string message)
    {
      Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}{1}{0}", Environment.NewLine, message));
    }
  }
}