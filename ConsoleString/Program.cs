using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleString
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var paramString = @"In 1991, while studying computer science at University of Helsinki, Linus Torvalds began a project that later became the Linux kernel. He wrote the program specifically for the hardware he was using and independent of an operating system because he wanted to use the functions of his new PC with an 80386 processor. Development was done on MINIX using the GNU C Compiler.";

            BreakString(paramString, 40);
        }

        public static void BreakString(string text, int length)
        {
            var stringBuilderResult = new StringBuilder();
            var row = string.Empty;
            var lastWord = string.Empty;
            var splitedString = text.Split(" ");

            foreach (var word in splitedString)
            {
                row += lastWord + word.Trim();
                lastWord = " ";

                if (row.Length < length)
                    continue;

                if (row.Length <= length)
                {
                    stringBuilderResult.AppendLine(row.Trim());
                }
                else
                {
                    row = row.SafeReplace(word, string.Empty, true);
                    lastWord = word + " ";

                    stringBuilderResult.AppendLine(row.Trim());
                }

                row = String.Empty;
            }

            stringBuilderResult.AppendLine(row.Trim());

            Console.WriteLine(stringBuilderResult.ToString().Trim());
            Console.ReadKey();
        }

        public static string SafeReplace(this string input, string find, string replace, bool matchWholeWord)
        {
            string textToFind = matchWholeWord ? string.Format(@"\b{0}\b", find) : find;
            return Regex.Replace(input, textToFind, replace);
        }
    }
}
