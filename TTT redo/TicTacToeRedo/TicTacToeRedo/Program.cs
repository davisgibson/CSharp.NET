using System;

namespace TicTacToeRedo
{
    class MainClass
    {
        public static string[,] board = new string[3, 3];
        public static bool xTurn = true;
        public static bool gameOver = false;
        public static string winner;
        public static void Main(string[] args)
        {
            //initialize the board
            clearBoard();


            while (!gameOver)
            {
                printBoard();
                Console.WriteLine("Enter your move (col row)");
                string moveString = Console.ReadLine();
                int col;
                int row;
                try
                {
                    col = Convert.ToInt16(moveString.Split(' ')[0]) - 1;
                    row = Convert.ToInt16(moveString.Split(' ')[1]) - 1;
                }
                catch
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }
                if(!move(col, row))
                {
                    Console.WriteLine("Invalid move!");
                }
                isGameOver();
                compMove();
                isGameOver();
            }
            printBoard();
            Console.WriteLine("Winner is: " + winner);
            Console.ReadLine();
        }

        public static void clearBoard()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    board[i, j] = " ";
                }
            }
        }

        public static void compMove()
        {
            Random ran = new Random();
            bool done = false;
            while (!done)
            {
                int row = ran.Next(0, 3);
                int col = ran.Next(0, 3);
                if (move(col, row))
                {
                    done = true;
                }
            }
        }

        public static bool move(int col, int row)
        {
            if(board[row,col] == " ")
            {
                if (xTurn)
                {
                    board[row, col] = "X";
                }
                else
                {
                    board[row, col] = "O";
                }
                xTurn = !xTurn;
                return true;
            }
            return false;
        }

        public static void printBoard()
        {
            Console.WriteLine("   1  2  3");
            for(int i = 0; i < 3; i++)
            {
                Console.Write((i + 1) + " ");
                for(int j = 0; j < 3; j++)
                {
                    Console.Write("[" + board[i, j] + "]");
                }
                Console.WriteLine();
            }
        }

        public static void isGameOver()
        {
            int count;
            //check rows

            for (int i = 0; i < 3; i++)
            {
                count = 0;
                for(int j = 0; j < 3; j++)
                {
                    if(board[i,j] == "X")
                    {
                        count++;
                    }
                    else if(board[i,j] == "O")
                    {
                        count--;
                    }
                }
                if(count == 3)
                {
                    winner = "X";
                    gameOver = true;
                }
                else if (count == -3)
                {
                    winner = "O";
                    gameOver = true;
                }
            }

            //check columns
            for (int i = 0; i < 3; i++)
            {
                count = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, i] == "X")
                    {
                        count++;
                    }
                    else if (board[j, i] == "O")
                    {
                        count--;
                    }
                }
                if (count == 3)
                {
                    winner = "X";
                    gameOver = true;
                }
                else if (count == -3)
                {
                    winner = "O";
                    gameOver = true;
                }
            }

            //check diagonals
            if(board[0,0] != " " && board[0,0] == board[1,1] && board[1,1] == board[2, 2])
            {
                if (board[0, 0] == "X")
                {
                    winner = "X";
                    gameOver = true;
                }
                else if (board[0, 0] == "O")
                {
                    winner = "O";
                    gameOver = true;
                }
            }
            else if (board[2, 0] != " " && board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
            {
                if (board[2, 0] == "X")
                {
                    winner = "X";
                    gameOver = true;
                }
                else if (board[2, 0] == "O")
                {
                    winner = "O";
                    gameOver = true;
                }
            }
        }

    }
}
