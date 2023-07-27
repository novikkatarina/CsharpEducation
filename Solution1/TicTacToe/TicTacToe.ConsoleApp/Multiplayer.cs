namespace TicTacToe.GUI.ConsoleApp;

/// <summary>
/// Описывает режим игры с другим игроком на поле 3х3.
/// </summary>
public class Multiplayer
{
  /// <summary>
  /// Константа размера поля - 3х3.
  /// </summary>
  public const int size = 3;

  /// <summary>
  /// Поле игры.
  /// </summary>
  private Board board;


  /// <summary>
  /// Описывает порядок ходов игроков.
  /// </summary>
  public void Play()
  {
    board.Print();
    while (true)
    {
      TicTacToeLogic.Turn("X", board.Array, out int _, board.GetSize(),
        out int _,
        out int _);
      board.Print();

      if (TicTacToeLogic.IsWin(board.Array, "X"))
      {
        Console.WriteLine("X won!");
        return;
      }

      if (TicTacToeLogic.IsDraw(board.Array))
      {
        Console.WriteLine("It's a tie!");
        return;
      }

      TicTacToeLogic.Turn("O", board.Array, out _, board.GetSize(), out _,
        out _);
      board.Print();
      if (TicTacToeLogic.IsWin(board.Array, "O"))
      {
        Console.WriteLine("O won!");
        return;
      }

      if (TicTacToeLogic.IsDraw(board
            .Array)) //turn off this loop in case of field size > 3, IsDraw method works only for board with size 3.
      {
        Console.WriteLine("It's a tie!");
        return;
      }
    }
  }

  /// <summary>
  ///Конструктор класса Multiplayer игры между двумя игроками.
  /// </summary>
  /// <param name="size">Размер матрицы.</param>
  public Multiplayer()
  {
    board = new Board(size);
  }
}
