using System;
using System.Collections.Generic;

namespace N_Queens_problem.Models.Algorithms
{
    public class LocalBeamSearchAlgorithm: Algorithm
    {

        public override void SolveProblem(Chessboard chessBoard)
        {
            var size = chessBoard.Size;
            var numberOfStates = chessBoard.Parameters.NumberOfStates;
            var maxNumberOfSteps = chessBoard.Parameters.MaximumNumberOfSteps;

            int steps = 0;

            var states = new List<ChessPiece[,]>();

            // generate X states
            for (int i = 0; i < numberOfStates; i++)
            {
                var generatedState = this.GenerateRandomBoardState(size);
                states.Add(generatedState);
            }

            var bestState = states[0];
            int bestResult = Heuristic(states[0], size);

            // iterations - steps = depth of search
            for (int i = 0; i < maxNumberOfSteps; i++)
            {
                MoveQueensInEveryState(states, size); // if state gets stuck => it will be replaced

                bestState = ReturnBestState(states, size);
                bestResult = Heuristic(bestState, size);

                steps++;

                if (bestResult == 0)
                    break;
            }

            chessBoard.Steps = steps;
            chessBoard.Board = bestState;
            chessBoard.HeuristicResult = bestResult;
        }

        private ChessPiece[,] ReturnBestState(List<ChessPiece[,]> states, int size)
        {
            int bestResult = Heuristic(states[0], size);
            ChessPiece[,] bestState = states[0];

            foreach (var state in states)
            {
                int newResult = Heuristic(state, size);

                if (newResult < bestResult)
                    bestState = state;
            }

            return bestState;
        }

        private void MoveQueensInEveryState(List<ChessPiece[,]> states, int size)
        {
            for(int index = 0; index < size; index++)
            {
                int resultBeforeChanges = Heuristic(states[index], size);

                if (resultBeforeChanges == 0) // one of our state is solved so we don't care about the rest
                    break;

                for (int i = 0; i < size; i++) // every column
                {
                    for (int j = 0; j < size; j++) // checking which row is the best in 'i' column and we are moving there our queen
                    {
                        int rowBeforeMovingQueen = GetQueenRowInColumn(states[index], size, i);
                        int resultBeforeMovingQueen = Heuristic(states[index], size);

                        this.MoveQueenVertical(states[index], size, i, j);
                        int newResult = this.Heuristic(states[index], size);

                        if (newResult < resultBeforeMovingQueen)
                        {
                            // we have already moved queen so it stays
                        }
                        else // worse or equal => puting back our queen
                        {
                            this.MoveQueenVertical(states[index], size, i, rowBeforeMovingQueen);
                        }

                        if (newResult == 0) // h(x) == 0 => we solved the problem
                            break;
                    }
                }
                int resultAfterChanges = Heuristic(states[index], size);
                if (resultBeforeChanges == resultAfterChanges) // we didn't move any queen => we generate new board
                {
                    states[index] = GenerateRandomBoardState(size);
                }
            }
        }
    }
}
