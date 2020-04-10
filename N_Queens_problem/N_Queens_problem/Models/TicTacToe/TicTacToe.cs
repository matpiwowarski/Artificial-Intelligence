using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public sealed class TicTacToe
    {
        private static readonly TicTacToe instance = new TicTacToe();

        public TicTacToeSymbol[,] ticTacToeBoard = new TicTacToeSymbol[3, 3]; // x,y
        public bool IsPlayerStarting = false;
        public int Level = 5;
        public int UserScore = 0;
        public int BotScore = 0;
        public int TieScore = 0;
        public bool IsFinsihed = false;

        private TicTacToe()
        {

        }

        static TicTacToe()
        {

        }

        public static TicTacToe Instance
        {
            get
            {
                return instance;
            }
        }

        public void UserWon()
        {
            UserScore++;
        }

        public void BotWon()
        {
            BotScore++;
        }

        public bool CheckIfSymbolWon(TicTacToeSymbol symbol)
        {
            // checking horizontal
            for (int x = 0; x < 3; x++)
            {
                if (ticTacToeBoard[x, 0] == symbol && ticTacToeBoard[x, 1] == symbol && ticTacToeBoard[x, 2] == symbol)
                {
                    return true;
                }
            }
            // vertical
            for (int y = 0; y < 3; y++) 
            {
                if (ticTacToeBoard[0, y] == symbol && ticTacToeBoard[1, y] == symbol && ticTacToeBoard[2, y] == symbol)
                {
                    return true;
                }
            }
            // diagonal
            if (ticTacToeBoard[0, 0] == symbol && ticTacToeBoard[1, 1] == symbol && ticTacToeBoard[2, 2] == symbol)
            {
                return true;
            }
            if (ticTacToeBoard[2, 0] == symbol && ticTacToeBoard[1, 1] == symbol && ticTacToeBoard[0, 2] == symbol)
            {
                return true;
            }
            return false;
        }

        public void CheckIfFinished()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (ticTacToeBoard[i, j] == TicTacToeSymbol.Empty)
                    {
                        IsFinsihed = false;
                        return;
                    }
                }
            }
            IsFinsihed = true;
        }

        public void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticTacToeBoard[i, j] = TicTacToeSymbol.Empty;
                }
            }
        }

    }
}
