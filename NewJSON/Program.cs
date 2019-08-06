using System;

namespace NewJSON
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(CheckBackslash(input));
        }

        public static bool CheckQuotationsStartAndEnd(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.StartsWith('"') && input.EndsWith('"');
        }

        public static bool CheckControlCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            const int controlCharactersLimit = 32;
            foreach (char c in input)
            {
                if (c < controlCharactersLimit)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckQuotations(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return (!input.Contains('"') || input.IndexOf('"') == 0) && input.IndexOf('"') == input.Length - 1;
        }

        public static bool CheckBackslash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.Contains('\\');
        }

        public static bool CheckBackslashPreceededCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
#pragma warning disable S1067 // Expressions should not be too complex
            if (input.Contains('/') ||
               input.Contains('\b') ||
                input.Contains('\f') ||
                input.Contains('\n') ||
                input.Contains('\r') ||
                input.Contains('\t'))
#pragma warning restore S1067 // Expressions should not be too complex
            {
                return true;
            }

            return false;
        }

        public static bool CheckUnicodeCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Contains("\\u")
        }
    }
}
