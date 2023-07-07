using System;
using System.Collections.Generic;
using System.Linq;

namespace TAsk2_2
{
    public class Logic
    {
        public static void Turn(string player, string[,] array, out int cell, int size, out int row, out int col)
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
        
                    // board.Print();
                    retryFlag = true;
                }
                catch (Exception e)
                {
                    retryFlag = false;
                }
            } while (retryFlag == false);
        }
        
        public static void CalculatingCell(int inputCellNumber, int size, out int cellRow, out int cellCol)
        {
            cellRow =
                inputCellNumber / size; //calculating the exact row and column by computer's cell
            cellCol = inputCellNumber % size;
        }
        
        public static double CalculatingDistance(int inputComputerCell, int inputUserCell)
        {
            CalculatingCell(inputComputerCell, 3, out int computerCellRow, out int computerCellCol);
            CalculatingCell(inputUserCell, 3, out int userCellRow, out int userCellCol);

            double distance =
                Math.Sqrt(Math.Abs(Math.Pow(computerCellRow - userCellRow, 2) +
                                   Math.Pow(computerCellCol - userCellCol, 2)));
            return distance;
        }
        
        public static bool IsDraw(string[,] array)
        {
            // Check each row
            List<bool> possibilities = new List<bool>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                possibilities.Add(!IsWinPossible(array[i, 0], array[i, 1], array[i, 2]));
            }

            // Check each column
            for (int i = 0; i < 3; i++)
            {
                possibilities.Add(!IsWinPossible(array[0, i], array[1, i], array[2, i]));
            }

            // Check the diagonals
            possibilities.Add(!IsWinPossible(array[0, 0], array[1, 1], array[2, 2]) ||
                              !IsWinPossible(array[0, 2], array[1, 1], array[2, 0]));

            // If no draw condition is found, return false
            return possibilities.Count(x => x == true) >= 6;
        }

        public static bool IsWinPossible(string cell1, string cell2, string cell3)
        {
            if ((cell1 == "X" || cell2 == "X" || cell3 == "X") && (cell1 == "O" || cell2 == "O" || cell3 == "O"))
            {
                return false;
            }

            return true;
        }

        public static bool IsWin(string[,] array, string player)
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
        
        public static bool WinThisTurnComputer(string[,] array, string player,
            string computer) //проверяем возможность выиграть в этот ход
        {
            int bestY = -1;
            int bestX = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] != player && array[i, j] != computer)
                    {
                        array[i, j] = computer; // set
                        if (IsWin(array, computer))
                        {
                            bestX = i;
                            bestY = j;
                            array[i, j] = (i * 3 + j).ToString();
                        }

                        array[i, j] = (i * 3 + j).ToString(); // reset
                    }
                }
            }

            // Ecли игрок может победить
            if (bestX != -1 && bestY != -1)
            {
                array[bestX, bestY] = computer;
                //PrintPause();
                //Print(array);
                return true;
            }

            return false;
        }

        public static bool WinThisTurnPlayer(string[,] array, string playerChekingWin,
            string computer) //проверяем возможность игрока выиграть в этот ход
        {
            int bestY = -1;
            int bestX = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] != playerChekingWin && array[i, j] != computer)
                    {
                        array[i, j] = playerChekingWin; // set
                        if (IsWin(array, playerChekingWin))
                        {
                            bestX = i;
                            bestY = j;
                            array[i, j] = (i * 3 + j).ToString();
                        }

                        array[i, j] = (i * 3 + j).ToString(); // reset
                    }
                }
            }

            // Ecли игрок может победить
            if (bestX != -1 && bestY != -1)
            {
                array[bestX, bestY] = computer;
                // PrintPause();
                // Print(array);
                return true;
            }

            return false;
        }
    }
}