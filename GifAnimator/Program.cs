#region Title Header

// Name: Phillip Smith
// 
// Solution: GifAnimator
// Project: GifAnimator
// File Name: Program.cs
// 
// Current Data:
// 2020-02-01 12:24 AM
// 
// Creation Date:
// 2020-01-31 6:02 PM

#endregion

using System;
using System.Linq;

namespace GifAnimator
{
  internal static class Program
  {
    public static void Main()
    {
      Console.Title = "Quick Gif Maker";

      Console.WriteLine("If there are any issues, please visit: " + @"https://github.com/TimeTravelPenguin/EmoteGifCreator");
      Console.WriteLine();

      var imageFrames = FilesSelector.SetDirectory().ToArray();
      Console.WriteLine();

      var gifData = UserInput.UserCreateGifData(imageFrames);
      ImageProcessing.CreateCollection(gifData);

      Console.WriteLine(Environment.NewLine + "Rendering Done!");
      Console.ReadKey(true);
    }
  }
}