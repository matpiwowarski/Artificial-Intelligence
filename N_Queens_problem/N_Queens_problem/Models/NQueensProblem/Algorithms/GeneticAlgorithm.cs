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

            var generation = new List<ChessPiece[,]>(); // generation -> list of states

            // generate initial generation
            for (int i = 0; i < sizeOfSingleGeneration; i++)
            {
                var generatedState = this.GenerateRandomBoardState(boardSize);
                generation.Add(generatedState);
            }

            var bestState = chessBoard.Board;
            int bestResult = chessBoard.HeuristicResult;
            // N iterations
            for (int i = 0; i < numberOfGenerations; i++)
            {
                // calculate h for each state and find the best
                bestState = ReturnBestState(generation, boardSize);
                bestResult = Heuristic(bestState, boardSize);
                if (bestResult == 0)
                    break;

                var newGeneration = new List<ChessPiece[,]>();

                // 1. Selection
                SortListOfStates(generation, boardSize);
                ChessPiece[,] parent1 = generation[0];
                ChessPiece[,] parent2 = generation[1];

                SelectPopulation(generation, boardSize, percentOfElitism);
                // 2. Crossover
                Crossover(generation, boardSize, crossoverProbability);
                // 3. Mutation
                Mutation(generation, boardSize, mutationProbability);

                steps++;
            }

            chessBoard.Steps = steps;
            chessBoard.Board = bestState;
            chessBoard.HeuristicResult = bestResult;
        }

        private void SelectPopulation(List<ChessPiece[,]> population, int boardSize, double percentOfElitism)
        {
            
        }

        private void Mutation(List<ChessPiece[,]> population, int boardSize, double mutationProbability)
        {
            Random random = new Random();
            var randomValue = random.NextDouble(); // random 0.0 - 1.0

            if (randomValue <= mutationProbability)
            {

            }
            // otherwise we skip mutation
        }

        private void Crossover(List<ChessPiece[,]> population, int boardSize, double crossoverProbability)
        {
            Random random = new Random();
            var randomValue = random.NextDouble(); // random 0.0 - 1.0

            if(randomValue <= crossoverProbability)
            {
                for(int i = 0; i < population.Count; i += 2)
                {
                    // 1st with 2nd, 3rd with 4th, 5th with 6th state:
                    Random randomPoint = new Random();
                    int crossoverPoint = randomPoint.Next(boardSize - 1); // (0, size - 2)

                    SwitchPartsOfStates(population[i], population[i + 1], crossoverPoint, boardSize);
                }
            }
            // otherwise we skip crossover
        }

        private void SwitchPartsOfStates(ChessPiece[,] state1, ChessPiece[,] state2, int crossoverPoint, int boardSize)
        {
            // crossoverPoint = X => first X columns won't be switched
            for(int i = crossoverPoint; i < boardSize; i++)
            {
                SwitchColumns(state1, state2, i, boardSize);
            }
        }

        private void SwitchColumns(ChessPiece[,] board1, ChessPiece[,] board2, int columnToSwitch, int boardSize)
        {
            int row1 = GetQueenRowInColumn(board1, boardSize, columnToSwitch);
            int row2 = GetQueenRowInColumn(board2, boardSize, columnToSwitch);

            MoveQueenVertical(board1, boardSize, columnToSwitch, row2);
            MoveQueenVertical(board2, boardSize, columnToSwitch, row1);
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
