using System;
using System.Collections.Generic;

public struct Position
{
    public int row { get; private set; }
    public int col { get; private set; }
    public Position(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}

public enum Color { White, Black }

public class Checker
{
    public String symbol { get; private set; }
    public Color team { get; private set; }
    public Position position { get; set; }

    public Checker(Color team, int row, int col)
    {
        this.position = new Position(row, col);
        this.team = team;
        if(team == Color.Black)
        {
            //int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            //this.symbol = char.ConvertFromUtf32(closedCircleId);
            this.symbol = "b";
        }
        else
        {
            //int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            //this.symbol = char.ConvertFromUtf32(openCircleId);
            this.symbol = "w";
        }
    }

}

public class Board
{
    public List<Checker> checkers;
    public Board()
    {
        checkers = new List<Checker>();
        for (int r = 0; r < 3; r++)
        {
            for (int i = 0; i < 8; i += 2)
            {
                Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                checkers.Add(c);
            }
            for (int i = 0; i < 8; i += 2)
            {
                Checker c = new Checker(Color.Black, 5 + r, (r) % 2 + i);
                checkers.Add(c);
            }
        }
    }

    public Checker GetChecker(Position pos)
    {
        foreach(Checker checker in checkers)
        {
            if(checker.position.Equals(pos))
            {
                return checker;`
            }
        }
        return null;
    }

    public void RemoveChecker(Checker checker)
    {
        checkers.Remove(checker);
    }

    public void MoveChecker(Checker checker, Position dest)
    {
        checker.position = dest;
    }
}

public class Game
{
    private Board board;
    public Game()
    {
        this.board = new Board();
    }

    private bool CheckForWin()
    {
        int whiteCount = 0;
        int blackCount = 0;
        foreach(Checker check in board.checkers)
        {
            if(check.team == Color.Black)
            {
                blackCount++;
            }
            else
            {
                whiteCount++;
            }
        }
        if(blackCount > 0 && whiteCount > 0)
        {
            return false;
        }
        return true;
    }

    public void Start()
    {
        while (!CheckForWin())
        {
            DrawBoard();
            Position from;
            Position to;
            Console.WriteLine("from: row col");
            from = ProcessInput();
            Console.WriteLine("to: row col");
            to = ProcessInput();
            if (IsLegalMove(board.GetChecker(from).team, from, to))
            {
                board.MoveChecker(board.GetChecker(from), to);
            }
            else if (IsCapture(from, to))
            {
                GetCaptureChecker(from, to);
            }
            else
            {
                Console.WriteLine("invalid move!");
                continue;
            }
            board.RemoveChecker(board.GetChecker(from));

        }
    }

    public bool IsLegalMove(Color player, Position src, Position dest)
    {
        //slope is 1
        if (Math.Abs(src.col - dest.col) / Math.Abs(src.row - dest.row) == 1)
        {
            
            if (IsCapture(src, dest))
            {
                return true;
            }
            else
            {
                //only moves 1 forward /side
                if ((player == Color.White && dest.row > src.row) || (player == Color.Black && dest.row < src.row))
                {

                    if(board.GetChecker(dest) == null && board.GetChecker(src) != null)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("no checker found/checker in the way");
                    }
                }
                else
                {
                    Console.WriteLine("Didn't move 1 forward!");
                }
            }
        }
        else
        {
            Console.WriteLine("slope isn't 1!");
        }
        return false;
    }

    public bool IsCapture(Position src, Position dest)
    {
        int row = Math.Abs(src.row - dest.row);
        int col = Math.Abs(src.col - dest.col);

        Position mid = new Position(row, col);

        Checker midChecker = board.GetChecker(mid);
        if(midChecker != null)
        {
            Console.WriteLine(midChecker.position);
        }
        
        //if the slope is 1
        if(Math.Abs(src.col - dest.col) / Math.Abs(src.row - dest.row) == 1)
        {
            //if the difference between the rows/cols is 2
            if(Math.Abs(src.row - dest.row) == 2 && Math.Abs(src.col - dest.col) == 1)
            {
                //if the checkers are different teams
                if(midChecker.team != board.GetChecker(src).team)
                {
                    //if there isnt a checker already at dest
                    if(board.GetChecker(dest) == null)
                    {
                        Console.WriteLine("Capture!");
                        return true;
                    }
                }
            }
        }
        return false;



    }

    public Checker GetCaptureChecker(Position src, Position dest)
    {
        int row = Math.Abs(src.row - dest.row);
        int col = Math.Abs(src.col - dest.col);

        Position toCapture = new Position(row, col);

        Checker toRemove = board.GetChecker(toCapture);

        if(toRemove != null)
        {
            board.RemoveChecker(toRemove);
            return toRemove;
        }
        return null;
    }

    public Position ProcessInput()
    {
        string raw = Console.ReadLine();
        string[] stringVals = raw.Split(' ');
        int row = Convert.ToInt32(stringVals[0]);
        int col = Convert.ToInt32(stringVals[1]);
        return new Position(row, col);
    }

    public void DrawBoard()
    {
        String[][] grid = new String[8][];
        for (int r = 0; r < 8; r++)
        {
            grid[r] = new String[8];
            for (int c = 0; c < 8; c++)
            {
                grid[r][c] = " ";
            }
        }
        foreach (Checker c in board.checkers)
        {
            grid[c.position.row][c.position.col] = c.symbol;
        }

        Console.WriteLine("  0 1 2 3 4 5 6 7");
        for (int r = 0; r < 8; r++)
        {
            Console.Write(r);
            for (int c = 0; c < 8; c++)
            {
                Console.Write($" {grid[r][c]}");
            }
            Console.WriteLine();
        }
    }


}

class Program
{
    public static void Main(String[] args)
    {
        Game game = new Game();
        game.Start();
    }
}
