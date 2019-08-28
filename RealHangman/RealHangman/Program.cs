using System;
using System.Collections.Generic;

namespace RealHangman
{
    class MainClass
    {
        static string phrase;
        static string secret;
        static List<char> guesses = new List<char>();
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to hangman!");
            start();
        }


        public static void start()
        {
            string[] phrases = { "hangman", "amazing things", "radioactive" };
            Console.WriteLine("Would you like to 1. enter your own phrase or 2. let me pick?");
            string choice = Console.ReadLine();
            if(choice == "1")
            {
                Console.WriteLine("Enter your phrase.");
                phrase = Console.ReadLine();
            }
            else
            {
                Random r = new Random();
                phrase = phrases[r.Next(0, phrases.Length - 1)];
            }
            secret = convertToSecret(phrase);


            while (secret.Contains("_"))
            {
                Console.WriteLine(secret);
                getGuess();

            }

            Console.WriteLine(phrase);
            Console.WriteLine("You Win!!");




            Console.ReadLine();

        }

        public static string convertToSecret(string phrase)
        {
            string ret = "";
            char[] chars = phrase.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char thisChar = chars[i];
                if(thisChar != ' ')
                {
                    ret += "_";
                }
                else
                {
                    ret += " ";
                }
            }
            return ret;
        }
        public static void revealLetters(string guess)
        {
            int index = 0;
            while (index != -1)
            {
                index = phrase.IndexOf(guess, index);
                secret = secret.Substring(0, index) + guess + secret.Substring(index + 1);
            }
        }

        public static void getGuess()
        {
            Console.WriteLine("Enter your guess.");
            string guess = Console.ReadLine();
            if(guess.Length > 1)
            {
                Console.WriteLine("Invalid input!");
                getGuess();
            }
            else if (guesses.Contains(guess.ToCharArray()[0]))
            {
                Console.WriteLine("Already Guessed!");
            }
            else
            {
                if (!phrase.Contains(guess))
                {
                    Console.WriteLine("Wrong guess!");
                    guesses.Add(guess.ToCharArray()[0]);
                }
                else
                {
                    Console.WriteLine("Right!");
                    guesses.Add(guess.ToCharArray()[0]);
                    revealLetters(guess);
                }


            }

        }
    }
}
