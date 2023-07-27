namespace TicTacToe.GUI.ConsoleApp;

/// <summary>
/// Описывает режим игры с другим игроком на поле с размером больше 3.
/// </summary>
public class MultiplayerBigField
{
  /// <summary>
  /// Игровое поле.
  /// </summary>
  private Board board;


  /// <summary>
  /// Запускает режим игры с другим игроком.
  /// </summary>
  public void Play()
  {
    board.Print();
    int step = 0;
    while (true)
    {
      TicTacToeLogic.Turn("X", board.Array, out _, board.GetSize(), out _,
        out _);
      board.Print();
      step++;
      if (TicTacToeLogic.IsWin(board.Array, "X"))
      {
        System.Console.WriteLine("X won!");
        return;
      }

      if (step == Math.Pow(board.GetSize(), 2))
      {
        System.Console.WriteLine("It's a tie!");
        return;
      }

      TicTacToeLogic.Turn("O", board.Array, out _, board.GetSize(), out _,
        out _);
      board.Print();
      if (TicTacToeLogic.IsWin(board.Array, "O"))
      {
        System.Console.WriteLine("O won!");
        return;
      }
    }
  }

  /// <summary>
  /// Конструктор класса MultiplayerBigField игры между двумя игроками.
  /// </summary>
  /// <param name="size">Размер поля.</param>
  public MultiplayerBigField(int size)
  {
    board = new Board(size);
  }
}
