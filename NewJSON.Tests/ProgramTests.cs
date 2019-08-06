using System;
using Xunit;

namespace NewJSON.Tests
{
    public class ProgramTests
    {
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
        public void StringOnlyEndsWithQuotations()
        {
            Assert.Equal("Invalid", Program.JSONValidator("Test\""));
        }

        [Fact]
        public void StringContainsQuotations()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te\"st\""));
        }

        [Fact]
        public void StringContainsSlash()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te/st\""));
        }

        [Fact]
        public void StringContainsBackSlashAlone()
        {
            Assert.Equal("Invalid", Program.JSONValidator("\"Te\\st\""));
        }

        [Fact]
        public void StringContainsBackSlashCharacters()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\nst\""));
        }

        [Fact]
        public void StringContainsUnicodeCharacters()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\\\u0097st\""));
        }

        [Fact]
        public void StringContainsSpaces()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te st\""));
        }

        [Fact]
        public void StringContainsCorrectSlash()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\/st\""));
        }

        [Fact]
        public void StringContainsCorrectQuotations()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Te\\\"st\""));
        }

        [Fact]
        public void StringIsComplex()
        {
            Assert.Equal("Valid", Program.JSONValidator("\"Test\\\\u0097\\nAnother line\""));
        }
    }
}
