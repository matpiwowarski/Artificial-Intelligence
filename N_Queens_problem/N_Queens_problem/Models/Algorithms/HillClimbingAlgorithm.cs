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
            var maxSteps = chessBoard.Parameters.MaximumNumberOfSteps;

            int bestResult = this.Heuristic(board, size);

            int steps = 0;
            while(bestResult != 0 && steps < maxSteps)
            {
                ChessPiece[,] startingState = CopyBoard(board, size);

                for (int i = 0; i < size; i++) // every column
                {
                    for (int j = 0; j < size; j++) // checking which row is the best in 'i' column and we are moving there our queen
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
                    steps++;
                    if (steps == maxSteps)
                        break;
                }
                
                if(CheckIfBoardsAreEqual(startingState, board, size)) // we are blocked => we have to start again
                {
                    board = GenerateRandomBoardState(size);
                    bestResult = this.Heuristic(board, size);
                }
            }

            chessBoard.HeuristicResult = bestResult;
            chessBoard.Board = board;
        }

        private bool CheckIfBoardsAreEqual(ChessPiece[,] a, ChessPiece[,] b, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (a[i, j] != b[i, j])
                        return false;
                }
            }

            return true;
        }
    }
}
