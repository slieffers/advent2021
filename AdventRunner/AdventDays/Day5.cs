using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day5 : Day
    {
        public static void Run()
        {
            List<string> coords = GetNewlineSeparatedFileContents("Day5")
                .ToList();

            int part1Solution = global::Day5CSharp.Day5.CalculateVentOverlapValue(coords);
            //int losingValue = global::Day4.Day4.GetLosingBoard(numbers, boards);
            
            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {part1Solution}\r\nPart 2: {part1Solution}";
        }
    }
}