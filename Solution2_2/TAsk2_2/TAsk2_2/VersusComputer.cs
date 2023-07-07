using System;
using System.Threading;

namespace TAsk2_2
{
    public class VersusComputer
    {
        public Board board;
        public VersusComputer()
        {
            board = new Board(3);
        }
        
        public void PrintPause() // печать задержки
        {
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
        }
        
        public void ComputerSuperPower()
        {
            const string computer = "X";
            const string player = "O";

            //First step in the center (cell = 4)
            Logic.CalculatingCell(4, 3, out int computerCellRow, out int computerCellCol);
            PrintPause();
        
            Console.WriteLine("Computer chose 4");
            board.SetSymbol(computerCellRow, computerCellCol, "X");
            board.Print();
        
            Logic.Turn("O", board.Array, out int userCell, 3, out int row, out int col);
            board.Print();
            
            //Second step as far as it's possible from O's second step
            double maxDistance = -1;
            int farCell = 0;
        
            if ((userCell == 1) || (userCell == 3) || (userCell == 5) || (userCell == 7))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board.Array[i, j] != "X" && board.Array[i, j] != "O")
                        {
                            int cell = i * board.GetSize() + j;
                            double distance = Logic.CalculatingDistance(cell, userCell);
                            if (distance > maxDistance)
                            {
                                maxDistance = distance;
                                farCell = cell;
                            }
                        }
                    }
                }
        
                row = farCell / board.GetSize();
                col = farCell % board.GetSize();
        
                board.SetSymbol(row, col, "X");
            }
        
            else
            {
                int cellAttempt = 0;
        
                do
                {
                    cellAttempt += 2;
                    row = cellAttempt / 3;
                    col = cellAttempt % 3;
                } while (board.Array[row, col] == computer || board.Array[row, col] == player);
            }
        
            board.SetSymbol(row, col, "X");
        
            PrintPause();
        
            board.Print();
        
            Logic.Turn("O", board.Array, out userCell, 3, out row, out col);
            board.Print();
        
            while (true)
            {
                TurnComputer(board.Array, computer, player);
                if (Logic.IsWin(board.Array, "X"))
                {
                    Console.WriteLine("X won!");
                    return;
                }
        
                if (Logic.IsDraw(board.Array)) //turn off this loop in case of field size > 3
                {
                    Console.WriteLine("It's a tie!");
                    return;
                }
        
                Logic.Turn("O", board.Array, out userCell, 3, out row, out col);
                board.Print();
                if (Logic.IsWin(board.Array, "O"))
                {
                    Console.WriteLine("O won!");
                    return;
                }
        
                if (Logic.IsDraw(board.Array)) //turn off this loop in case of field size > 3
                {
                    Console.WriteLine("It's a tie!");
                    return;
                }
            }
        }
        
        public void TurnComputer(string[,] array, string computer, string player)
        {
            //Случай 1. Проверяем, можем ли мы победить следующим ходом.
        
            if (Logic.WinThisTurnComputer(array, player, computer))
            {
                PrintPause();
                board.Print();
                return;
            }
        
            // Проверяем, может ли противник победить следующим ходом, и блокируем его ход.
            if (Logic.WinThisTurnPlayer(array, player, computer))
            {
                PrintPause();
                board.Print();
                return;
            }
        
            //Если оба варианта не подходят, ходим рандомно
            
            Random random = new Random();
            int computerCol;
            int computerRow;
            do
            {
                int randomCell = random.Next(9);
                computerRow = randomCell / 3;
                computerCol = randomCell % 3; //calculating the exact row and colom by user's input cell
            } while (array[computerRow, computerCol] == computer ||
                     array[computerRow, computerCol] == player /*|| !IsDraw(array)*/);
        
            array[computerRow, computerCol] = "X";
            PrintPause();
            board.Print();
        }
    }
}