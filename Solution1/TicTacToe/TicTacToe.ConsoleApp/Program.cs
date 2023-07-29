namespace TicTacToe.ConsoleApp;

internal class Program
{
  public static void Main()
  {
    int input;
    do
    {
      Console.WriteLine(
        "Choose 1 - to play with your friend, 2 to play with computer");
      input = int.Parse(Console.ReadLine());
    } while (( input != 1 ) && ( input != 2 ));

    if (input == 1)
    {
      int size;
      do
      {
        Console.WriteLine("Enter size of field");
        size = int.Parse(Console.ReadLine());
      } while (size < 3);

      if (size == 3)
      {
        GamingWithPlayer mp = new GamingWithPlayer();
        mp.Play();
      }
      else
      {
        GamingWithPLayerBigBoard mpbf = new GamingWithPLayerBigBoard(size);
        mpbf.Play();
      }
    }
    else
    {
      GamingWithPlayer vs = new GamingWithPlayer();
      vs.Play();
    }
  }
}
