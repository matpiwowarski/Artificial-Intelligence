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

        protected void MoveQueenVertical(ChessPiece[,] board, int size, int column, int newRow)
        {
            for (int i = 0; i < size; i++)
            {
                if (board[i, column] == ChessPiece.Queen) // deleting older one
                    board[i, column] = ChessPiece.Empty;

                board[newRow, column] = ChessPiece.Queen;
            }
        }

        protected int GetQueenRowInColumn(ChessPiece[,] board, int size, int column)
        {
            for (int i = 0; i < size; i++)
            {
                if (board[i, column] == ChessPiece.Queen)
                    return i;
            }

            return -1; // Queen not found
        }

        public ChessPiece[,] GenerateRandomBoardState(int size)
        {
            ChessPiece[,] newBoard = new ChessPiece[size, size];

            for (int x = 0; x < size; x++)
            {
                Random random = new Random();
                int y = random.Next(0, size);

                newBoard[y, x] = ChessPiece.Queen;
            }

            return newBoard;
        }

        protected ChessPiece[,] CopyBoard(ChessPiece[,] board, int size)
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

        protected void RandomMove1Queen(ChessPiece[,] board, int size)
        {
            var random = new Random();
            int randomColumn = random.Next(size);
            int randomRow = random.Next(size);

            MoveQueenVertical(board, size, randomColumn, randomRow);
        }
    }
}
