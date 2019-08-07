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
    }
}
