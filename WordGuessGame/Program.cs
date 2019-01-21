using System;
using System.IO;

namespace WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string path = "../../../../wordbank.txt";

            //ShowWordBank(path);
            //ShowMysteryWord(path);

            ShowMenu();

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

        /// <summary>
        /// This method takes a file path and sends it to ReadWordBank to fill up a newly created string array with the contents of the file. Then a Random object is instantiated and a random index created using the Next method of the Random class and the length of the array. A random word variable is created and set to the value of the array at the random index. The method then returns the random word.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A random word.</returns>
        static string GetRandomWord(string path)
        {
            try
            {
                string[] wordBank = ReadWordBank(path);

                Random random = new Random();
                int index = random.Next(wordBank.Length);

                string randomWord = wordBank[index];

                return randomWord;

            }
            catch (Exception error)
            {
                Console.WriteLine("The word could not be retrieved: ");
                Console.WriteLine(error.Message);
            }

            return null;
        }
         
        /// <summary>
        /// This method takes the user's input and converts it to char.
        /// </summary>
        /// <returns>A character</returns>
        static char GetGuess()
        {
            try
            {
                Console.Write("\n\nWhat letter do you think is in the word?  ");

                string guess = Console.ReadLine();

                return Convert.ToChar(guess);
                
            }
            catch (Exception error)
            {
                Console.WriteLine("I am sorry but I was unable to collect your input:");
                Console.WriteLine(error.Message);
            }

            return '_';
        }

        /// <summary>
        /// This method takes in the word and a guess and returns true or false depending on if the word contains the guess.
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="mysterWord"></param>
        /// <returns>True if the guess is correct, false if it isn't.</returns>
        public static bool CheckGuess(char guess, string mysterWord)
        {
            if (mysterWord.Contains(guess)) return true;

            return false;
        }

        /**
         * INTERFACE METHODS
         **/

        /// <summary>
        /// ShowWordBank takes a path to text file and then sends it to ReadWordBank. ReadWordBank returns an array that is assigned to a words array and then the words are rendered in the console. The user is able to add, edit, or delete words
        /// </summary>
        static void ShowWordBank(string path)
        {
            Console.Clear();

            string[] words = ReadWordBank(path);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            string userInput = "";

            while (userInput.ToUpper() != "X")
            {
                Console.Write("What would you like to do?  \t");
                Console.Write("(A)dd a word \t");
                Console.Write("(E)dit a word \t");
                Console.Write("(D)elete a word \t");
                Console.WriteLine("E(x)it");

                userInput = Console.ReadLine();

                switch (userInput.ToUpper())
                {

                    case "A":
                        Console.Write("\n\nWhat word would you like to add? ");
                        string addWord = Console.ReadLine();
                        string[] addWords = ReadWordBank(path);

                        AddWord(path, addWord, addWords);

                        ShowWordBank(path);

                        break;

                    case "E":
                        Console.Write("\n\nWhat word would you like to edit? ");
                        string oldWord = Console.ReadLine();

                        Console.Write("\n\nWhat would you like to change it to? ");
                        string newWord = Console.ReadLine();

                        string[] editWords = ReadWordBank(path);

                        EditWord(path, oldWord, newWord, editWords);

                        ShowWordBank(path);

                        break;

                    case "D":
                        Console.Write("\n\nWhat word would you like to delete? ");
                        string deleteWord = Console.ReadLine();
                        string[] deleteWords = ReadWordBank(path);

                        DeleteWord(path, deleteWord, deleteWords);

                        ShowWordBank(path);

                        break;

                    case "X":
                        ShowMenu();

                        break;

                    default:
                        Console.WriteLine("Please enter a valid menu option");

                        break;
                }
            }
        }

        /// <summary>
        /// This method takes a path and sends it to get a random word. It then creates an array of the same length as the random word and uses iteration to fill up the empty spaces with underscores and display them on the screen
        /// </summary>
        /// <param name="path"></param>
        static void ShowMysteryWord(string path)
        {
            Console.Clear();
            string mysteryWord = GetRandomWord(path);
            int lettersInWord = mysteryWord.Length;
            string [] displayWord = new string[mysteryWord.Length];
            string guesses = "";

            for (int i = 0; i < displayWord.Length; i++)
            {
                displayWord[i] = " _ ";
                Console.Write(displayWord[i]);
            }
            Console.WriteLine("\n\nGuesses: ");

            char guess;
            bool isCorrect;
            
            while (!string.Equals(mysteryWord, displayWord.ToString()))
            {
                Console.Write("\n\nGuess a letter in the word: ");
                guess = GetGuess();
                isCorrect = CheckGuess(guess, mysteryWord);

                if (!isCorrect)
                {
                    guesses += guess;
                }

                for (int j = 0; j < displayWord.Length; j++)
                {
                    if (mysteryWord[j] == guess)
                    {
                        displayWord[j] = $"{ guess }";

                        lettersInWord--;
                    }

                    Console.Write(displayWord[j]);
                }

                Console.WriteLine($"\n\nGuesses: { guesses }");

                if (lettersInWord == 0)
                {
                    Console.WriteLine($"\n\nYou correctly guessed { string.Join("", displayWord)}!");
                    Console.WriteLine("Congratulations!");

                    return;
                }
            }
        }

        /// <summary>
        /// Show menu shows the menu in console and keep the app open until the user decides to exit.
        /// </summary>
        static void ShowMenu()
        {
            try
            {
                string path = "../../../../wordbank.txt";
                string userInput = "";

                while (userInput != "3")
                {
                    Console.Clear();
                    Console.WriteLine("\n 1. Play the Word Guess Game");
                    Console.WriteLine("\n 2. View the word bank");
                    Console.WriteLine("\n 3. Exit\n\n");

                    Console.Write("What would you like to do?  ");

                    userInput = Console.ReadLine();

                    switch (int.Parse(userInput))
                    {
                        case 1:
                            ShowMysteryWord(path);

                            break;

                        case 2:
                            ShowWordBank(path);

                            break;

                        case 3:
                            return;

                        default:
                            Console.WriteLine("Please enter a valid menu option");

                            break;
                    }
                }

            }
            catch (Exception error)
            {
                Console.WriteLine("Your input may have been invalid:");
                Console.WriteLine(error.Message);
            }
        }
    }
}

