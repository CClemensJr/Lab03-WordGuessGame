using System;
using System.IO;

namespace WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../wordbank.txt";

            ShowWordBank(path);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadLine();
        }


        /**
         * FILE METHODS
         **/

        /// <summary>
        /// ReadWordBank takes a path to text file and then opens (and closes) it using File.AllLines. The text read from File.AllLines is placed in an array and return to the method that call it.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>An array of strings</returns>
        public static string[] ReadWordBank (string path)
        {
            try
            {
                string[] words = File.ReadAllLines(path);

                return words;
            }
            catch (Exception error)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(error.Message);
            }

            return null;
        }

        /// <summary>
        /// This method takes a path to a text file, an array of words, and a new word to add to the array. The method creates a new array of a size equal to the original array plus the new word and uses a for loop to iterate over the new array and assign it the values of the old one. When at the last element of the array, the new word is inserted. The WriteAllLines method of the File class is then used to write the content of the new array into the file. The method then calls the ReadWordBank method which returns an array of words from the updated file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newWord"></param>
        /// <param name="words"></param>
        /// <returns>An array of words including the added word</returns>
        public static string[] AddWord(string path, string newWord, string[] words)
        {
            try
            {
                string[] updatedWords = new string[(words.Length + 1)];

                for (int i = 0; i < updatedWords.Length; i++)
                {
                    if (i == (updatedWords.Length - 1))
                    {
                        updatedWords[i] = newWord;
                    }
                    else
                    {
                        updatedWords[i] = words[i];
                    }
                }

                File.WriteAllLines(path, updatedWords);

                return ReadWordBank(path);
            }
            catch (Exception error)
            {
                Console.WriteLine("The word could not be added:");
                Console.WriteLine(error.Message);
            }

            return null;
        }

        /// <summary>
        /// This method takes a path to a text file, an array of words, an old word that will be edited, and a new word that is the edited version of the original (old) word. The method creates a new array of a size equal to the original array uses a for loop to iterate over the new array and assign the values of the old one. When an index contains the value of the old word, then new word is inserted in it's stead and the iteration continues. The WriteAllLines method of the File class is then used to write the content of the new array into the file. The method then calls the ReadWordBank method which returns an array of words from the updated file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="oldWord"></param>
        /// <param name="newWord"></param>
        /// <param name="words"></param>
        /// <returns>An array of words including the edited word</returns>
        public static string[] EditWord(string path, string oldWord, string newWord, string[] words)
        {
            try
            {
                string[] updatedWords = new string[(words.Length)];

                for (int i = 0; i < updatedWords.Length; i++)
                {
                    if (words[i].Contains(oldWord))
                    {
                        updatedWords[i] = newWord;
                    }
                    else
                    {
                        updatedWords[i] = words[i];
                    }
                }

                File.WriteAllLines(path, updatedWords);

                return ReadWordBank(path);
            }
            catch (Exception error)
            {
                Console.WriteLine("The word could not be added:");
                Console.WriteLine(error.Message);
            }

            return null;
        }

        /// <summary>
        /// This method takes a path, an array of words, and a word to be deleted. A new array is created that is equal to the length of the original array minus one, since a word needs to be deleted. A for loop is used to iterate over the new array while assigning values from the original array to it. When the value at i index of the original array is equal to the word to be deleted, the next value in the original array is assigned and the iterator is updated twice. File.WriteAllLines is used to write the contents of the new array to the file and then the contents of the file are returned when ReadWordBank is called.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="deleteWord"></param>
        /// <param name="words"></param>
        /// <returns>An array of words minus the deleted word</returns>
        public static string[] DeleteWord(string path, string deleteWord, string[] words)
        {
            try
            {
                string[] updatedWords = new string[(words.Length - 1)];

                for (int i = 0; i < updatedWords.Length; i++)
                {
                    if (words[i].Contains(deleteWord))
                    {
                        updatedWords[i] = words[i + 1];

                        i++;
                    }
                    else
                    {
                        updatedWords[i] = words[i];
                    }
                }

                File.WriteAllLines(path, updatedWords);

                return ReadWordBank(path);
            }
            catch (Exception error)
            {
                Console.WriteLine("The word could not be added:");
                Console.WriteLine(error.Message);
            }

            return null;
        }



        /**
         * GAMEPLAY METHODS
         **/

        static string GetRandomWord(string path)
        {
            try
            {
                string[] wordBank = ReadWordBank(path);
            }
            catch (Exception error)
            {
                Console.WriteLine("The word could not be retrieved: ");
                Console.WriteLine(error.Message);
            }

            return null;
        }
         


        /**
         * INTERFACE METHODS
         **/

        /// <summary>
        /// ReadWordBank takes a path to text file and then sends it to ReadWordBank. ReadWordBank returns an array that is assigned to a words array and then the words are rendered in the console
        /// </summary>
        static void ShowWordBank(string path)
        {
            string[] words = ReadWordBank(path);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }


}
