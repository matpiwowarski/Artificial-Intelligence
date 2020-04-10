﻿using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public class TicTacToe
    {
        public TicTacToeMove[,] ticTacToeBoard = new TicTacToeMove[3, 3]; // x,y
        public IPlayer WhoStarts;
        public int Level;
        public int UserScore = 0;
        public int BotScore = 0;
        public int TieScore = 0;

        public TicTacToe()
        {

        }

        public TicTacToe(int level)
        {
            Level = level;
        }

        public void SetWhoStarts(IPlayer player)
        {
            this.WhoStarts = player;
        }

        public void UserWon()
        {
            UserScore++;
        }

        public void BotWon()
        {
            BotScore++;
        }

        public IPlayer CheckIfPlayerWon(TicTacToeUser user, TicTacToeBot bot)
        {
            // checking user
            if(CheckIfMoveWins(TicTacToeMove.Cross))
            {
                return user;
            }
            // checking bot
            if (CheckIfMoveWins(TicTacToeMove.Circle))
            {
                return user;
            }

            return null;
        }

        private bool CheckIfMoveWins(TicTacToeMove move)
        {
            // checking horizontal
            for (int x = 0; x < 3; x++)
            {
                if (ticTacToeBoard[x, 0] == move && ticTacToeBoard[x, 1] == move && ticTacToeBoard[x, 2] == move)
                {
                    return true;
                }
            }
            // vertical
            for (int y = 0; y < 3; y++) 
            {
                if (ticTacToeBoard[0, y] == move && ticTacToeBoard[1, y] == move && ticTacToeBoard[2, y] == move)
                {
                    return true;
                }
            }
            // diagonal
            if (ticTacToeBoard[0, 0] == move && ticTacToeBoard[1, 1] == move && ticTacToeBoard[2, 2] == move)
            {
                return true;
            }
            if (ticTacToeBoard[2, 0] == move && ticTacToeBoard[1, 1] == move && ticTacToeBoard[0, 2] == move)
            {
                return true;
            }
            return false;
        }
    }
}
