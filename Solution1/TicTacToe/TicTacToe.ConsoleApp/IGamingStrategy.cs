namespace TicTacToe.ConsoleApp;

internal interface IGamingStrategy
{
  void Play();

  Board Board { get; }
}
