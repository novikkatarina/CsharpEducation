namespace TicTacToe.GUI.ConsoleApp;

internal class Program
{
    public static void Main()
    {
        int input;
        do
        {
            Console.WriteLine("Choose , 1 - with your friend, 2 to play with computer");
            input = int.Parse(Console.ReadLine());
        } while ((input != 1) && (input != 2));

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
                Multiplayer mp = new Multiplayer();
                mp.Play();
            }
            else
            {
                MultiplayerBigField mpbf = new MultiplayerBigField(size);
                mpbf.Play();
            }
        }
        else
        {
            VersusComputer vs = new VersusComputer();
            vs.Play();
        }
    }
}