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

        public void SetAlgorithm(Algorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public Chessboard GetResultBoard()
        {
            return _chessboard;
        }
    }
}
