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

        public static string JSONValidator(string input)
        {
            const string invalid = "Invalid";
            const int two = 2;
            if (string.IsNullOrEmpty(input))
            {
                return invalid;
            }

            if (!input.EndsWith('"') || !input.StartsWith('"'))
            {
                return invalid;
            }

            return AnalyzeContent(input.Substring(1, input.Length - two));
        }

        private static string AnalyzeContent(string content)
        {
            const string invalid = "Invalid";
            const string valid = "Valid";
            for (int i = 0; i < content.Length; i++)
            {
                if (char.IsControl(content, i))
                {
                    return invalid;
                }

                if (content[i] == '"' || content[i] == '/')
                {
                    return content[i - 1] != '\\' ? invalid : valid;
                }
            }

            return valid;
        }

        private static string EscapePreceededCharacters(string input)
        {
            char[] validCharacters = { 'b', 'f', 'n', 'r', 't' };
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < validCharacters.Length; j++)
                {
                    if (input[i] == '\\' && input[i + 1] == validCharacters[j])
                    {
                       return "Valid";
                    }
                }
            }

            return "Invalid";
        }
    }
}