using System;
namespace N_Queens_problem.Models.Algorithms
{
    public class HillClimbingAlgorithm: Algorithm
    {
        public HillClimbingAlgorithm()
        {
        }


        // N x (N-1) possible successors
        public override void SolveProblem(Chessboard chessBoard)
        {
            var size = chessBoard.Size;

            for(int i = 0; i < chessBoard.Size; i++)
            {
                for(int j = 0; j < chessBoard.Size; j++)
                {

                }
            }

            //chessBoard.HeuristicResult = bestResult;
            //chessBoard.Board = bestBoard;
        }
    }
}
