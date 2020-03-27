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
            var temperature = chessBoard.Parameters.StartingTemperature;
            var coolingFactor = chessBoard.Parameters.CoolingFactor;

            int steps = 0;

            var currentResult = this.Heuristic(board, size);

            while (temperature > 0 && currentResult != 0)
            {
                ChessPiece[,] boardBeforeMove = CopyBoard(board,size);
                // 1. Random move
                RandomMove1Queen(board, size);
                var newResult = this.Heuristic(board, size);
                // h = current H(x) - new H(x)
                int h = currentResult - newResult;
                // 2. better result -> save it
                if (h > 0)
                {
                    currentResult = newResult;
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
                    }
                    else // else rejected -> don't save 
                    {
                        board = boardBeforeMove;
                    }

                }

                // 4. Reduce temperature
                temperature -= coolingFactor;
                steps++;
            }

            chessBoard.Steps = steps;
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
