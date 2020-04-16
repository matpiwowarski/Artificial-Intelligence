using System;
namespace ArtificialIntelligence.Models.TicTacToe.Algorithm
{
    public abstract class TicTacToeAlgorithm
    {
        protected TicTacToeSymbol[,] _boardBeforeMove = new TicTacToeSymbol[3, 3]; // x,y
        protected int _maxDepth;

        public void CopyTicTacToeBoard(TicTacToeSymbol[,] empty, TicTacToeSymbol[,] original)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    empty[x, y] = original[x, y];
                }
            }
        }

        protected abstract int DoAlgorithm();

        public Tuple<int, int> BestMove()
        {
            int bestX = 0;
            int bestY = 0;
            int bestScore = -int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_boardBeforeMove[i, j] == TicTacToeSymbol.Empty)
                    {
                        _boardBeforeMove[i, j] = TicTacToeSymbol.Circle;
                        int score = DoAlgorithm();
                        _boardBeforeMove[i, j] = TicTacToeSymbol.Empty;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestX = i;
                            bestY = j;
                        }
                    }
                }
            }

            return new Tuple<int, int>(bestX, bestY);
        }
    }
}
