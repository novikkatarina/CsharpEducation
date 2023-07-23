namespace TicTacToe.GUI.ConsoleApp;

/// <summary>
/// Описывает основную логику игры.
/// </summary>
public class Logic
{
  /// <summary>
  /// Описывает ход игрока.
  /// </summary>
  /// <param name="player"> Игрок X или Y, чья очередь ходить в этот ход.</param>
  /// <param name="array"> Массивю - поле для игры в крестики-нолики, содержащий в каждой ячейке цифру от 0 до size - 1.</param>
  /// <param name="cell"> Клетка, в которую можно сделать ход.</param>
  /// <param name="size"> Размер массива, определяющий величину поля.</param>
  /// <param name="row"> Строка массива.</param>
  /// <param name="col"> Столбец массива.</param>
  public static void Turn(string player, string[,] array, out int cell,
    int size, out int row, out int col)
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

        row = cell /
              size; //calculating the exact row and colom by user's input cell
        col = cell % size;

        if (array[row, col] == "X" || array[row, col] == "O")
        {
          continue;
        }

        array[row, col] = player;
        retryFlag = true;
      }
      catch (Exception e)
      {
        retryFlag = false;
      }
    } while (retryFlag == false);
  }

  #region Функции расчета

  /// <summary>
  /// Расчитывает колонку и строку из номера ячейки который ввел пользователь.
  /// </summary>
  /// <param name="inputCellNumber">Предыдущий ход.</param>
  /// <param name="size">Размер поля.</param>
  /// <param name="cellRow">Расчитаная строка.</param>
  /// <param name="cellCol">Расчитаный столбец.</param>
  public static void CalculateCell(int inputCellNumber, int size,
    out int cellRow, out int cellCol)
  {
    cellRow =
      inputCellNumber /
      size; //calculating the exact row and column by computer's cell
    cellCol = inputCellNumber % size;
  }

  /// <summary>
  /// Расчитывает дистанцию.
  /// </summary>
  /// <param name="inputComputerCell">Ячейка компьютера.</param>
  /// <param name="inputUserCell">Ячейка игрока.</param>
  /// <returns>Дистанция.</returns>
  public static double CalculateDistance(int inputComputerCell,
    int inputUserCell)
  {
    CalculateCell(inputComputerCell, 3, out int computerCellRow,
      out int computerCellCol);
    CalculateCell(inputUserCell, 3, out int userCellRow, out int userCellCol);

    double distance =
      Math.Sqrt(Math.Abs(Math.Pow(computerCellRow - userCellRow, 2) +
                         Math.Pow(computerCellCol - userCellCol, 2)));
    return distance;
  }

  #endregion


  #region Игровые проверки

  /// <summary>
  /// Проверяет получилась ли ничья на данном ходу.
  /// </summary>
  /// <param name="array">Игровое поле.</param>
  /// <returns>Результат проверки.</returns>
  public static bool IsDraw(string[,] array)
  {
    // Проверка каждой строки.
    List<bool> possibilities = new List<bool>();
    for (int i = 0; i < array.GetLength(0); i++)
    {
      possibilities.Add(!IsWinPossible(array[i, 0], array[i, 1], array[i, 2]));
    }

    // Проверка каджой колонки.
    for (int i = 0; i < 3; i++)
    {
      possibilities.Add(!IsWinPossible(array[0, i], array[1, i], array[2, i]));
    }

    // Проверка диагонали.
    possibilities.Add(!IsWinPossible(array[0, 0], array[1, 1], array[2, 2]) ||
                      !IsWinPossible(array[0, 2], array[1, 1], array[2, 0]));

    // If no draw condition is found, return false
    return possibilities.Count(x => x == true) >= 6;
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
    if (( cell1 == "X" || cell2 == "X" || cell3 == "X" ) &&
        ( cell1 == "O" || cell2 == "O" || cell3 == "O" ))
    {
      return false;
    }

    return true;
  }

  /// <summary>
  /// Проверяет победит ли данный игрок.
  /// </summary>
  /// <param name="array">Игровое поле.</param>
  /// <param name="player">Данный игрок.</param>
  /// <returns>Результат проверки.</returns>
  public static bool IsWin(string[,] array, string player)
  {
    int flag = 0;
    int flag2 = 0;

    // Проверка строк и колонок.
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

    // Проверка диагонали.
    for (int k = 0; k < array.GetLength(0); k++)
    {
      if (array[k, array.GetLength(1) - 1 - k] == player) flag++;
    }

    if (flag == array.GetLength(0)) return true;
    flag = 0;

    // Проверка диагонали.
    for (int k = 0; k < array.GetLength(0); k++)
    {
      if (array[k, k] == player) flag++;
    }

    if (flag == array.GetLength(1)) return true;
    return false;
  }

  /// <summary>
  /// Проверяет победит ли компьютер на данном ходу.
  /// </summary>
  /// <param name="array">Игровое поле.</param>
  /// <param name="player">Игровой символ игрока.</param>
  /// <param name="computer">Игрвовой символ компьютера.</param>
  /// <returns>Результат проверки.</returns>
  public static bool IsComputerWin(string[,] array, string player,
    string computer) //Checking if computer can win.
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
            array[i, j] = ( i * 3 + j ).ToString();
          }

          array[i, j] = ( i * 3 + j ).ToString(); // reset
        }
      }
    }

    if (bestX != -1 && bestY != -1)
    {
      array[bestX, bestY] = computer;
      return true;
    }

    return false;
  }

  /// <summary>
  /// Возвращает победит ли игрок на данныом ходу.
  /// </summary>
  /// <param name="array">Игровое поле.</param>
  /// <param name="player">Игровой символ игрока, которого проверяют на победу.</param>
  /// <param name="computer">Игрвойо символ компьютера.</param>
  /// <returns>Результат проверки.</returns>
  public static bool IsPlayerWin(string[,] array, string player,
    string computer) //Checking if player can win.
  {
    int bestY = -1;
    int bestX = -1;
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        if (array[i, j] != player && array[i, j] != computer)
        {
          array[i, j] = player; // set
          if (IsWin(array, player))
          {
            bestX = i;
            bestY = j;
            array[i, j] = ( i * 3 + j ).ToString();
          }

          array[i, j] = ( i * 3 + j ).ToString(); // reset
        }
      }
    }

    if (bestX != -1 && bestY != -1)
    {
      array[bestX, bestY] = computer;
      return true;
    }

    return false;
  }

  #endregion
}
