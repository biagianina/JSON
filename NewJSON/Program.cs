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

            if (content.Contains('\\'))
            {
                return CheckEscapeCharacters(content);
            }

            return valid;
        }

        private static string CheckEscapeCharacters(string content)
        {
            char[] validCharacters = { 'b', 'f', 'n', 'r', 't', '\\', '/', '"' };
            bool foundValidCharacter = false;
            for (int i = 0; i < validCharacters.Length; i++)
            {
                if (validCharacters[i] == content[content.IndexOf('\\') + 1])
                {
                    foundValidCharacter = true;
                }
            }

            return foundValidCharacter ? "Valid" : "Invalid";
        }
    }
}