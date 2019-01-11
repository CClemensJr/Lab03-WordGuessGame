using System;
using Xunit;
using WordGuessGame;

namespace WordGuessTests
{
    public class UnitTest1
    {
        [Fact]
        public void FileShouldOpen()
        {
            string path = "dictionary.txt";

            Assert.Equal(true, OpenFile(path));
        }
    }
}
