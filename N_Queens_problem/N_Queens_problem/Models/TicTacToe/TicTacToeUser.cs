using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public sealed class TicTacToeUser: IPlayer
    {
        private TicTacToe ticTacToe;
        public readonly TicTacToeSymbol Symbol = TicTacToeSymbol.Cross; 

        private static readonly TicTacToeUser instance = new TicTacToeUser();

        private TicTacToeUser()
        {

        }

        static TicTacToeUser()
        {

        }

        public static TicTacToeUser Instance
        {
            get
            {
                return instance;
            }
        }


        public void SetTicTacToe(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
        }

        public bool MakeMove(int x, int y)
        {
            if (ticTacToe.ticTacToeBoard[x, y] == TicTacToeSymbol.Empty)
            {
                ticTacToe.ticTacToeBoard[x, y] = TicTacToeSymbol.Cross;
                return true;
            }
            return false;
        }
    }
}
