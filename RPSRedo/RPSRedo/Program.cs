using System;

namespace RPSRedo
{
    class MainClass
    {
        static int playerWins = 0;
        static int cpuWins = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");
            string[] moves = { "rock", "paper", "scissors" };
            Random r = new Random();
            string winner;
            while (true)
            {
                Console.WriteLine("1...");
                Console.WriteLine("2...");
                Console.WriteLine("3...");
                Console.WriteLine("Shoot!");
                string input = Console.ReadLine();
                string cpu = moves[r.Next(3)];
                Console.WriteLine($"cpu chose {cpu}");
                if(input == "exit")
                {
                    break;
                }
                winner = evaluateHands(input,cpu);
                if(winner == "player")
                {
                    Console.WriteLine("You win!");
                }
                else if(winner == "cpu")
                {
                    Console.WriteLine("You Lose!");
                }
                else if(winner == "tie")
                {
                    Console.WriteLine("It's a tie!");
                }
                Console.WriteLine($"cpu - {cpuWins}");
                Console.WriteLine($"you - {playerWins}");
            }
        }
        public static string evaluateHands(string player, string cpu)
        {
            if(player == "rock")
            {
                if(cpu == "rock")
                {
                    return "tie";
                }
                if(cpu == "scissors")
                {
                    playerWins++;
                    return "player";
                }
                if(cpu == "paper")
                {
                    cpuWins++;
                    return "cpu";
                }
            }
            if (player == "paper")
            {
                if (cpu == "rock")
                {
                    playerWins++;
                    return "player";
                }
                if (cpu == "scissors")
                {
                    cpuWins++;
                    return "cpu";
                }
                if (cpu == "paper")
                {
                    return "tie";
                }
            }
            if (player == "scissors")
            {
                if (cpu == "rock")
                {
                    cpuWins++;
                    return "cpu";
                }
                if (cpu == "scissors")
                {
                    return "tie";
                }
                if (cpu == "paper")
                {
                    playerWins++;
                    return "player";
                }
            }
            return "Error?";
        }
    }
}
