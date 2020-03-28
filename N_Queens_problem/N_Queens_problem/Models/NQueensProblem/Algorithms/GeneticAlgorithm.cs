using System;
using System.Collections.Generic;

namespace N_Queens_problem.Models.Algorithms
{
    public class GeneticAlgorithm: Algorithm
    {
        public override void SolveProblem(Chessboard chessBoard)
        {
            var sizeOfSingleGeneration = chessBoard.Parameters.SizeOfSingleGeneration;
            var percentOfElitism = chessBoard.Parameters.PercentOfElitism / 100;
            var crossoverProbability = chessBoard.Parameters.CrossoverProbability / 100;
            var mutationProbability = chessBoard.Parameters.MutationProbability / 100;
            var numberOfGenerations = chessBoard.Parameters.NumberOfGenerations;

            var boardSize = chessBoard.Size;
            int steps = 0;


            var generation = new List<ChessPiece[,]>(); // generation -> list of states

            // generate initial generation
            for (int i = 0; i < sizeOfSingleGeneration; i++)
            {
                var generatedState = this.GenerateRandomBoardState(boardSize);
                generation.Add(generatedState);
            }

            for(int i = 0; i < numberOfGenerations; i++)
            {

            }

            var bestState = generation[0];
            int bestResult = Heuristic(generation[0], boardSize);


            chessBoard.Steps = steps;
            chessBoard.Board = bestState;
            chessBoard.HeuristicResult = bestResult;
        }
    }
}
