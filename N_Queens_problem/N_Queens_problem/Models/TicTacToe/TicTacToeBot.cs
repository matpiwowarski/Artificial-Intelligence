using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToeBot: IPlayer
    {
        private TicTacToe ticTacToe;
        public readonly TicTacToeSymbol Symbol = TicTacToeSymbol.Circle;

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
            if (ticTacToe.ticTacToeBoard[x, y] == TicTacToeSymbol.Empty)
            {
                ticTacToe.ticTacToeBoard[x, y] = TicTacToeSymbol.Circle;
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
