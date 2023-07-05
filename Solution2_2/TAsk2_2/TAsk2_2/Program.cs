using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace TAsk2_2
{
    internal class Program
    {
        public static bool IsDraw(string[,] board)
        {
            // Check each row

            List<bool> possibilities = new List<bool>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                possibilities.Add(!IsWinPossible(board[i, 0], board[i, 1], board[i, 2]));
            }

            // Check each column
            for (int i = 0; i < 3; i++)
            {
                possibilities.Add(!IsWinPossible(board[0, i], board[1, i], board[2, i]));
            }

            // Check the diagonals
            possibilities.Add(!IsWinPossible(board[0, 0], board[1, 1], board[2, 2]) ||
                              !IsWinPossible(board[0, 2], board[1, 1], board[2, 0]));


            // If no draw condition is found, return false
            return possibilities.Count(x => x == true) >= 6;
        }

        private static bool IsWinPossible(string cell1, string cell2, string cell3)
        {
            if ((cell1 == "X" || cell2 == "X" || cell3 == "X") && (cell1 == "O" || cell2 == "O" || cell3 == "O"))
            {
                return false;
            }

            return true;
        }

        private static bool IsWin(string[,] array, string player)
        {
            int flag = 0;
            int flag2 = 0;

            //Checking rows and columns

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == player) flag++;
                    {
                        if (flag == array.GetLength(0)) return true;
                    }
                    if (array[j, i] == player) flag2++;
                    {
                        if (flag2 == array.GetLength(1)) return true;
                    }
                }

                flag = 0;
                flag2 = 0;
            }

            flag = 0;

//Checking diagonal
            for (int k = 0; k < array.GetLength(0); k++)
            {
                if (array[k, array.GetLength(1) - 1 - k] == player) flag++;
            }

            if (flag == array.GetLength(0))
                return true;
            flag = 0;
//Checking diagonal
            for (int k = 0; k < array.GetLength(0); k++)
            {
                if (array[k, k] == player) flag++;
            }

            if (flag == array.GetLength(1))
                return true;
            return false;
        }


        static void Turn(string player, string[,] array, out int cell, int size, out int row, out int col)
        {
            cell = 0;
            row = 0;
            col = 0;
            string input;
            bool retryFlag = false;
            do
            {
                Console.WriteLine($"{player}, your turn. Choose your position");
                input = Console.ReadLine();

                try
                {
                    cell = int.Parse(input);

                    row = cell / size; //calculating the exact row and colom by user's input cell
                    col = cell % size;

                    if (array[row, col] == "X" || array[row, col] == "O")
                    {
                        continue;
                    }

                    array[row, col] = player;

                    Print(array);
                    retryFlag = true;
                }
                catch (Exception e)
                {
                    retryFlag = false;
                }
            } while (retryFlag == false);
        }

        static void Print(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (array[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write($"[{array[i, j]}]\t");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

        static double CalculatingDistance(int inputComputerCell, int inputUserCell)
        {
            CalculatingCell(inputComputerCell, 3, out int computerCellRow, out int computerCellCol);
            CalculatingCell(inputUserCell, 3, out int userCellRow, out int userCellCol);

            double distance =
                Math.Sqrt(Math.Abs(Math.Pow(computerCellRow - userCellRow, 2) +
                                   Math.Pow(computerCellCol - userCellCol, 2)));
            return distance;
        }

        static void CalculatingCell(int inputCellNumber, int size, out int cellRow, out int cellCol)
        {
            cellRow =
                inputCellNumber / size; //calculating the exact row and column by computer's cell
            cellCol = inputCellNumber % size;
        }

        static void ComputerSuperPower()
        {
            const string computer = "X";
            const string player = "O";
            int size = 3;
            string[,] array = new string[size, size];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
                    Console.Write($"[{array[i, j]}]\t");
                }

                Console.WriteLine();
            }

            // while (true)
            // {
            //     GetBestMove(array, out int bestX, out int bestY);
            //     array[bestX, bestY] = "X";
            //     
            //     if (IsWin(array, "X"))
            //     {
            //         Console.WriteLine("X won!");
            //     }
            //
            //     if (IsDraw(array))
            //     {
            //         Console.WriteLine("Tie!");
            //     }
            //     
            //     Turn("O", array, out _, 3, out _, out _);
            //
            // }

            //First step in the center (cell = 4)
            CalculatingCell(4, 3, out int computerCellRow, out int computerCellCol);
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");

            Console.WriteLine("Computer chose 4");
            array[computerCellRow, computerCellCol] = "X";
            Print(array);

            Turn("O", array, out int userCell, 3, out int row, out int col);
            //Second step as far as it's possible from O's stepdouble
            double maxDistance = -1;
            int minCell = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] != "X" && array[i, j] != "Y")
                    {
                        int cell = i * size + j;
                        double distance = CalculatingDistance(cell, userCell);
                        if (distance > maxDistance)
                        {
                            maxDistance = distance;
                            minCell = cell;
                        }
                    }
                }
            }

            row = minCell / size;
            col = minCell % size;

            array[row, col] = "X";

            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");

            Print(array);

            Turn("O", array, out userCell, 3, out row, out col);

            // Проверяем, может ли противник победить следующим ходом, и блокируем его ход
            int bestY = -1;
            int bestX = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] != player && array[i, j] != computer)
                    {
                        array[i, j] = player;
                        if (IsWin(array, player))
                        {
                            bestX = i;
                            bestY = j;
                            array[i, j] = (i * 3 + j).ToString();
                        }

                        array[i, j] = (i * 3 + j).ToString();
                    }
                }
            }
            

            // игрок может победить
            if (bestX != -1 || bestY != -1)
            {
                array[bestX, bestY] = computer;
            }
            
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            
            Print(array);
            
        }


        // public static void GetBestMove(string[,] array, out int bestX, out int bestY)
        // {
        //     const string player = "O";
        //     const string computer = "X";
        //     bestX = -1;
        //     bestY = -1;
        //
        //     // Проверка на первый ход, если так - выбираем центральную ячейку
        //     if (array[1, 1] == "4")
        //     {
        //         bestX = 1;
        //         bestY = 1;
        //         return;
        //     }
        //
        //     // Проверяем, можем ли мы победить следующим ходом
        //     for (int i = 0; i < 3; i++)
        //     {
        //         for (int j = 0; j < 3; j++)
        //         {
        //             if (array[i, j] != player && array[i, j] != computer)
        //             {
        //                 array[i, j] = computer;
        //                 if (IsWin(array, computer))
        //                 {
        //                     bestX = i;
        //                     bestY = j;
        //                     array[i, j] = (i * 3 + j).ToString();
        //                     return;
        //                 }
        //
        //                 array[i, j] = (i * 3 + j).ToString();
        //             }
        //         }
        //     }
        //
        // // Проверяем, может ли противник победить следующим ходом, и блокируем его ход
        // for (int i = 0; i < 3; i++)
        // {
        //     for (int j = 0; j < 3; j++)
        //     {
        //         if (array[i, j] != player && array[i, j] != computer)
        //         {
        //             array[i, j] = player;
        //             if (IsWin(array, player))
        //             {
        //                 bestX = i;
        //                 bestY = j;
        //                 array[i, j] = (i * 3 + j).ToString();
        //                 return;
        //             }
        //
        //             array[i, j] = (i * 3 + j).ToString();
        //         }
        //     }
        // }

        // Если не можем победить и не нужно блокировать, выбираем любую свободную ячейку
        //     for (int i = 0; i < 3; i++)
        //     {
        //         for (int j = 0; j < 3; j++)
        //         {
        //             if (array[i, j] != player && array[i, j] != computer)
        //             {
        //                 bestX = i;
        //                 bestY = j;
        //                 return;
        //             }
        //         }
        //     }
        // }


        // 1 ход: всегда в центр;
        // 2 ход: в угол, который дальше всего от предыдущего хода ноликов;
        //     3 ход: защита от попыток нолика чет выстроить или, что вероятнее, – снова ход в угол;
        //     4 ход: тут у вас в наличии либо уже имеются две выигрышные линии, и вы гасите его, либо нолик прикрыл тылы, и исход – ничья.


        public static void Main(string[] args)
        {
            int input;
            do
            {
                Console.WriteLine("Choose , 1 - with your friend, 2 to play with computer");
                input = int.Parse(Console.ReadLine());
            } while ((input != 1) && (input != 2));

            if (input == 1)
            {
                int size;
                do
                {
                    Console.WriteLine("Enter size of field");
                    size = int.Parse(Console.ReadLine());
                } while (size < 3);

                if (size == 3)
                {
                    Multiplayer(size);
                }
                else
                {
                    MultiplayerBigField(size);
                }
            }
            else
            {
                ComputerSuperPower();
            }
        }

        static void Multiplayer(int size)
        {
            string[,] array = new string[size, size];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
                    Console.Write($"[{array[i, j]}]\t");
                }

                Console.WriteLine();
            }

            while (true)
            {
                Turn("X", array, out int _, size, out int _, out int _);
                //(string player, string[,] array, out int cell, int size, out int row, out int col)
                if (IsWin(array, "X"))
                {
                    Console.WriteLine("X won!");
                    return;
                }

                if (IsDraw(array))
                {
                    Console.WriteLine("It's a tie!");
                    return;
                }

                Turn("O", array, out _, size, out _, out _);
                if (IsWin(array, "O"))
                {
                    Console.WriteLine("O won!");
                    return;
                }

                if (IsDraw(array)) //turn off this loop in case of field size > 3
                {
                    Console.WriteLine("It's a tie!");
                    return;
                }
            }
        }

        static void MultiplayerBigField(int size)
        {
            string[,] array = new string[size, size];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
                    Console.Write($"[{array[i, j]}]\t");
                }

                Console.WriteLine();
            }

            int step = 0;
            while (true)
            {
                Turn("X", array, out _, size, out _, out _);
                step++;
                if (IsWin(array, "X"))
                {
                    Console.WriteLine("X won!");
                    return;
                }

                if (step == Math.Pow(size, 2))
                {
                    Console.WriteLine("It's a tie!");
                    return;
                }

                Turn("O", array, out _, size, out _, out _);
                if (IsWin(array, "O"))
                {
                    Console.WriteLine("O won!");
                    return;
                }
            }
        }
    }
}