namespace TicTacToe.GUI.ConsoleApp;

/// <summary>
/// Описывает режим игры с другим игроком на большом поле.
/// </summary>
public class MultiplayerBigField
{
  /// <summary>
  /// Игровое поле.
  /// </summary>
  private Board board;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="size">Размер поля.</param>
  public MultiplayerBigField(int size)
  {
    board = new Board(size);
  }

  /// <summary>
  /// Запускает режим игры с другим игроком.
  /// </summary>
  public void Play()
  {
    board.Print();
    int step = 0;
    while (true)
    {
      Logic.Turn("X", board.Array, out _, board.GetSize(), out _, out _);
      board.Print();
      step++;
      if (Logic.IsWin(board.Array, "X"))
      {
        System.Console.WriteLine("X won!");
        return;
      }

      if (step == Math.Pow(board.GetSize(), 2))
      {
        System.Console.WriteLine("It's a tie!");
        return;
      }

      Logic.Turn("O", board.Array, out _, board.GetSize(), out _, out _);
      board.Print();
      if (Logic.IsWin(board.Array, "O"))
      {
        System.Console.WriteLine("O won!");
        return;
      }
    }
  }
}
