using System;
using System.Collections.Generic;

namespace HanoiRedo
{
    class MainClass
    {
        public static Dictionary<String, Stack<int>> board;
        public static void Main(string[] args)
        {
            board = new Dictionary<string, Stack<int>>();
            board.Add("a", new Stack<int>());
            board.Add("b", new Stack<int>());
            board.Add("c", new Stack<int>());

            board["a"].Push(3);
            board["a"].Push(2);
            board["a"].Push(1);



            while(board["c"].Count < 3)
            {
                printBoard();
                getInput();
            }
            printBoard();
            Console.WriteLine("You Win!!");
            Console.ReadLine();
        }

        public static void getInput()
        {
            Console.WriteLine("Tower From");
            string from = Console.ReadLine();
            Console.WriteLine("Tower To");
            string to = Console.ReadLine();
            if(from.Length == 1 && to.Length == 1)
            {
                move(from, to);
            }
            else
            {
                Console.WriteLine("Invalid Input!");
                getInput();
            }
        }

        public static void move(string from, string to)
        {
            if(board[to].Count == 0 || board[from].Peek() < board[to].Peek())
            {
                board[to].Push(board[from].Pop());
            }
        }

        public static void printBoard()
        {
            Console.Write("a: ");
            int[] a = board["a"].ToArray();
            Array.Reverse(a);
            foreach(int val in a)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();

            Console.Write("b: ");
            int[] b = board["b"].ToArray();
            Array.Reverse(b);
            foreach (int val in b)
            {
                Console.Write(val + " ");
            }

            Console.WriteLine();


            Console.Write("c: ");
            int[] c = board["c"].ToArray();
            Array.Reverse(c);
            foreach (int val in c)
            {
                Console.Write(val + " ");
            }

            Console.WriteLine();
        }

    }
}
