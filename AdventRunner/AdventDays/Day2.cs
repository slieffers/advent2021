using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day2 : Day
    {
        public static void Run()
        {
            List<string> coords = GetFileContents(nameof(Day2))
                    .ToList();

            int finalPosition = FSharp.Code.Day2.findFinalPositionValue(coords);
            int finalPositionWithAim = FSharp.Code.Day2.findFinalPositionValueWithAim(coords);
            
            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {finalPosition}\r\nPart 2: {finalPositionWithAim}";
        }
    }
}