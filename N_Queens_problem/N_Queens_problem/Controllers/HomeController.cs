using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N_Queens_problem.Models;
using N_Queens_problem.Models.Algorithms;

namespace N_Queens_problem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        /*
        public IActionResult LocalSearchAlgorithms()
        {
            NQueensProblem nQueensProblem = new NQueensProblem();

            ViewBag.nQueensProblem = nQueensProblem;

            return View();
        }
        */

        // FIRST VIEW + CLEAR()
        public IActionResult LocalSearchAlgorithms(int size = 4)
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

            return View("LocalSearchAlgorithms", board);
        }

        [HttpPost]
        public IActionResult DoAlgorithm(IFormCollection formCollection)
        {
            NQueensProblem nQueensProblem = new NQueensProblem();

            var algorithmName = formCollection["AlgorithmSelect"];

            switch(algorithmName)
            {
                case "Hill Climbing":
                    try // taking parameters from View and set it
                    {
                        var maximumNumberOfSteps = int.Parse(formCollection["MaxSteps"]);
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
                        var maximumNumberOfSteps = int.Parse(formCollection["MaxSteps"]);
                        nQueensProblem.SetMaximumNumberOfSteps(maximumNumberOfSteps);
                        var numberOfStates = int.Parse(formCollection["NumberOfStates"]);
                        nQueensProblem.SetNumberOfStates(numberOfStates);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception message: {0}", e.Message);
                    }
                    nQueensProblem.SetAlgorithm(new LocalBeamSearchAlgorithm());
                    break;

                case "Genetic":
                    nQueensProblem.SetAlgorithm(new GeneticAlgorithm());
                    break;
                default:
                    nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
                    break;
            }

            nQueensProblem.DoAlgorithm();

            var resultBoard = nQueensProblem.GetResultBoard();
            resultBoard.CheckIfProblemSolved();

            return View("LocalSearchAlgorithms", resultBoard);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
