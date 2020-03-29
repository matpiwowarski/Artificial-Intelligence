using System;
using System.Collections.Generic;

namespace N_Queens_problem.Models.Algorithms
{
    public class GeneticAlgorithm: Algorithm
    {
        public override void SolveProblem(Chessboard chessBoard)
        {
            int sizeOfSingleGeneration = chessBoard.Parameters.SizeOfSingleGeneration;
            double percentOfElitism = chessBoard.Parameters.PercentOfElitism / 100;
            double crossoverProbability = chessBoard.Parameters.CrossoverProbability / 100;
            double mutationProbability = chessBoard.Parameters.MutationProbability / 100;
            int numberOfGenerations = chessBoard.Parameters.NumberOfGenerations;

            int boardSize = chessBoard.Size;
            int steps = 0;


            var population = new List<ChessPiece[,]>(); // population -> list of states

            // generate initial population
            for (int i = 0; i < sizeOfSingleGeneration; i++)
            {
                var generatedState = this.GenerateRandomBoardState(boardSize);
                population.Add(generatedState);
            }

            var bestState = ReturnBestState(population, boardSize);
            int bestResult = Heuristic(bestState, boardSize);

            for (int i = 0; i < numberOfGenerations; i++)
            {
                // 1. Selection
                SelectPopulation(population);
                // 2. Crossover
                Crossover(population, boardSize, crossoverProbability);
                // 3. Mutation
            }



            chessBoard.Steps = steps;
            chessBoard.Board = bestState;
            chessBoard.HeuristicResult = bestResult;
        }

        private void Crossover(List<ChessPiece[,]> population, int boardSize, double crossoverProbability)
        {
            Random random = new Random();
            var randomValue = random.NextDouble(); // random 0.0 - 1.0

            if(randomValue <= crossoverProbability)
            {
                for(int i = 0; i < population.Count; i = i + 2)
                {
                    // 1st with 2nd, 3rd with 4th, 5th with 6th state:
                    SwitchEvery2ndColumn(population[i], population[i + 1], boardSize);
                }
            }
            // otherwise we skip crossover
        }

        private void SwitchEvery2ndColumn(ChessPiece[,] chessPiece1, ChessPiece[,] chessPiece2, int boardSize)
        {
            for(int i = 0; i < boardSize; i++)
            {

            }
        }

        private void SelectPopulation(List<ChessPiece[,]> population)
        {

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
    }
}
