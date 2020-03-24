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
        public ChessPiece[,] Board { get; set; } // BOARD [ ROW , COLUMN]
        public bool IsSolved { get; set; }
        public int HeuristicResult { get; set; }
        // parameters
        public int MaximumNumberOfSteps { get; set; } // 1st algorithm
        public double StartingTemperature { get; set; } // 2nd algorithm
        public double CoolingFactor { get; set; } // 2nd algorithm

        public Chessboard()
        {
            // default values
            MaximumNumberOfSteps = 50;
            StartingTemperature = 1000;
            CoolingFactor = 1;
        }

        public Chessboard(int size)
        {
            Size = size;
            Board = new ChessPiece[size, size];
            IsSolved = false;
            // default values
            MaximumNumberOfSteps = 50;
            StartingTemperature = 1000;
            CoolingFactor = 1;
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
            for (int i = x + 1, j = y - 1; i < Size && j >= 0; i++, j--)
            {
                if (Board[i, j] == ChessPiece.Queen)
                    isAttacked = true;
            }
            return isAttacked;
        }

        public bool CheckIfProblemSolved()
        {
            IsSolved = true;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] == ChessPiece.Queen)
                    {
                        bool queenCanBeAttacked = CheckIfQueenCanBeAttacked(i, j);
                        if (queenCanBeAttacked)
                        {
                            IsSolved = false;
                            break;
                        }
                    }
                }
            }

            return IsSolved;
        }
    }
}
