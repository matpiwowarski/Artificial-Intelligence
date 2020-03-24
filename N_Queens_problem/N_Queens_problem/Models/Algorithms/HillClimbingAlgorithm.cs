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

            int counter = 0;
            while(bestResult != 0 && counter < chessBoard.MaximumNumberOfSteps)
            {
                ChessPiece[,] startingState = CopyBoard(board, size);

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
                
                if(CheckIfBoardsAreEqual(startingState, board, size)) // we are blocked => we have to start again
                {
                    board = GenerateRandomBoardState(size);
                    bestResult = this.Heuristic(board, size);
                }
                counter++;
            }

            chessBoard.HeuristicResult = bestResult;
            chessBoard.Board = board;
        }


        private ChessPiece[,] CopyBoard(ChessPiece[,] board, int size)
        {
            ChessPiece[,] copy = new ChessPiece[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    copy[i, j] = board[i, j];
                }
            }

            return copy;
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
