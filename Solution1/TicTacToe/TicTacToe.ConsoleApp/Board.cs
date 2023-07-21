namespace TicTacToe.ConsoleApp;

public class Board
{
    public string[,] Array { get; set; }

    public int GetSize()
    {
        return Array.GetLength(0);
    }
        
    public Board(int size)
    {
        Array = new string[size, size];
        FillArray();
    }

    private void FillArray()
    {
        for (int i = 0; i < Array.GetLength(0); i++)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                Array[i, j] = Convert.ToString(j + Array.GetLength(0) * i);
            }

        }
    }
    public void SetSymbol(int row, int col, string symbol)
    {
        Array[row, col] = symbol;
    }

    public void Print()
    {
        for (int i = 0; i < Array.GetLength(0); i++)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                if (Array[i, j] == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (Array[i, j] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write($"[{Array[i, j]}]\t");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
        
        

}