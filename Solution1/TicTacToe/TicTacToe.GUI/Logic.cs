namespace TicTacToe.GUI
{
    public class Logic
    {
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
            return possibilities.Count(x => x == true) >= 7;
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




    }
}