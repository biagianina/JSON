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
            if (string.IsNullOrEmpty(input))
            {
                return "Invalid";
            }

            if (!input.EndsWith('"'))
            {
                return "Invalid";
            }

            return "Valid";
        }
    }
}