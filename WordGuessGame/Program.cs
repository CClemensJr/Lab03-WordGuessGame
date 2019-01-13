using System;
using System.IO;

namespace WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../wordbank.txt";

            string message = ReadWordBank(path);

            Console.WriteLine(message);
            Console.ReadLine();
        }

        /// <summary>
        /// ReadWordBank takes a path to text file and then opens (and closes) it using StreamReader class in the Stream.IO namespace. The method reads through a word in the file and outputs it to the screen before moving on to the next word. This repeats until there are no more words to display. If the file cannot be opened, an error message is sent to the user.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static string ReadWordBank (string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string word;

                    while ((word = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(error.Message);
            }

            return "\n\nPress any key to exit...";
        }
    }


}
