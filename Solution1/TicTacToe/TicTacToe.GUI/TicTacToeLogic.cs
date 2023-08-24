namespace TicTacToe.GUI
{
  public class TicTacToeLogic
  {
    /// <summary>
    /// Проверяет получилась ли ничья на данном ходу.
    /// </summary>
    /// <param name="array">Игровое поле.</param>
    /// <returns>Результат проверки.</returns>

    #region Проверка на ничью

    public static bool IsDraw(string[,] array)
    {
      // Check each row
      List<bool> possibilities = new List<bool>();
      for (int i = 0; i < array.GetLength(0); i++)
      {
        possibilities.Add(!IsWinPossible(array[i, 0], array[i, 1],
          array[i, 2]));
      }

      // Check each column
      for (int i = 0; i < 3; i++)
      {
        possibilities.Add(!IsWinPossible(array[0, i], array[1, i],
          array[2, i]));
      }

      // Check the diagonals
      possibilities.Add(!IsWinPossible(array[0, 0], array[1, 1], array[2, 2]) ||
                        !IsWinPossible(array[0, 2], array[1, 1], array[2, 0]));

      // If no draw condition is found, return false
      return possibilities.Count(x => x == true) >= 7;
    }


    /// <summary>
    /// Проверяет возможна ли победа кого-либо на этом ходу в заданных ячейках.
    /// </summary>
    /// <param name="cell1">1 ячейка.</param>
    /// <param name="cell2">2 ячейка.</param>
    /// <param name="cell3">3 ячейка.</param>
    /// <returns>Результат проверки.</returns>
    public static bool IsWinPossible(string cell1, string cell2, string cell3)
    {
      if (( cell1 == Player.X.ToString() || cell2 == Player.X.ToString() ||
            cell3 == Player.X.ToString() ) &&
          ( cell1 == Player.O.ToString() || cell2 == Player.O.ToString() ||
            cell3 == Player.O.ToString() ))
      {
        return false;
      }

      return true;
    }

    #endregion

    /// <summary>
    /// Проверяет победит ли данный игрок.
    /// </summary>
    /// <param name="array">Игровое поле.</param>
    /// <param name="player">Данный игрок.</param>
    /// <returns>Результат проверки.</returns>

    #region Проверка на выигрыш

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

    #endregion
  }
}
