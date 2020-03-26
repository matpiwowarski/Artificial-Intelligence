using System;
namespace N_Queens_problem.Models
{
    public class Parameters
    {
        // 1st and 3rd algorithm
        public int MaximumNumberOfSteps { get; set; }
        // 2nd algorithm
        public double StartingTemperature { get; set; } 
        public double CoolingFactor { get; set; }
        // 3rd algorithm
        public int NumberOfStates { get; set; }
        // 4th algorithm
        public int SizeOfSingleGeneration { get; set; }
        public int PercentOfElitism { get; set; }
        public int CrossoverProbability { get; set; }
        public int MutationProbability { get; set; }
        public int NumberOfGenerations { get; set; }

        public Parameters()
        {
            // default values
            MaximumNumberOfSteps = 50;
            StartingTemperature = 10000;
            CoolingFactor = 1;
            NumberOfStates = 20;
        }
    }
}
