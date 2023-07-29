namespace TicTacToe.ConsoleApp;

/// <summary>
/// Описывает режим игры с другим игроком на поле 3х3.
/// </summary>
public class GamingWithPlayer : IGamingStrategy
{
  /// <summary>
  /// Константа размера поля - 3х3.
  /// </summary>
  public const int size = 3;

  public Board Board { get { return board; } }

  /// <summary>
  /// Поле игры.
  /// </summary>
  private Board board;


  /// <summary>
  /// Описывает порядок ходов игроков.
  /// </summary>
  public void Play()
  {
    Player currentPlayer = Player.X;
    board.Print();
    while (true)
    {
      TicTacToeLogic.Turn($"{currentPlayer}", board.Array, out int _,
        board.GetSize(),
        out int _,
        out int _);
      board.Print();

      if (TicTacToeLogic.IsWin(board.Array, $"{currentPlayer}"))
      {
        Console.WriteLine($"{currentPlayer} won!");
        return;
      }

      if (TicTacToeLogic.IsDraw(board.Array))
      {
        Console.WriteLine("It's a tie!");
        return;
      }

      currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
    }
  }

  /// <summary>
  ///Конструктор класса Multiplayer игры между двумя игроками.
  /// </summary>
  /// <param name="size">Размер матрицы.</param>
  public GamingWithPlayer()
  {
    board = new Board(size);
  }
}
