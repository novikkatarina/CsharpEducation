namespace TicTacToe.GUI.ConsoleApp;

/// <summary>
/// Описывает режим игры против компьютера.
/// </summary>
public class VersusComputer
{
  /// <summary>
  /// Игровое поле.
  /// </summary>
  private Board board;

  /// <summary>
  /// Конструктор.
  /// </summary>
  public VersusComputer()
  {
    board = new Board(3);
  }

  /// <summary>
  /// Запускает режим игры против компьютера.
  /// </summary>
  public void Play()
  {
    const string computer = "X";
    const string player = "O";

    // First step for computer - in the center (cell = 4)
    Logic.CalculateCell(4, 3, out int computerCellRow,
      out int computerCellCol);
    PrintPause();

    Console.WriteLine("Computer chose 4");
    board.SetSymbol(computerCellRow, computerCellCol, computer);
    board.Print();

    // PLayer step
    Logic.Turn(player, board.Array, out int userCell, 3, out int row,
      out int col);
    board.Print();

    // Second step of computer - as far as it's possible from O's second step
    double maxDistance = -1;
    int farCell = 0;

    // If previous player's step was in the center steps (1, 3, 5, 7) - calculating the most far cell
    if (( userCell == 1 ) || ( userCell == 3 ) || ( userCell == 5 ) ||
        ( userCell == 7 ))
    {
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (board.Array[i, j] != computer && board.Array[i, j] != player)
          {
            int cell = i * board.GetSize() + j;
            double distance = Logic.CalculateDistance(cell, userCell);
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

      board.SetSymbol(row, col, computer);
    }

    // Else make step in the corner
    else
    {
      int cellAttempt = -2;

      do
      {
        cellAttempt += 2;
        row = cellAttempt / 3;
        col = cellAttempt % 3;
      } while (board.Array[row, col] == computer ||
               board.Array[row, col] == player);
    }

    board.SetSymbol(row, col, computer);

    PrintPause();

    board.Print();

    //Next step for player

    Logic.Turn(player, board.Array, out userCell, 3, out row, out col);
    board.Print();

    while (true)
    {
      TurnComputer(board.Array, computer, player);
      if (Logic.IsWin(board.Array, "X"))
      {
        Console.WriteLine("X won!");
        return;
      }

      if (Logic.IsDraw(board
            .Array)) //turn off this loop in case of field size > 3
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

      if (Logic.IsDraw(board
            .Array)) //turn off this loop in case of field size > 3
      {
        Console.WriteLine("It's a tie!");
        return;
      }
    }
  }

  #region Функции компьютера

  /// <summary>
  /// Описывает ход компьютера.
  /// </summary>
  /// <param name="array">Игровое поле.</param>
  /// <param name="computer">Игровой символ компьютера.</param>
  /// <param name="player">Игровой символ игрока.</param>
  private void TurnComputer(string[,] array, string computer, string player)
  {
    //Case 1. Checking if computer can win.

    if (Logic.IsComputerWin(array, player, computer))
    {
      PrintPause();
      board.Print();
      return;
    }

    // Case 2. Checking if player can win and stop him.
    if (Logic.IsPlayerWin(array, player, computer))
    {
      PrintPause();
      board.Print();
      return;
    }

    //Case 3. Else make random step.

    Random random = new Random();
    int computerCol;
    int computerRow;
    do
    {
      int randomCell = random.Next(9);
      computerRow = randomCell / 3;
      computerCol =
        randomCell %
        3; //calculating the exact row and colom by user's input cell
    } while (array[computerRow, computerCol] == computer ||
             array[computerRow, computerCol] == player);

    array[computerRow, computerCol] = computer;
    PrintPause();
    board.Print();
  }

  /// <summary>
  /// Распечатывает ... с задержкой.
  /// </summary>
  private static void PrintPause()
  {
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);
    Console.WriteLine(".");
  }

  #endregion
}
