using System;
using System.Collections.Generic;

namespace ArtificialIntelligence.Models.TicTacToe
{
    public class MiniMax
    {
        private TicTacToeSymbol[,] BoardBeforeMove = new TicTacToeSymbol[3, 3]; // x,y

        public MiniMax(TicTacToeSymbol[,] boardBeforeMove)
        {
            // rewrite board (it won't work with the original)
            for(int x = 0; x < 3; x ++)
            {
                for(int y = 0; y < 3; y ++)
                {
                    BoardBeforeMove[x, y] = boardBeforeMove[x, y];
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
                        int score = GetScore(i, j);
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

        private int GetScore(int x, int y)
        {
            return 1;
        }
    }
}
