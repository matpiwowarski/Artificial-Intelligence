using System;
using System.Collections.Generic;

namespace ArtificialIntelligence.Models.Algorithms
{
    public class LocalBeamSearchAlgorithm: Algorithm
    {

        public override void SolveProblem(Chessboard chessBoard)
        {
            var boardSize = chessBoard.Size;
            var numberOfStates = chessBoard.Parameters.NumberOfStates;
            var maxNumberOfSteps = chessBoard.Parameters.MaximumNumberOfSteps;

            int steps = 0;

            var states = new List<ChessPiece[,]>();

            // generate X states
            for (int i = 0; i < numberOfStates; i++)
            {
                var generatedState = this.GenerateRandomBoardState(boardSize);
                states.Add(generatedState);
            }

            var bestState = states[0];
            int bestResult = Heuristic(states[0], boardSize);

            // iterations - steps = depth of search
            for (int i = 0; i < maxNumberOfSteps; i++)
            {
                MoveQueensInEveryState(states, boardSize); // if state gets stuck => it will be replaced

                bestState = ReturnBestState(states, boardSize);
                bestResult = Heuristic(bestState, boardSize);

                steps++;

                if (bestResult == 0)
                    break;
            }

            chessBoard.Steps = steps;
            chessBoard.Board = bestState;
            chessBoard.HeuristicResult = bestResult;
        }

        private ChessPiece[,] ReturnBestState(List<ChessPiece[,]> states, int boardSize)
        {
            int bestResult = Heuristic(states[0], boardSize);
            ChessPiece[,] bestState = states[0];

            foreach (var state in states)
            {
                int newResult = Heuristic(state, boardSize);

                if (newResult < bestResult)
                    bestState = state;
            }

            return bestState;
        }

        private void MoveQueensInEveryState(List<ChessPiece[,]> states, int boardSize)
        {
            for(int stateIndex = 0; stateIndex < states.Count; stateIndex++)
            {
                int resultBeforeChanges = Heuristic(states[stateIndex], boardSize);

                if (resultBeforeChanges == 0) // one of our state is solved so we don't care about the rest
                    break;

                for (int i = 0; i < boardSize; i++) // every column
                {
                    for (int j = 0; j < boardSize; j++) // checking which row is the best in 'i' column and we are moving there our queen
                    {
                        int rowBeforeMovingQueen = GetQueenRowInColumn(states[stateIndex], boardSize, i);
                        int resultBeforeMovingQueen = Heuristic(states[stateIndex], boardSize);

                        this.MoveQueenVertical(states[stateIndex], boardSize, i, j);
                        int newResult = this.Heuristic(states[stateIndex], boardSize);

                        if (newResult < resultBeforeMovingQueen)
                        {
                            // we have already moved queen so it stays
                        }
                        else // worse or equal => puting back our queen
                        {
                            this.MoveQueenVertical(states[stateIndex], boardSize, i, rowBeforeMovingQueen);
                        }

                        if (newResult == 0) // h(x) == 0 => we solved the problem
                            break;
                    }
                }
                int resultAfterChanges = Heuristic(states[stateIndex], boardSize);
                if (resultBeforeChanges == resultAfterChanges) // we didn't move any queen => we generate new board
                {
                    states[stateIndex] = GenerateRandomBoardState(boardSize);
                }
            }
        }
    }
}
