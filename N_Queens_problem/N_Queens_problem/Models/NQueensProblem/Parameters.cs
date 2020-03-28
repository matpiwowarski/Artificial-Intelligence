using System;
namespace N_Queens_problem.Models
{
    public class Parameters
    {
        // 1st and 3rd algorithm
        public uint MaximumNumberOfSteps { get; set; }
        // 2nd algorithm
        public double StartingTemperature { get; set; } 
        public double CoolingFactor { get; set; }
        // 3rd algorithm
        public uint NumberOfStates { get; set; }
        // 4th algorithm
        public int SizeOfSingleGeneration { get; set; }
        public double PercentOfElitism { get; set; }
        public double CrossoverProbability { get; set; }
        public double MutationProbability { get; set; }
        public int NumberOfGenerations { get; set; }

        public Parameters()
        {
            // default values
            MaximumNumberOfSteps = 50;
            StartingTemperature = 10000;
            CoolingFactor = 1;
            NumberOfStates = 20;
            SizeOfSingleGeneration = 100;
            PercentOfElitism = 20;
            CrossoverProbability = 35;
            MutationProbability = 5;
            NumberOfGenerations = 1000;
        }
    }
}
