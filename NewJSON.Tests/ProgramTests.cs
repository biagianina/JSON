using System;
using Xunit;

namespace NewJSON.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void StringIsNullShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONValidator(""));
        }

        [Fact]
        public void StringStartsAndEndsWithQuotations()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Test\""));
        }

        [Fact]
        public void StringOnlyStartsWithQuotations()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Test"));
        }

        [Fact]
        public void StringContainsQuotationsWithoutEscapeCharacter()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te\"st\""));
        }

        [Fact]
        public void StringContainsSlashWithoutEscapeCharacter()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te//st\""));
        }

        [Fact]
        public void StringContainsSlashWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\//st\""));
        }

        [Fact]
        public void StringContainsQuotationWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\\"st\""));
        }

        [Fact]
        public void StringContainsBackslashWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\\\st\""));
        }

        [Fact]
        public void StringContainsBackslashWithoutEscapeCharacter()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te\\st\""));
        }

        [Fact]
        public void StringContainsBWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\bst\""));
        }

        [Fact]
        public void StringContainsFWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\fst\""));
        }

        [Fact]
        public void StringContainsNWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\nst\""));
        }

        [Fact]
        public void StringContainsUnicodeWithoutEscapeCharacter()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te\\u0097nst\""));
        }

        [Fact]
        public void StringContainsUnicodeWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\\\u0097st\""));
        }

        [Fact]
        public void StringContainsUnicodeWithDigitsAndLettersWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\\\u0Bf7st\""));
        }

        [Fact]
        public void StringContainsUnicodeWithDigitsAndLettersAndAValidCharacterWithEscapeCharacter()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Test\\\\u0Bf7\\nAnother line\""));
        }

        [Fact]
        public void StringContainsOneCorrecttAndOneIncorrectEscapeCharacters()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Test\\n\\q\""));
        }

        [Fact]
        public void StringContainsThreeCorrectEscapeCharacters()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Test\\n\\/\\\\u09Aa\""));
        }

        [Fact]
        public void StringContainsTwoCorrectAndOneIncorrectEscapeCharacters()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Test\\n/\\\\u09Aa\""));
        }
    }
}
