using System;

namespace NewJSON
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(JSONValidator(input));
            Console.Read();
        }

#pragma warning disable S1541 // Methods and properties should not be too complex
        public static string JSONValidator(string input)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            const string invalid = "Invalid";
            if (string.IsNullOrEmpty(input))
            {
                return invalid;
            }

            if (!input.StartsWith('\"') || !input.EndsWith('\"'))
            {
                return invalid;
            }

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i - 1] != '\\' && input[i] == '/' || input[i - 1] != '\\' && input[i] == '"')
                {
                    return invalid;
                }

                const int charactersLimit = 32;
                if (input[i] < charactersLimit)
                {
                    return invalid;
                }

                if (input[i] == '\\' && !CheckBackslash(input.Substring(input.IndexOf('\\') + 1)))
                {
                     return invalid;
                }
            }

            return "Valid";
        }

        private static bool CheckBackslash(string substring)
            {
            if (CheckBackslashNextCharacter(substring[0]))
            {
                return true;
            }

            if (substring[1] != 'u')
            {
                return false;
            }

            const int unicodeLength = 5;
            const int start = 2;
            return CheckUnicode(substring.Substring(start, unicodeLength));
        }

        private static bool CheckBackslashNextCharacter(char nextCharacter)
        {
            char[] validCharacters = { 'b', 'f', 'n', 'r', 't', '"', '/' };
            for (int i = 0; i < validCharacters.Length; i++)
            {
                if (nextCharacter == validCharacters[i])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckUnicode(string unicode)
        {
            const int A = 65;
            const int F = 70;
            const int a = 97;
            const int f = 102;
            foreach (char c in unicode)
            {
#pragma warning disable S1067 // Expressions should not be too complex
                if ((c >= A && c <= F) || (c >= a && c <= f) || char.IsDigit(c))
#pragma warning restore S1067 // Expressions should not be too complex
                {
                    return true;
                }
            }

            return false;
        }
    }
}