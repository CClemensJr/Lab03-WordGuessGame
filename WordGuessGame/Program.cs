using System;
using System.IO;

namespace WordGuessGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "dictionary.txt";

            ReadFile(path);
        }

        static bool ReadFile(string path)
        {
            string[] readText = File.ReadAllLines(path);

            if (readText.Length > 0) return true;

            return false;
        }
    }
}
