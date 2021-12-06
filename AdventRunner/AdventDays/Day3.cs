using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day3 : Day
    {
        public static void Run()
        {
            List<string> codes = GetFileContents(nameof(Day3))
                    .ToList();

            int finalPosition = FSharp.Code.Day3.decipherCodes(codes);
            int finalPositionWithAim = FSharp.Code.Day3.decipherCodes(codes);
            
            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {finalPosition}\r\nPart 2: {finalPositionWithAim}";
        }
    }
}