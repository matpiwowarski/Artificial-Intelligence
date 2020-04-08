using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToe
    {
        public TicTacToeMove[,] ticTacToe = new TicTacToeMove[3, 3];

        public TicTacToe()
        {

        }

        public bool PutCross(int x, int y)
        {
            if (ticTacToe[x, y] == TicTacToeMove.Empty)
            {
                ticTacToe[x, y] = TicTacToeMove.Cross;
                return true;
            }
            return false;
        }

        public bool PutCircle(int x, int y)
        {
            if(ticTacToe[x, y] == TicTacToeMove.Empty)
            {
                ticTacToe[x, y] = TicTacToeMove.Circle;
                return true;
            }
            return false;
        }
    }
}
