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
        public int Size { get; set; }
        public ChessPiece[,] Board; // BOARD [ ROW , COLUMN]

        public Chessboard(int size)
        {
            Size = size;
            Board = new ChessPiece[size, size];
        }
    }
}
