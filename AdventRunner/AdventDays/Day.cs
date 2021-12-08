using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventRunner.AdventDays
{
    public abstract class Day
    {
        protected static List<string> GetNewlineSeparatedFileContents(string day)
        {
            using TextReader tr = new StreamReader(@$"InputFiles\{day}.txt");
            return tr
                .ReadToEnd()
                .Split(new [] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
        protected static List<string> GetCommaSeparatedFileContents(string day)
        {
            using TextReader tr = new StreamReader(@$"InputFiles\{day}.txt");
            return tr
                .ReadToEnd()
                .Split(new [] {',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}