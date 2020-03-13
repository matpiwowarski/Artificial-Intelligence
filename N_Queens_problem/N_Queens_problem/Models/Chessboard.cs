using System;
namespace N_Queens_problem.Models
{
    public enum ChessPiece
    {
        Empty,
        Queen
    }

    public class Chessboard
    {
        private int _size { get; set; }
        private ChessPiece[,] _board;

        public Chessboard(int size)
        {
            _size = size;
            _board = new ChessPiece[size, size];
        }
    }
}
