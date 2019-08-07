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

                if (input[i] == '"' || input[i] == '/' && input[i - 1] != '\\')
                {
                    return invalid;
                }
            }

            return "Valid";
        }
    }
}