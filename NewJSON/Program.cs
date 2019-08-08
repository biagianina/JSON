﻿using System;

namespace NewJSON
{
    public class Program
    {
        public const string Invalid = "Invalid";
        public const string Valid = "Valid";

        public static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(JSONValidator(input));
            Console.Read();
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
            }

            if (content.Contains('\\'))
            {
                return CheckEscapeCharacters(content);
            }

            return Valid;
        }

        private static string CheckEscapeCharacters(string content)
        {
            char[] validCharacters = { 'b', 'f', 'n', 'r', 't', '\\', '/', '"' };
            bool foundValidCharacter = false;
            char escapeNextChar = content[content.IndexOf('\\') + 1];
            char unicodeChar = content[content.IndexOf('\\') + 2];
            for (int i = 0; i < validCharacters.Length; i++)
            {
                if (validCharacters[i] == escapeNextChar)
                {
                    foundValidCharacter = true;
                    if (escapeNextChar == '\\' && unicodeChar == 'u')
                    {
                        return CheckUnicode(content);
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