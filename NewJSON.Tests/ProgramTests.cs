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
    }
}
