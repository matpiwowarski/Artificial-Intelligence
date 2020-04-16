using System;
using System.Collections.Generic;

namespace ArtificialIntelligence.Models.TicTacToe
{
    public class MiniMax
    {
        private TicTacToeSymbol[,] BoardBeforeMove = new TicTacToeSymbol[3, 3]; // x,y

        public MiniMax(TicTacToeSymbol[,] boardBeforeMove)
        {
            CopyTicTacToeBoard(BoardBeforeMove, boardBeforeMove);
        }

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

        public Tuple<int, int> GetBotMove(int level)
        {
            int bestX = 0;
            int bestY = 0;
            int bestScore = -int.MaxValue;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(BoardBeforeMove[i,j] == TicTacToeSymbol.Empty)
                    {
                        BoardBeforeMove[i, j] = TicTacToeSymbol.Circle;
                        int score = GetScore(0, true);
                        BoardBeforeMove[i, j] = TicTacToeSymbol.Empty;
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

        // MiniMax algorithm
        private int GetScore(int depth, bool isMaximizing)
        {
            TicTacToeChecker ticTacToeChecker = new TicTacToeChecker();

            // checking board state
            if (ticTacToeChecker.CheckIfSymbolWon(TicTacToeSymbol.Circle, BoardBeforeMove))
            {
                return 10;
            }
            else if (ticTacToeChecker.CheckIfSymbolWon(TicTacToeSymbol.Cross, BoardBeforeMove))
            {
                return -10;
            }
            else if (ticTacToeChecker.GameEnded(BoardBeforeMove))
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
                        if (BoardBeforeMove[i, j] == TicTacToeSymbol.Empty)
                        {
                            BoardBeforeMove[i, j] = TicTacToeSymbol.Circle;
                            int scoreMax = GetScore(depth + 1, false);
                            BoardBeforeMove[i, j] = TicTacToeSymbol.Empty;

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
                        if (BoardBeforeMove[i, j] == TicTacToeSymbol.Empty)
                        {
                            BoardBeforeMove[i, j] = TicTacToeSymbol.Cross;
                            int scoreMin = GetScore(depth + 1, true);
                            BoardBeforeMove[i, j] = TicTacToeSymbol.Empty;

                            bestScore = Math.Min(scoreMin, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}
