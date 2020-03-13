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

        internal bool CheckIfQueenCanBeAttacked(int x, int y)
        {
            bool isAttacked = CheckIfQueenCanBeAttackedHorizontal(x, y);
            if (isAttacked) return isAttacked;
            isAttacked = CheckIfQueenCanBeAttackedVertical(x, y);
            if (isAttacked) return isAttacked;
            isAttacked = CheckIfQueenCanBeAttackedDiagonal(x, y);
            if (isAttacked) return isAttacked;

            return isAttacked;
        }

        private bool CheckIfQueenCanBeAttackedHorizontal(int x, int y)
        {
            bool isAttacked = false;
            for (int i = x + 1; i < Size; i++)
            {
                if (Board[i, y] == ChessPiece.Queen)
                    isAttacked = true;
            }
            return isAttacked;
        }
        private bool CheckIfQueenCanBeAttackedVertical(int x, int y)
        {
            bool isAttacked = false;
            for (int i = y + 1; i < Size; i++)
            {
                if (Board[x, i] == ChessPiece.Queen)
                    isAttacked = true;
            }
            return isAttacked;
        }
        private bool CheckIfQueenCanBeAttackedDiagonal(int x, int y)
        {
            bool isAttacked = false;
            for (int i = x + 1, j = y + 1; i < Size && j < Size; i++, j++)
            {
                if (Board[i, j] == ChessPiece.Queen)
                    isAttacked = true;
            }
            return isAttacked;
        }
    }
}
