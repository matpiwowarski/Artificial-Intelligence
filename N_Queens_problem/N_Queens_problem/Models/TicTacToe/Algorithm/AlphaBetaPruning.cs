using System;
namespace ArtificialIntelligence.Models.TicTacToe.Algorithm
{
    public class AlphaBetaPruning : TicTacToeAlgorithm
    {
        public AlphaBetaPruning(TicTacToeSymbol[,] boardBeforeMove, int level)
        {
            CopyTicTacToeBoard(_boardBeforeMove, boardBeforeMove);
            _maxDepth = level;
        }

        protected override int DoAlgorithm()
        {
            return AlphaBetaAlgorithm(1, false, -int.MaxValue, int.MaxValue);
        }

        private int AlphaBetaAlgorithm(int depth, bool isMaximizing, int alpha, int beta)
        {
            TicTacToeChecker ticTacToeChecker = new TicTacToeChecker();

            // checking board state
            if (ticTacToeChecker.CheckIfSymbolWon(TicTacToeSymbol.Circle, _boardBeforeMove))
            {
                return 10;
            }
            else if (ticTacToeChecker.CheckIfSymbolWon(TicTacToeSymbol.Cross, _boardBeforeMove))
            {
                return -10;
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
                            int scoreMax = AlphaBetaAlgorithm(depth + 1, false, alpha, beta);
                            _boardBeforeMove[i, j] = TicTacToeSymbol.Empty;

                            bestScore = Math.Max(scoreMax, bestScore);
                            alpha = Math.Max(alpha, bestScore);
                            if (beta <= alpha)
                                return bestScore;
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
                            int scoreMin = AlphaBetaAlgorithm(depth + 1, true, alpha, beta);
                            _boardBeforeMove[i, j] = TicTacToeSymbol.Empty;

                            bestScore = Math.Min(scoreMin, bestScore);
                            beta = Math.Min(beta, bestScore);
                            if (beta <= alpha)
                                return bestScore;
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}
