using System;
using System.Collections.Generic;

namespace Mastermind
{
    class MainClass
    {
        //score1 represents correct guesses in incorrect positions
        static int score1;
        //score2 represents correct guesses in correct positions
        static int score2;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");
            bool x = true;
            while (x)
            {
                score1 = 0;
                score2 = 0;
                Console.WriteLine("Enter your guesses:");
                String inp = Console.ReadLine();
                if(!inp.Contains(" "))
                {
                    break;
                }
                String[] guesses = inp.Split(' ');
                String[] colors = getColors();

                for (int i = 0; i < 2; i++)
                {
                    if (colors[i] == guesses[i])
                    {
                        score2++;
                    }

                }
                if (guesses[0] == colors[1])
                {
                    score1++;
                }
                if (guesses[1] == colors[0])
                {
                    score1++;
                }
                Console.WriteLine(score1 + " - " + score2);

            }
           

        }

        public static String[] getColors()
        {
            String[] ret = new String[2];

            Random random = new Random();
            int rand;
            for(int i = 0; i < 2; i++)
            {
                rand = random.Next(3) + 1;
                if(rand == 1)
                {
                    ret[i] = "yellow";
                }
                else if (rand == 2)
                {
                    ret[i] = "red";
                }
                else if (rand == 3)
                {
                    ret[i] = "blue";
                }
            }

            return ret;
        }
    }
}
