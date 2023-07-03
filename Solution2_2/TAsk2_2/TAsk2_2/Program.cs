using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

        private static bool IsWin(string[,] arrayButtons, string player)
        {
            int flag = 0;
            int flag2 = 0;

            //Checking rows and columns

            for (int i = 0; i < arrayButtons.GetLength(0); i++)
            {
                for (int j = 0; j < arrayButtons.GetLength(1); j++)
                {
                    if (arrayButtons[i, j] == player) flag++;
                    {
                        if (flag == arrayButtons.GetLength(0)) return true;
                    }
                    if (arrayButtons[j, i] == player) flag2++;
                    {
                        if (flag2 == arrayButtons.GetLength(1)) return true;
                    }
                }

                flag = 0;
                flag2 = 0;
            }

            flag = 0;

//Checking diagonal
            for (int k = 0; k < arrayButtons.GetLength(0); k++)
            {
                if (arrayButtons[k, arrayButtons.GetLength(1) - 1 - k] == player) flag++;
            }

            if (flag == arrayButtons.GetLength(0))
                return true;
            flag = 0;
//Checking diagonal
            for (int k = 0; k < arrayButtons.GetLength(0); k++)
            {
                if (arrayButtons[k, k] == player) flag++;
            }

            if (flag == arrayButtons.GetLength(1))
                return true;
            return false;
        }


        static void Turn(string player, string[,] array, int size)
        {
            string input;
            bool retryFlag = false;
            do
            {
                Console.WriteLine($"{player}, your turn. Choose your position");
                input = Console.ReadLine();

                try
                {
                    int cell = int.Parse(input);

                    int row = cell / size; //calculating the exact row and colom by user's input cell
                    int col = cell % size;

                    if (array[row, col] == "X" || array[row, col] == "O")
                    {
                        continue;
                    }

                    array[row, col] = player;

                    Print(array, row, col);
                    retryFlag = true;
                }
                catch (Exception e)
                {
                    retryFlag = false;
                }
            } while (retryFlag == false);
        }

        static void Print(string[,] array, int row = -1, int col = -1)
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

        static double CalculatingDistance(string[,] array, int size, int computerCell, int userCell)
        {
            int computerRow =
                computerCell / size; //calculating the exact row and column by computer's cell
            int computerCol = computerCell % size;

            int userRow = userCell / size; //calculating the exact row and column by user's input cell
            int userCol = userCell % size;

            double distance =
                Math.Sqrt(Math.Abs(Math.Pow(computerRow - userRow, 2) + Math.Pow(computerCol - userCol, 2)));
            return distance;
        }
        
        
        static void ComputerSuperPower(string player)
        {
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

            return;
        }
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
                int size = 3;
                string[,] array = new string[size, size];

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = Convert.ToString(j + array.GetLength(0) * i);
                        Console.Write($"[{array[i, j]}]\t");
                    }

                    
                }
                Console.WriteLine(CalculatingDistance(array, 3, 0, 8));
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
                Turn("X", array, size);
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

                Turn("O", array, size);
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
                Turn("X", array, size);
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

                Turn("O", array, size);
                if (IsWin(array, "O"))
                {
                    Console.WriteLine("O won!");
                    return;
                }

            }
        }
    }
}