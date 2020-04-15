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
            int x = 0;
            int y = 0;



            return new Tuple<int, int>(x, y);
        }
    }
}
