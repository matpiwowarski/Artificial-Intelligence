using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArtificialIntelligence.Models;
using ArtificialIntelligence.Models.Algorithms;

namespace ArtificialIntelligence.Controllers
{
    public class LocalSearchAlgorithmsController : Controller
    {
        public IActionResult Index(int size = 4)
        {
            NQueensProblem nQueensProblem = new NQueensProblem(size);

            nQueensProblem.SetRandomBoardState();
            nQueensProblem.DoAlgorithm(); // just heuristic result

            var board = nQueensProblem.GetResultBoard();

            board.CheckIfProblemSolved();

            return View(board);
        }

        [HttpPost]
        public IActionResult ChangeBoardgameSize(IFormCollection formCollection)
        {
            int size = int.Parse(formCollection["SizeSelect"]);

            NQueensProblem nQueensProblem = new NQueensProblem(size);

            nQueensProblem.SetRandomBoardState();
            nQueensProblem.DoAlgorithm(); // just heuristic result

            var board = nQueensProblem.GetResultBoard();
            board.CheckIfProblemSolved();

            return View("Index", board);
        }

        [HttpPost]
        public IActionResult DoAlgorithm(IFormCollection formCollection)
        {
            NQueensProblem nQueensProblem = new NQueensProblem();

            var algorithmName = formCollection["AlgorithmSelect"];

            switch (algorithmName)
            {
                case "Hill Climbing":
                    try // taking parameters from View and set it
                    {
                        var maximumNumberOfSteps = uint.Parse(formCollection["MaxSteps"]);
                        nQueensProblem.SetMaximumNumberOfSteps(maximumNumberOfSteps);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception message: {0}", e.Message);
                    }
                    nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
                    break;

                case "Simulated Annealing":
                    try // taking parameters from View and set it
                    {
                        var startingTemperature = int.Parse(formCollection["StartingTemperature"]);
                        nQueensProblem.SetStartingTemperature(startingTemperature);
                        var coolingFactor = int.Parse(formCollection["CoolingFactor"]);
                        nQueensProblem.SetCoolingFactor(coolingFactor);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception message: {0}", e.Message);
                    }
                    nQueensProblem.SetAlgorithm(new SimulatedAnnealingAlgorithm());
                    break;

                case "Local Beam Search":
                    try // taking parameters from View and set it
                    {
                        var maximumNumberOfSteps = uint.Parse(formCollection["MaxSteps"]);
                        nQueensProblem.SetMaximumNumberOfSteps(maximumNumberOfSteps);
                        var numberOfStates = uint.Parse(formCollection["NumberOfStates"]);
                        nQueensProblem.SetNumberOfStates(numberOfStates);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception message: {0}", e.Message);
                    }
                    nQueensProblem.SetAlgorithm(new LocalBeamSearchAlgorithm());
                    break;
                case "Genetic":
                    try // taking parameters from View and set it
                    {
                        var sizeOfSingleGeneration = int.Parse(formCollection["SizeOfSingleGeneration"]);
                        nQueensProblem.SetSizeOfSingleGeneration(sizeOfSingleGeneration);

                        var percentOfElitism = int.Parse(formCollection["PercentOfElitism"]);
                        nQueensProblem.SetPercentOfElitism(percentOfElitism);

                        var crossoverProbability = int.Parse(formCollection["CrossoverProbability"]);
                        nQueensProblem.SetCrossoverProbability(crossoverProbability);

                        var mutationProbability = int.Parse(formCollection["MutationProbability"]);
                        nQueensProblem.SetMutationProbability(mutationProbability);

                        var numberOfGenerations = int.Parse(formCollection["NumberOfGenerations"]);
                        nQueensProblem.SetNumberOfGenerations(numberOfGenerations);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception message: {0}", e.Message);
                    }
                    nQueensProblem.SetAlgorithm(new GeneticAlgorithm());
                    break;
                default:
                    nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
                    break;
            }

            nQueensProblem.DoAlgorithm();

            var resultBoard = nQueensProblem.GetResultBoard();
            resultBoard.CheckIfProblemSolved();

            return View("Index", resultBoard);
        }
    }
}

