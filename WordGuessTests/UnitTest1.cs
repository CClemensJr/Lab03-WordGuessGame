using System;
using Xunit;
using WordGuessGame;

namespace WordGuessTests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReadWordsFromFile()
        {
            string path = "../../../../test.txt";
            string[] testWords = { "test", "test", "test" };

            Assert.Equal(testWords, Program.ReadWordBank(path));
        }

        //[Fact]
        //public void ShouldEditWordsInFile()
        //{
        //    string path = "dictionary.txt";
        //    string word = "yoke";
        //    string editedWord = "yokes";

        //    Assert.Equal(editedWord, Program.UpdateWordBank(path, word));
        //}

        //[Fact]
        //public void ShouldAddWordsToFile()
        //{
        //    string path = "dictionary.txt";
        //    string newWord = "pokes";

        //    Assert.Equal(newWord, Program.AddToWordBank(path, newWord));
        //}

        //[Fact]
        //public void ShouldDetectIfGuessInWord()
        //{
        //    string word = "yoke";
        //    string guess = "o";

        //    Assert.Equal("In word", Program.CheckGuess(word, guess));
        //}

        //[Fact]
        //public void ShouldDetectIfGuessNotInWord()
        //{
        //    string word = "yoke";
        //    string guess = "o";

        //    Assert.Equal("Not in word", Program.CheckGuess(word, guess));
        //}
    }
}
