using System;
using Xunit;
using WordGuessGame;

namespace WordGuessTests
{
    public class UnitTest1
    {
        [Fact]
        public void EditedWordsShouldBeUpdatedInFile()
        {
            string path = "dictionary.txt";
            string word = "yoke";
            string editedWord = "yokes";

            Assert.Equal(editedWord, Program.UpdateFile(path, word));
        }
    }
}
