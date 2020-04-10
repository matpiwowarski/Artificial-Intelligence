using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToeBot: IPlayer
    {
        private TicTacToe ticTacToe;

        private static readonly TicTacToeBot instance = new TicTacToeBot();

        private TicTacToeBot()
        {

        }

        static TicTacToeBot()
        {

        }

        public static TicTacToeBot Instance
        {
            get
            {
                return instance;
            }
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

        public void SetTicTacToe(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
        }
    }
}
