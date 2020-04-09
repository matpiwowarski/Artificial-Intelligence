using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToeBot: IPlayer
    {
        private TicTacToe ticTacToe;
        private int level;

        public TicTacToeBot(TicTacToe ticTacToe, int level)
        {
            this.ticTacToe = ticTacToe;
            this.level = level;
        }

        public bool MakeMove(int x, int y)
        {
            if (ticTacToe.ticTacToeBoard[x, y] == TicTacToeMove.Empty)
            {
                ticTacToe.ticTacToeBoard[x, y] = TicTacToeMove.Circle;
                return true;
            }
            return false;
        }
    }
}
