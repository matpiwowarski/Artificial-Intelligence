using System;
using System.Collections.Generic;

namespace N_Queens_problem.Models.Algorithms
{
    public class LocalBeamSearchAlgorithm: Algorithm
    {

        public override void SolveProblem(Chessboard chessBoard)
        {
            var size = chessBoard.Size;
            var numberOfStates = chessBoard.Parameters.StartingTemperature;
            var maxNumberOfSteps = chessBoard.Parameters.CoolingFactor;

            var states = new List<ChessPiece[,]>();

            // generate X states
            for (int i = 0; i < numberOfStates; i++)
            {
                var generatedState = this.GenerateRandomBoardState(size);
                states.Add(generatedState);
            }

            // iterations - steps = depth of search
            for (int i = 0; i < maxNumberOfSteps; i++)
            {
                var solvedState = ReturnStateIfAnyIsSolved(states, size);

                if (solvedState != null)
                {
                    chessBoard.Board = solvedState;
                    chessBoard.HeuristicResult = Heuristic(solvedState, size);
                    break;
                }
            }
        }

        private ChessPiece[,] ReturnStateIfAnyIsSolved(List<ChessPiece[,]> states, int size)
        {
            foreach(var state in states)
            {
                if (Heuristic(state, size) == 0)
                    return state;
            }

            // there's no solution in list of states
            return null;
        }

    }
}
