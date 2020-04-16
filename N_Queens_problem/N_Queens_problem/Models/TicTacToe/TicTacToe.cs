using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public sealed class TicTacToe
    {
        private static readonly TicTacToe instance = new TicTacToe();

        public GameStatus GameStatus = GameStatus.InProgress;
        public TicTacToeSymbol[,] ticTacToeBoard = new TicTacToeSymbol[3, 3]; // x,y
        public bool IsPlayerStarting = false;
        public int Level = 5;
        public int UserScore = 0;
        public int BotScore = 0;
        public int TieScore = 0;

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

        public void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticTacToeBoard[i, j] = TicTacToeSymbol.Empty;
                }
            }
            GameStatus = GameStatus.InProgress;
        }

    }
}
