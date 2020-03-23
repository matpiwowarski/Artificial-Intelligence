using System;
namespace N_Queens_problem.Models.Algorithms
{
    public abstract class Algorithm
    {
        public abstract void SolveProblem(Chessboard chessboard);

        // h(x) = pairs of queens that are attacking each other (directly or indirectly)
        public int Heuristic(ChessPiece[,] board, int boardSize)
        {
            int result = 0;
            int queenToCount = boardSize;

            for(int x = 0; x < boardSize; x++)
            {
                for(int y = 0; y < boardSize; y++)
                {
                    if (queenToCount == 0)
                        break;

                    if(board[x,y] == ChessPiece.Queen)
                    {
                        queenToCount--;

                        result += HeuristicRight(board, boardSize, x, y);
                        result += HeuristicDown(board, boardSize, x, y);
                        result += HeuristicRightDown(board, boardSize, x, y);
                        result += HeuristicRightUp(board, boardSize, x, y);
                    }

                }
            }

            return result;
        }

        private int HeuristicRightUp(ChessPiece[,] board, int size, int x, int y)
        {
            int result = 0;
            for (int i = x + 1, j = y - 1; i < size && j >= 0; i++, j--)
            {
                if (board[i, j] == ChessPiece.Queen)
                    result++;
            }
            return result;
        }

        private int HeuristicRightDown(ChessPiece[,] board, int size, int x, int y)
        {
            int result = 0;
            for (int i = x + 1, j = y + 1; i < size && j < size; i++, j++)
            {
                if (board[i, j] == ChessPiece.Queen)
                    result++;
            }
            return result;
        }

        private int HeuristicDown(ChessPiece[,] board, int size, int x, int y)
        {
            int result = 0;
            for (int i = y + 1; i < size; i++)
            {
                if (board[x, i] == ChessPiece.Queen)
                    result++;
            }
            return result;
        }

        private int HeuristicRight(ChessPiece[,] board, int size, int x, int y)
        {
            int result = 0;
            for (int i = x + 1; i < size; i++)
            {
                if (board[i, y] == ChessPiece.Queen)
                    result++;
            }
            return result;
        }
    }
}
