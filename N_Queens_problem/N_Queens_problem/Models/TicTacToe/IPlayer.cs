using System;
namespace ArtificialIntelligence.Models.TicTacToe
{
    public interface IPlayer
    {
        public bool MakeMove(int x, int y);
        public void WonGame();
        public int GetScore();
    }
}
