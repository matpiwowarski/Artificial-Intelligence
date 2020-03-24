using System;
namespace N_Queens_problem.Models.Algorithms
{
    public class SimulatedAnnealingAlgorithm: Algorithm
    {
        // higher temperature -> more randomly
        // cooling parameter -> reduce temperature
        // h = current H(x) - new H(x)
        // probability of accetance: min(1,e^(h/T)
        public override void SolveProblem(Chessboard chessBoard)
        {
            var size = chessBoard.Size;
            var board = chessBoard.Board;
            var temperature = chessBoard.StartingTemperature;
            var coolingFactor = chessBoard.CoolingFactor;

            var currentResult = this.Heuristic(board, size);

            while (temperature > 0 && currentResult != 0)
            {
                // 1. Random move
                ChessPiece[,] randomState = GenerateRandomBoardState(size);
                var newResult = this.Heuristic(randomState, size);
                // h = current H(x) - new H(x)
                int h = currentResult - newResult;
                // 2. better result -> save it
                if (h > 0)
                {
                    currentResult = newResult;
                    board = randomState;
                }
                // 3. worse result :
                //      a) too risky -> start start again
                //      b) not too risky -> accept it
                else
                {
                    // probability of accetance: min(1,e^(h/T)

                    double probability = Math.Exp(h / temperature);
                    if (probability > 1)
                        probability = 1;

                    if (CheckIfShouldBeAccepted(probability))
                    {
                        // accepted
                        currentResult = newResult;
                        board = randomState;
                    }
                    else
                    {
                        // rejected
                    }

                }

                temperature = temperature - coolingFactor;
            }



            // 4. Reduce temperature
            chessBoard.HeuristicResult = currentResult;
            chessBoard.Board = board;
        }

        private bool CheckIfShouldBeAccepted(double probability)
        {
            if (probability == 1)
                return true;
            else
            {
                Random random = new Random();
                var randomValue = random.NextDouble(); // random 0.0 - 1.0

                if (randomValue <= probability)
                    return true;
                else
                    return false;
            }
        }

    }
}
