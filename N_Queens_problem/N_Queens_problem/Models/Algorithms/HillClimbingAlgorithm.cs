using System;
namespace N_Queens_problem.Models.Algorithms
{
    public class HillClimbingAlgorithm: Algorithm
    {
        public HillClimbingAlgorithm()
        {
        }


        // N x (N-1) possible successors
        //Hill Climbing with random restart
        public override void SolveProblem(Chessboard chessBoard)
        {
            var size = chessBoard.Size;
            var board = chessBoard.Board;

            int bestResult = this.Heuristic(board, size);

            while(bestResult != 0)
            {
                ChessPiece[,] startingState = board;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        int rowBeforeMovingQueen = GetQueenRowInColumn(board, size, i);

                        this.MoveQueenVertical(board, size, i, j);
                        int newResult = this.Heuristic(board, size);

                        if (newResult < bestResult) // better => moving queen and remember result
                        {
                            bestResult = newResult;
                        }
                        else // worse or equal => puting back our queen
                        {
                            this.MoveQueenVertical(board, size, i, rowBeforeMovingQueen);
                        }

                        if (bestResult == 0) // h(x) == 0 => we solved the problem
                            break;
                    }
                }

                if(startingState.Equals(board)) // we are blocked => we have to start again
                {
                    board = GenerateRandomBoardState(size);
                }
            }

            chessBoard.HeuristicResult = bestResult;
            chessBoard.Board = board;
        }
    }
}
