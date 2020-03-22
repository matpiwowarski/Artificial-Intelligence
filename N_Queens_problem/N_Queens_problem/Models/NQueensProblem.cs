﻿using System;
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

        public void SolvedProblemExample()
        {
            _chessboard.Board[0, 1] = ChessPiece.Queen;
            _chessboard.Board[1, 3] = ChessPiece.Queen;
            _chessboard.Board[2, 0] = ChessPiece.Queen;
            _chessboard.Board[3, 2] = ChessPiece.Queen;
        }
        public void UnsolvedProblemExample()
        {
            _chessboard.Board[0, 0] = ChessPiece.Queen;
            _chessboard.Board[0, 1] = ChessPiece.Queen;
            _chessboard.Board[0, 2] = ChessPiece.Queen;
            _chessboard.Board[0, 3] = ChessPiece.Queen;
        }

        public void SetRandomBoardState()
        {
            for(int i = 0; i < _chessboard.Size; i++)
            {
                Random random = new Random();
                int x = random.Next(0, _chessboard.Size);
                int y = random.Next(0, _chessboard.Size);

                while (_chessboard.Board[x,y] == ChessPiece.Queen)
                {
                    x = random.Next(0, _chessboard.Size);
                    y = random.Next(0, _chessboard.Size);
                }

                _chessboard.Board[x, y] = ChessPiece.Queen;
            }
        }

        public void DoAlgorithm()
        {
            _algorithm.SolveProblem(_chessboard);
        }
    }
}
