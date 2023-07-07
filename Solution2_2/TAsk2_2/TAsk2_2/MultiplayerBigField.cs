using System;

namespace TAsk2_2
{
    public class MultiplayerBigField
    {
        private Board board;
        public MultiplayerBigField(int size)
        {
            board = new Board(size);
        }
        
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
                    Console.WriteLine("X won!");
                    return;
                }
        
                if (step == Math.Pow(board.GetSize(), 2))
                {
                    Console.WriteLine("It's a tie!");
                    return;
                }
        
                Logic.Turn("O", board.Array, out _, board.GetSize(), out _, out _);
                board.Print();
                if (Logic.IsWin(board.Array, "O"))
                {
                    Console.WriteLine("O won!");
                    return;
                }
            }
        }
    }
}