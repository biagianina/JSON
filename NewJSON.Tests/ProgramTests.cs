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
            Assert.Equal("Invalid", Program.JSONValidator("\"Te\\//st\""));
        }
    }
}
