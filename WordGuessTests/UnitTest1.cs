using System;
using Xunit;
using WordGuessGame;

namespace WordGuessTests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldBeAbleToEditWordsInFile()
        {
            string path = "dictionary.txt";
            string word = "yoke";
            string editedWord = "yokes";

            Assert.Equal(editedWord, Program.EditFile(path, word));
        }

        [Fact]
        public void ShouldBeAbleToAddWordsToFile()
        {
            string path = "dictionary.txt";
            string newWord = "pokes";

            Assert.Equal(newWord, Program.AddToFile(path, newWord));
        }

        [Fact]
        public void ShouldBeAbleToReadWordsFromFile()
        {
            string path = "dictionary.txt";
            string firstWordInFile = "yoke";

            Assert.Equal(firstWordInFile, Program.ReadFile(path, firstWordInFile));
        }

        [Fact]
        public void ShouldDetectIfGuessInWord()
        {
            string word = "yoke";
            string guess = "o";

            Assert.Equal("In word", Program.CheckGuess(word, guess));
        }

        [Fact]
        public void ShouldDetectIfGuessNotInWord()
        {
            string word = "yoke";
            string guess = "o";

            Assert.Equal("Not in word", Program.CheckGuess(word, guess));
        }
    }
}
