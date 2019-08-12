using System;

namespace NewJSON
{
    public class Program
    {
        public const string Invalid = "Invalid";
        public const string Valid = "Valid";

        public static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(ManualNumberValidator(input));
            Console.Read();
        }

        public static string ManualNumberValidator(string input)
        {
            if (!CheckElements(input))
            {
                return Invalid;
            }

            if (input.StartsWith('-'))
            {
                return CheckNegativeNumber(input);
            }

            if (input.StartsWith('0') && input[1] != '.')
            {
                return Invalid;
            }

            if (!char.IsDigit(input[input.Length - 1]))
            {
                return Invalid;
            }

            if (input.Contains('E') || input.Contains('e'))
            {
                return CheckExponentOccurance(input);
            }

            if (input.Contains('+') || input.Contains('-'))
            {
                return CheckExponent(input);
            }

            return Valid;
        }

        public static string CheckExponentOccurance(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Invalid;
            }

            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'E' || input[i] == 'e')
                {
                    counter++;
                }
            }

            if (counter != 1)
            {
                return Invalid;
            }

            return Valid;
        }

        public static string CheckNegativeNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Invalid;
            }

            if (char.IsDigit(input[1]))
            {
                return Valid;
            }

            return Invalid;
        }

        public static string CheckExponent(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Invalid;
            }

            if (input.IndexOf('+') > 1 && input[input.IndexOf('+') - 1] != 'E' && input[input.IndexOf('+') - 1] != 'e')
            {
                   return Invalid;
            }

            if (input.IndexOf('-') > 1 && input[input.IndexOf('-') - 1] != 'E' && input[input.IndexOf('-') - 1] != 'e')
            {
                return Invalid;
            }

            return Valid;
        }

        public static bool CheckElements(string input)
        {
            const string validCharacters = ".-+eE";
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c) && !validCharacters.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static string JSONNumberValidator(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Invalid;
            }

            if (!double.TryParse(input, out double result)
                || input.StartsWith('0') && input[1] != '.'
                || input.EndsWith('.'))
            {
                return Invalid;
            }

            return Valid;
        }

        public static string JSONValidator(string input)
        {
            const int two = 2;
            if (string.IsNullOrEmpty(input))
            {
                return Invalid;
            }

            if (!input.EndsWith('"') || !input.StartsWith('"'))
            {
                return Invalid;
            }

            return AnalyzeContent(input.Substring(1, input.Length - two));
        }

        private static string AnalyzeContent(string content)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (char.IsControl(content, i))
                {
                    return Invalid;
                }

                if (content[i] == '"' || content[i] == '/')
                {
                    return content[i - 1] != '\\' ? Invalid : Valid;
                }

                if (content[i] == '\\' && CheckEscapeCharacters(content.Substring(i - 1)) != Valid)
                {
                    return Invalid;
                }
            }

            return Valid;
        }

        private static string CheckEscapeCharacters(string content)
        {
            string[] validCharacters = { "\\b", "\\f", "\\n", "\\r", "\\t", "\\\\", "\\\\u", "\\\"", "\\/" };
            bool foundValidCharacter = false;
            for (int i = 0; i < validCharacters.Length; i++)
            {
                if (content.Contains(validCharacters[i]))
                {
                    foundValidCharacter = true;

                    if (validCharacters[i] == "\\\\u" && CheckUnicode(content) == Invalid)
                    {
                         foundValidCharacter = false;
                    }
                }
            }

            return foundValidCharacter ? Valid : Invalid;
        }

        private static string CheckUnicode(string content)
        {
            const int A = 65;
            const int F = 70;
            const int a = 97;
            const int f = 102;
            const int unicodeLength = 4;
            int start = content.IndexOf('u') + 1;
            bool result = false;
            for (int i = start; i < start + unicodeLength; i++)
            {
                if (char.IsDigit(content[i]))
                {
                    result = true;
                }
                else if ((content[i] >= A && content[i] <= F) ||
                    (content[i] >= a && content[i] <= f))
                {
                    result = true;
                }
            }

            return result ? Valid : Invalid;
        }
    }
}