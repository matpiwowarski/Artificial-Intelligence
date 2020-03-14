using System;
using N_Queens_problem.Models.Algorithms;

namespace N_Queens_problem.Models
{
    public class NQueensProblem
    {
        private Chessboard _chessboard;
        private Algorithm _algorithm;

        public NQueensProblem()
        {
            _chessboard = new Chessboard(4);
        }

        public NQueensProblem(int size)
        {
            _chessboard = new Chessboard(size);
        }

        public void SetAlgorithm(Algorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public Chessboard GetResultBoard()
        {
            return _chessboard;
        }

        public bool CheckIfProblemSolved()
        {
            bool solved = true;

            for(int i = 0; i < _chessboard.Size; i++)
            {
                for(int j = 0; j < _chessboard.Size; j++)
                {
                    if(_chessboard.Board[i, j] == ChessPiece.Queen)
                    {
                        bool queenCanBeAttacked = _chessboard.CheckIfQueenCanBeAttacked(i, j);
                        if (queenCanBeAttacked)
                        {
                            solved = false;
                            break;
                        }
                    }
                }
            }

            return solved;
        }
    }
}
