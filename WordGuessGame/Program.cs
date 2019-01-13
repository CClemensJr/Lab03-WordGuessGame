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
        /// This method takes a path to a atext file, an array of words, and a new word to add to the array. Using the StreamWriter class it, the method iterates over the array and WriteLines it into the file. The method then calls the ReadWordBank method which returns an array of words from the updated file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newWord"></param>
        /// <param name="words"></param>
        /// <returns>An array of words</returns>
        public static string[] AddWordToWordBank(string path, string newWord, string[] words)
        {
            try
            {
                string[] updatedArray = new string[(words.Length + 1)];

                for (int i = 0; i < updatedArray.Length; i++)
                {
                    if (i == (updatedArray.Length - 1))
                    {
                        updatedArray[i] = newWord;
                    }
                    else
                    {
                        updatedArray[i] = words[i];
                    }
                }

                File.WriteAllLines(path, updatedArray);

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
