using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AdventRunner.Helpers;

namespace AdventRunner.AdventDays
{
    public class Day4 : Day
    {
        public static void Run()
        {
            List<int> numbers = GetCommaSeparatedFileContents("Day4.1").Select(int.Parse)
                .ToList();

            List<string> boards = GetNewlineSeparatedFileContents("Day4.2")
                .ToList();

            int winningValue = global::Day4.Day4.GetWinningBoard(numbers, boards);
            int losingValue = global::Day4.Day4.GetLosingBoard(numbers, boards);
            
            var textBox = Application.Current.MainWindow.FindChild<TextBox>("MainTextBox");
            textBox.Text = $"Part 1: {winningValue}\r\nPart 2: {losingValue}";
        }
    }
}