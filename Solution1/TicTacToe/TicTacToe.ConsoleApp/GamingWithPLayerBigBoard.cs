namespace TicTacToe.ConsoleApp;

/// <summary>
/// Описывает режим игры с другим игроком на поле с размером больше 3.
/// </summary>
public class GamingWithPLayerBigBoard
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
    Player currentPlayer = Player.X;
    while (true)
    {
      TicTacToeLogic.Turn(currentPlayer.ToString(), board.Array, out _,
        board.GetSize(), out _,
        out _);
      board.Print();
      step++;
      if (TicTacToeLogic.IsWin(board.Array, currentPlayer.ToString()))
      {
        Console.WriteLine($"{currentPlayer} won!");
        return;
      }

      if (step == Math.Pow(board.GetSize(), 2))
      {
        Console.WriteLine("It's a tie!");
        return;
      }

      currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
    }
  }

  /// <summary>
  /// Конструктор класса MultiplayerBigField игры между двумя игроками.
  /// </summary>
  /// <param name="size">Размер поля.</param>
  public GamingWithPLayerBigBoard(int size)
  {
    board = new Board(size);
  }
}
