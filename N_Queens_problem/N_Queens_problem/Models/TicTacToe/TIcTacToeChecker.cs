using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToeChecker
    {
        public TicTacToeChecker()
        {

        }

        public bool CheckIfSymbolWon(TicTacToeSymbol symbol, TicTacToeSymbol[,] ticTacToeBoard)
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

        public void CheckGameStatus(TicTacToe ticTacToe)
        {
            SetTieIfGameEnded(ticTacToe);
            if (CheckIfSymbolWon(TicTacToeSymbol.Circle, ticTacToe.ticTacToeBoard))
                ticTacToe.GameStatus = GameStatus.BotWon;
            if (CheckIfSymbolWon(TicTacToeSymbol.Cross, ticTacToe.ticTacToeBoard))
                ticTacToe.GameStatus = GameStatus.UserWon;
        }

        public void CheckGameStatusAndGivePoint(TicTacToe ticTacToe)
        {
            if (ticTacToe.GameStatus == GameStatus.Tie)
            {
                ticTacToe.TieScore++;
            }
            else if (ticTacToe.GameStatus == GameStatus.BotWon)
            {
                ticTacToe.BotScore++;
            }
            else if (ticTacToe.GameStatus == GameStatus.UserWon)
            {
                ticTacToe.UserScore++;
            }
        }

        private void SetTieIfGameEnded(TicTacToe ticTacToe)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ticTacToe.ticTacToeBoard[i, j] == TicTacToeSymbol.Empty)
                    {
                        return;
                    }
                }
            }
            ticTacToe.GameStatus = GameStatus.Tie;
        }
    }
}
