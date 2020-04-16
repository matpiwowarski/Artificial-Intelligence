using System;
using System.Collections.Generic;

namespace ArtificialIntelligence.Models.TicTacToe.Algorithm
{
    public class MiniMax: TicTacToeAlgorithm
    {
        public MiniMax(TicTacToeSymbol[,] boardBeforeMove, int level)
        {
            CopyTicTacToeBoard(_boardBeforeMove, boardBeforeMove);
            _maxDepth = level;
        }

        protected override int DoAlgorithm()
        {
            return MiniMaxAlgorithm(1, false);
        }

        // MiniMax algorithm
        private int MiniMaxAlgorithm(int depth, bool isMaximizing)
        {
            TicTacToeChecker ticTacToeChecker = new TicTacToeChecker();

            // checking board state
            if (ticTacToeChecker.CheckIfSymbolWon(TicTacToeSymbol.Circle, _boardBeforeMove))
            {
                return 10 - depth;
            }
            else if (ticTacToeChecker.CheckIfSymbolWon(TicTacToeSymbol.Cross, _boardBeforeMove))
            {
                return depth - 10;
            }
            else if (ticTacToeChecker.GameEnded(_boardBeforeMove))
            {
                return 0;
            }

            if (depth >= _maxDepth)
            {
                return 0;
            }

            if (isMaximizing) // circle should be the best
            {
                int bestScore = -int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_boardBeforeMove[i, j] == TicTacToeSymbol.Empty)
                        {
                            _boardBeforeMove[i, j] = TicTacToeSymbol.Circle;
                            int scoreMax = MiniMaxAlgorithm(depth + 1, false);
                            _boardBeforeMove[i, j] = TicTacToeSymbol.Empty;

                            bestScore = Math.Max(scoreMax, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            else // cross should be the worst
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_boardBeforeMove[i, j] == TicTacToeSymbol.Empty)
                        {
                            _boardBeforeMove[i, j] = TicTacToeSymbol.Cross;
                            int scoreMin = MiniMaxAlgorithm(depth + 1, true);
                            _boardBeforeMove[i, j] = TicTacToeSymbol.Empty;

                            bestScore = Math.Min(scoreMin, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}
