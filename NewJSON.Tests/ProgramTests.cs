using System;
using Xunit;

namespace NewJSON.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void StringStartsAndEndsWithQuotations()
        {
            Assert.True(Program.CheckQuotationsStartAndEnd("\"Test\""));
        }

        [Fact]
        public void StringOnlyStartsWithQuotations()
        {
            Assert.False(Program.CheckQuotationsStartAndEnd("\"Test"));
        }

        [Fact]
        public void StringOnlyEndsWithQuotations()
        {
            Assert.False(Program.CheckQuotationsStartAndEnd("Test\""));
        }

        [Fact]
        public void StringContainsQuotations()
        {
            Assert.False(Program.CheckQuotations("\"Te\"st\""));
        }

        [Fact]
        public void StringContainsBackSlashAlone()
        {
            Assert.True(Program.CheckBackslash("\"Te\\st\""));
        }

        [Fact]
        public void StringContainsBackSlashCharacters()
        {
            Assert.True(Program.CheckBackslashPreceededCharacters("\"Te\nst\""));
        }
    }
}
