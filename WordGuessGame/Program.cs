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
