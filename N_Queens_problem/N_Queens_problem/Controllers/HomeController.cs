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

            var board = nQueensProblem.GetResultBoard();
            board.CheckIfProblemSolved();

            return View("LocalSearchAlgorithms", board);
        }

        [HttpPost]
        public IActionResult DoAlgorithm(IFormCollection formCollection,int size)
        {
            NQueensProblem nQueensProblem = new NQueensProblem(size);
            var algorithmName = formCollection["Algorithm"];

            switch(algorithmName)
            {
                case "Hill Climbing":
                    nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
                    break;
                default:
                    nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
                    break;
            }

            nQueensProblem.DoAlgorithm();

            var board = nQueensProblem.GetResultBoard();
            board.CheckIfProblemSolved();

            return View("LocalSearchAlgorithms", board);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
