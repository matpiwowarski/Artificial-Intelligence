using System;
namespace N_Queens_problem.Models.Algorithms
{
    public class HillClimbingAlgorithm: Algorithm
    {
        public HillClimbingAlgorithm()
        {
        }

        public override void SolveProblem(Chessboard chessBoard)
        {
            var size = chessBoard.Size;

            var bestBoard = chessBoard.Board;
            int bestResult = Heuristic(bestBoard, size);

            while(bestResult != 0)
            {
                ChessPiece[,] newBoard = new ChessPiece[size, size];
                for (int i = 0; i < size; i++)
                {
                    var random = new Random();
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);

                    while (newBoard[x, y] == ChessPiece.Queen)
                    {
                        x = random.Next(0, size);
                        y = random.Next(0, size);
                    }

                    newBoard[x, y] = ChessPiece.Queen;
                }

                int newResult = Heuristic(newBoard, size);

                if (newResult < bestResult)
                {
                    bestResult = newResult;
                    bestBoard = newBoard;
                }

            }

            chessBoard.HeuristicResult = bestResult;
            chessBoard.Board = bestBoard;
        }
    }
}
