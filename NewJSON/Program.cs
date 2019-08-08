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
            if (string.IsNullOrEmpty(input))
            {
                return invalid;
            }

            if (!input.EndsWith('"') || !input.StartsWith('"'))
            {
                return invalid;
            }

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (char.IsControl(input, i))
                {
                    return invalid;
                }

                if (input[i] == '"' || input[i] == '/')
                {
                    return input[i - 1] != '\\' ? invalid : "Valid";
                }
            }

            return "Valid";
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