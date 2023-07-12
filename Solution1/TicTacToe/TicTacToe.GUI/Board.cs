using System;

namespace TicTacToe
{
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

        }


        public void SetSymbol(int row, int col, string symbol)
        {
            Array[row, col] = symbol;
        }





    }
}

