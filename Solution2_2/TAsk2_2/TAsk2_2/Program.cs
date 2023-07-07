using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace TAsk2_2
{
    internal class Program
    {
        
        // static void Turn(string player, string[,] array, out int cell, int size, out int row, out int col)
        // {
        //     cell = 0;
        //     row = 0;
        //     col = 0;
        //     string input;
        //     bool retryFlag = false;
        //     do
        //     {
        //         Console.WriteLine($"{player}, your turn. Choose your position");
        //         input = Console.ReadLine();
        //
        //         try
        //         {
        //             cell = int.Parse(input);
        //
        //             row = cell / size; //calculating the exact row and colom by user's input cell
        //             col = cell % size;
        //
        //             if (array[row, col] == "X" || array[row, col] == "O")
        //             {
        //                 continue;
        //             }
        //
        //             array[row, col] = player;
        //
        //             Print(array);
        //             retryFlag = true;
        //         }
        //         catch (Exception e)
        //         {
        //             retryFlag = false;
        //         }
        //     } while (retryFlag == false);
        // }

        // static void Print(string[,] array)
        // {
        //     for (int i = 0; i < array.GetLength(0); i++)
        //     {
        //         for (int j = 0; j < array.GetLength(1); j++)
        //         {
        //             if (array[i, j] == "X")
        //             {
        //                 Console.ForegroundColor = ConsoleColor.Red;
        //             }
        //
        //             if (array[i, j] == "O")
        //             {
        //                 Console.ForegroundColor = ConsoleColor.Green;
        //             }
        //
        //             Console.Write($"[{array[i, j]}]\t");
        //             Console.ResetColor();
        //         }
        //
        //         Console.WriteLine();
        //     }
        // }

        // static double CalculatingDistance(int inputComputerCell, int inputUserCell)
        // {
        //     CalculatingCell(inputComputerCell, 3, out int computerCellRow, out int computerCellCol);
        //     CalculatingCell(inputUserCell, 3, out int userCellRow, out int userCellCol);
        //
        //     double distance =
        //         Math.Sqrt(Math.Abs(Math.Pow(computerCellRow - userCellRow, 2) +
        //                            Math.Pow(computerCellCol - userCellCol, 2)));
        //     return distance;
        // }

        // static void CalculatingCell(int inputCellNumber, int size, out int cellRow, out int cellCol)
        // {
        //     cellRow =
        //         inputCellNumber / size; //calculating the exact row and column by computer's cell
        //     cellCol = inputCellNumber % size;
        // }

        static void PrintPause() // печать задержки
        {
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
        }

        
        // static void TurnComputer(string[,] array, string computer, string player)
        // {
        //     //Случай 1. Проверяем, можем ли мы победить следующим ходом.
        //
        //     if (WinThisTurnComputer(array, player, computer)) return;
        //
        //     // Проверяем, может ли противник победить следующим ходом, и блокируем его ход.
        //     if (WinThisTurnPlayer(array, player, computer)) return;
        //
        //     //Если оба варианта не подходят, ходим рандомно
        //     Random random = new Random();
        //     int computerCol;
        //     int computerRow;
        //     do
        //     {
        //         int randomCell = random.Next(9);
        //         computerRow = randomCell / 3;
        //         computerCol = randomCell % 3; //calculating the exact row and colom by user's input cell
        //     } while (array[computerRow, computerCol] == computer ||
        //              array[computerRow, computerCol] == player /*|| !IsDraw(array)*/);
        //
        //     array[computerRow, computerCol] = "X";
        //     PrintPause();
        //     Print(array);
        // }

        // static void ComputerSuperPower()
        // {
        //     const string computer = "X";
        //     const string player = "O";
        //     int size = 3;
        //     string[,] array = new string[3, 3];
        //
        //     //заполнение массива
        //
        //     for (int i = 0; i < array.GetLength(0); i++)
        //     {
        //         for (int j = 0; j < array.GetLength(1); j++)
        //         {
        //             array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
        //             Console.Write($"[{array[i, j]}]\t");
        //         }
        //
        //         Console.WriteLine();
        //     }
        //
        //     // while (true)
        //     // {
        //     //     GetBestMove(array, out int bestX, out int bestY);
        //     //     array[bestX, bestY] = "X";
        //     //     
        //     //     if (IsWin(array, "X"))
        //     //     {
        //     //         Console.WriteLine("X won!");
        //     //     }
        //     //
        //     //     if (IsDraw(array))
        //     //     {
        //     //         Console.WriteLine("Tie!");
        //     //     }
        //     //     
        //     //     Turn("O", array, out _, 3, out _, out _);
        //     //
        //     // }
        //
        //     //First step in the center (cell = 4)
        //     CalculatingCell(4, 3, out int computerCellRow, out int computerCellCol);
        //     PrintPause();
        //
        //     Console.WriteLine("Computer chose 4");
        //     array[computerCellRow, computerCellCol] = "X";
        //     Print(array);
        //
        //     Turn("O", array, out int userCell, 3, out int row, out int col);
        //     //Second step as far as it's possible from O's stepdouble
        //     double maxDistance = -1;
        //     int farCell = 0;
        //
        //     if ((userCell == 1) || (userCell == 3) || (userCell == 5) || (userCell == 7))
        //     {
        //         for (int i = 0; i < 3; i++)
        //         {
        //             for (int j = 0; j < 3; j++)
        //             {
        //                 if (array[i, j] != "X" && array[i, j] != "O")
        //                 {
        //                     int cell = i * size + j;
        //                     double distance = CalculatingDistance(cell, userCell);
        //                     if (distance > maxDistance)
        //                     {
        //                         maxDistance = distance;
        //                         farCell = cell;
        //                     }
        //                 }
        //             }
        //         }
        //
        //         row = farCell / size;
        //         col = farCell % size;
        //
        //         array[row, col] = "X";
        //     }
        //
        //     else
        //     {
        //         int cellAttempt = 0;
        //
        //         do
        //         {
        //             cellAttempt += 2;
        //             row = cellAttempt / 3;
        //             col = cellAttempt % 3;
        //         } while (array[row, col] == computer || array[row, col] == player);
        //     }
        //
        //     array[row, col] = "X";
        //
        //     PrintPause();
        //
        //     Print(array);
        //
        //     Turn("O", array, out userCell, 3, out row, out col);
        //
        //     while (true)
        //     {
        //         TurnComputer(array, computer, player);
        //         if (IsWin(array, "X"))
        //         {
        //             Console.WriteLine("X won!");
        //             return;
        //         }
        //
        //         if (IsDraw(array)) //turn off this loop in case of field size > 3
        //         {
        //             Console.WriteLine("It's a tie!");
        //             return;
        //         }
        //
        //         Turn("O", array, out userCell, 3, out row, out col);
        //         if (IsWin(array, "O"))
        //         {
        //             Console.WriteLine("O won!");
        //             return;
        //         }
        //
        //         if (IsDraw(array)) //turn off this loop in case of field size > 3
        //         {
        //             Console.WriteLine("It's a tie!");
        //             return;
        //         }
        //     }
        // }

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
                    Multiplayer mp = new Multiplayer();
                    mp.Play();
                    // Multiplayer(size);
                }
                else
                {
                    MultiplayerBigField mpbf = new MultiplayerBigField(size);
                    mpbf.Play();
                    // MultiplayerBigField(size);
                }
            }
            else
            {
                VersusComputer vs = new VersusComputer();
                vs.ComputerSuperPower();
            }
        }

        // static void Multiplayer(int size)
        // {
        //     string[,] array = new string[size, size];
        //
        //     for (int i = 0; i < array.GetLength(0); i++)
        //     {
        //         for (int j = 0; j < array.GetLength(1); j++)
        //         {
        //             array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
        //             Console.Write($"[{array[i, j]}]\t");
        //         }
        //
        //         Console.WriteLine();
        //     }
        //
        //     while (true)
        //     {
        //         Turn("X", array, out int _, size, out int _, out int _);
        //         //(string player, string[,] array, out int cell, int size, out int row, out int col)
        //         if (IsWin(array, "X"))
        //         {
        //             Console.WriteLine("X won!");
        //             return;
        //         }
        //
        //         if (IsDraw(array))
        //         {
        //             Console.WriteLine("It's a tie!");
        //             return;
        //         }
        //
        //         Turn("O", array, out _, size, out _, out _);
        //         if (IsWin(array, "O"))
        //         {
        //             Console.WriteLine("O won!");
        //             return;
        //         }
        //
        //         if (IsDraw(array)) //turn off this loop in case of field size > 3
        //         {
        //             Console.WriteLine("It's a tie!");
        //             return;
        //         }
        //     }
        // }

        // static void MultiplayerBigField(int size)
        // {
        //     string[,] array = new string[size, size];
        //     for (int i = 0; i < array.GetLength(0); i++)
        //     {
        //         for (int j = 0; j < array.GetLength(1); j++)
        //         {
        //             array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
        //             Console.Write($"[{array[i, j]}]\t");
        //         }
        //
        //         Console.WriteLine();
        //     }
        //
        //     int step = 0;
        //     while (true)
        //     {
        //         Turn("X", array, out _, size, out _, out _);
        //         step++;
        //         if (IsWin(array, "X"))
        //         {
        //             Console.WriteLine("X won!");
        //             return;
        //         }
        //
        //         if (step == Math.Pow(size, 2))
        //         {
        //             Console.WriteLine("It's a tie!");
        //             return;
        //         }
        //
        //         Turn("O", array, out _, size, out _, out _);
        //         if (IsWin(array, "O"))
        //         {
        //             Console.WriteLine("O won!");
        //             return;
        //         }
        //     }
        // }
    }
}