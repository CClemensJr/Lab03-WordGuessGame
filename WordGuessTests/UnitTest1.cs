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
            string[] testWords = Program.ReadWordBank(path);

            Assert.True(testWords.Length > 0);
        }

        [Fact]
        public void ShouldEditWordsInFile()
        {
            string testPath = "../../../../test.txt";
            string oldWord = "testy";
            string newWord = "whoopsie!";
            string[] testArray = { "test", "test", "testy" };
            string[] newTestArray = { "test", "test", "whoopsie!" };

            Assert.Equal(newTestArray, Program.EditWord(testPath, oldWord, newWord, testArray)); ;
        }

        [Fact]
        public void ShouldAddWordsToFile()
        {
            string testPath = "../../../../test.txt";
            string testWord = "test";
            string[] testArray = { "test", "test", "test" };
            string[] newTestArray = { "test", "test", "test", "test" };

            Assert.Equal(newTestArray, Program.AddWord(testPath, testWord, testArray));
        }

        [Fact]
        public void ShouldDeleteWordsFromFile()
        {
            string testPath = "../../../../test.txt";
            string testWord = "testy";
            string[] testArray = { "test", "testy", "test" };
            string[] newTestArray = { "test", "test" };

            Assert.Equal(newTestArray, Program.DeleteWord(testPath, testWord, testArray));
        }

        [Fact]
        public void ShouldDetectIfGuessInWord()
        {
            string word = "yoke";
            char guess = 'o';
            bool isCorrect = Program.CheckGuess(guess, word);

            Assert.True(isCorrect);
        }

        [Fact]
        public void ShouldDetectIfGuessNotInWord()
        {
            string word = "yoke";
            char guess = 'i';
            bool isCorrect = Program.CheckGuess(guess, word);

            Assert.False(isCorrect);
        }
    }
}
