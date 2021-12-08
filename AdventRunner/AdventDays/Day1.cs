using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day1 : Day
    {
        public static void Run()
        {
            List<int> numbers = GetNewlineSeparatedFileContents(nameof(Day1))
                    .Select(int.Parse)
                    .ToList();

            int greaterDepthCount = FSharp.Code.Day1.countGreaterValues(numbers);
            int slidingGreaterDepthCount = FSharp.Code.Day1.countSlidingGreaterValues(numbers);
            
            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {greaterDepthCount}\r\nPart 2: {slidingGreaterDepthCount}";
        }
    }
}