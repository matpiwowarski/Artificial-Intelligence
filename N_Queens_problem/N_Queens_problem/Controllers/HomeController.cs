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
    
        public IActionResult LocalSearchAlgorithms(int size = 4)
        {
            NQueensProblem nQueensProblem = new NQueensProblem(size);
            nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
            // algorithms

            //nQueensProblem.SolvedProblemExample();
            //nQueensProblem.UnsolvedProblemExample();

            /* CUSTOM TESTING
            var testBoard = nQueensProblem.GetResultBoard().Board;
            testBoard[0, 0] = ChessPiece.Queen;
            testBoard[0, 3] = ChessPiece.Queen;
            testBoard[0, 2] = ChessPiece.Queen;
            testBoard[0, 3] = ChessPiece.Queen;
            */

            nQueensProblem.SetRandomBoardState();
            nQueensProblem.DoAlgorithm();

            // end algorithm
            var board = nQueensProblem.GetResultBoard();
            board.CheckIfProblemSolved();

            return View(board);
        }

        [HttpPost]
        public IActionResult ChangeBoardGameSize(IFormCollection formCollection)
        {
            int size = int.Parse(formCollection["SizeSelect"]);

            NQueensProblem nQueensProblem = new NQueensProblem(size);
            nQueensProblem.SetAlgorithm(new HillClimbingAlgorithm());
            // algorithms

            nQueensProblem.SetRandomBoardState();
            nQueensProblem.DoAlgorithm();

            // end algorithm
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
