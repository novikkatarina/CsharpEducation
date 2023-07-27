namespace TicTacToe.GUI.ConsoleApp;

/// <summary>
/// Создает и печатает матрицу - поле для игры.
/// </summary>
public class Board
{
  /// <summary>
  /// Матрица, представляет поле для игры.
  /// </summary>
  public string[,] Array { get; }

  /// <summary>
  /// Возвращает размер матрицы.
  /// </summary>
  /// <returns></returns>
  public int GetSize()
  {
    return Array.GetLength(0);
  }

  /// <summary>
  /// Заполнение весго поля числами.
  /// </summary>
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

  /// <summary>
  /// Устанавливает знак игрока текущего хода на нужную позицию.
  /// </summary>
  /// <param name="row">Строка ячейки хода игрока.</param>
  /// <param name="col">Столбец ячейки хода игрока.</param>
  /// <param name="symbol">Символ игрока, делающего ход.</param>
  public void SetSymbol(int row, int col, string symbol)
  {
    Array[row, col] = symbol;
  }

  /// <summary>
  /// Распечатывает поле игры.
  /// </summary>
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

  /// <summary>
  ///Конструктор класса Board, создающий новую матрицу - поле и заполняющий его.
  /// </summary>
  /// <param name="size">Размер матрицы.</param>
  public Board(int size)
  {
    Array = new string[size, size];
    FillArray();
  }
}
