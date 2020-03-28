using System;
namespace N_Queens_problem.Models.Algorithms
{
    public class GeneticAlgorithm: Algorithm
    {
        public override void SolveProblem(Chessboard chessboard)
        {
            var sizeOfSingleGeneration = chessboard.Parameters.SizeOfSingleGeneration;
            var percentOfElitism = chessboard.Parameters.PercentOfElitism / 100;
            var crossoverProbability = chessboard.Parameters.CrossoverProbability / 100;
            var mutationProbability = chessboard.Parameters.MutationProbability / 100;
            var numberOfGenerations = chessboard.Parameters.NumberOfGenerations;

        }
    }
}
