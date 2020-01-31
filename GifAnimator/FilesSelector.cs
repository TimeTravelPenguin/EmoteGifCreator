#region Title Header

// Name: Phillip Smith
// 
// Solution: GifAnimator
// Project: GifAnimator
// File Name: FilesSelector.cs
// 
// Current Data:
// 2020-02-01 12:24 AM
// 
// Creation Date:
// 2020-01-31 6:08 PM

#endregion

using System;
using System.Collections.Generic;
using System.IO;

namespace GifAnimator
{
  internal static class FilesSelector
  {
    public static IEnumerable<string> SetDirectory()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("When selecting the source folder containing the individual frames for the animation," +
                          Environment.NewLine +
                          "ensure the only contents are the frames required for the animation!");
        Console.WriteLine();

        var directory = UserInput.UserInputPath("Enter directory with animation frames: ");
        Console.WriteLine();

        var files = GetImageNames(directory, "*.*");

        while (true)
        {
          var key = UserInput.UserInputString(
              $"Animate {files.Length} files from {Path.GetFileName(files[0])} to {Path.GetFileName(files[^1])}? (Y/N):")
            ?.ToUpperInvariant().Trim();

          if (key == "Y")
          {
            return files;
          }

          if (key == "N")
          {
            break;
          }
        }
      }
    }

    private static string[] GetImageNames(string dir, string formatPattern)
    {
      return Directory.GetFiles(dir, formatPattern, SearchOption.TopDirectoryOnly);
    }
  }
}