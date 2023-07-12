using TAsk2_2;

namespace TicTacToe.Console
{
    /// <summary>
    /// 
    /// </summary>
    public class Multiplayer
    {
        private Board board; // null

        public Multiplayer()
        {
            board = new Board(3);
        }
        
        public void Play()
        {
            board.Print();
            while (true)
            {
                Logic.Turn("X", board.Array, out int _, board.GetSize(), out int _, out int _);
                board.Print();
                
                if (Logic.IsWin(board.Array, "X"))
                {
                    System.Console.WriteLine("X won!");
                    return;
                }

                if (Logic.IsDraw(board.Array))
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

                if (Logic.IsDraw(board.Array)) //turn off this loop in case of field size > 3
                {
                    System.Console.WriteLine("It's a tie!");
                    return;
                }
            }
        }
        
    }
}