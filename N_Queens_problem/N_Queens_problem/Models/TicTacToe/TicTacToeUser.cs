using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToeUser: IPlayer
    {
        private TicTacToe ticTacToe;
        private static int score = 0;

        public TicTacToeUser(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
        }

        public bool MakeMove(int x, int y)
        {
            if (ticTacToe.ticTacToeBoard[x, y] == TicTacToeMove.Empty)
            {
                ticTacToe.ticTacToeBoard[x, y] = TicTacToeMove.Cross;
                return true;
            }
            return false;
        }

        public void WonGame()
        {
            TicTacToeUser.score++;
        }

        public int GetScore()
        {
            return TicTacToeUser.score;
        }
    }
}
