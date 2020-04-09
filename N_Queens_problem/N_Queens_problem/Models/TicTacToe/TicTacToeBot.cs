using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToeBot: IPlayer
    {
        private TicTacToe ticTacToe;
        private static int score = 0;

        public TicTacToeBot(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
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

        public void WonGame()
        {
            TicTacToeBot.score++;
        }

        public int GetScore()
        {
            return TicTacToeBot.score;
        }
    }
}
