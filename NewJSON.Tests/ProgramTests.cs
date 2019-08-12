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

        [Fact]
        public void NumberInputIsEmptyShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONNumberValidator(""));
        }

        [Fact]
        public void NumberInputIsNotNumberShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONNumberValidator("abc"));
        }

        [Fact]
        public void NumberInputIsNumberShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("234"));
        }

        [Fact]
        public void NumberInputStartsWithZeroAndIsNotSubunitaryShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONNumberValidator("012"));
        }

        [Fact]
        public void NumberInputStartsWithZeroAndIsSubunitaryShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("0.12"));
        }

        [Fact]
        public void NumberInputStartsWithMinusShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("-123"));
        }

        [Fact]
        public void NumberInputContainsExponentShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("12.123e3"));
        }

        [Fact]
        public void NumberInputContainsExponentsShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("12.123E+3"));
        }

        [Fact]
        public void NumberInputEndsWithPositiveExponentShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONNumberValidator("12.123E"));
        }

        [Fact]
        public void NumberInputEndsWithPointShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONNumberValidator("12."));
        }

        [Fact]
        public void NumberInputEndsWithMinusShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.JSONNumberValidator("12-"));
        }

        [Fact]
        public void NumberInputIsFractionaryShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("12.34"));
        }

        [Fact]
        public void NumberInputWithNegativeExponentShouldReturnValid()
        {
            Assert.Equal("Valid", Program.JSONNumberValidator("12.123E-2"));
        }

        [Fact]
        public void NumberInputEmptyShouldReturnValid()
        {
            Assert.Equal("Invalid", Program.ManualNumberValidator(""));
        }

        [Fact]
        public void NumberInputShouldReturnValid()
        {
            Assert.Equal("Valid", Program.ManualNumberValidator("123"));
       }

        [Fact]
        public void NumberInputContainsLettersShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.ManualNumberValidator("123A"));
        }

        [Fact]
        public void NumberInputStartingWithZeroShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.ManualNumberValidator("012"));
        }

        [Fact]
        public void NumberInputIsSubunitaryShouldReturnValid()
        {
            Assert.Equal("Valid", Program.ManualNumberValidator("0.12"));
        }

        [Fact]
        public void NumberInputIsNegativeShouldReturnValid()
        {
            Assert.Equal("Valid", Program.ManualNumberValidator("-123"));
        }

        [Fact]
        public void NumberContainsExponenteShouldReturnValid()
        {
            Assert.Equal("Valid", Program.ManualNumberValidator("12.123e3"));
        }

        [Fact]
        public void NumberContainsExponentOfEShouldReturnValid()
        {
            Assert.Equal("Valid", Program.ManualNumberValidator("12.123E3"));
        }

        [Fact]
        public void NumberContainsExponentOfEFollowedByPlusShouldReturnValid()
        {
            Assert.Equal("Valid", Program.ManualNumberValidator("12.123E+3"));
        }

        [Fact]
        public void NumberContainPlusWithoutExponentShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.ManualNumberValidator("12.123+3"));
        }

        [Fact]
        public void NumberStartingWithPointShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.ManualNumberValidator(".123"));
        }

        [Fact]
        public void NumberEndingWithPointShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.ManualNumberValidator("123."));
        }
    }
}
