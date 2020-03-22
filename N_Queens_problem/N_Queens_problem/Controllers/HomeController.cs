using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N_Queens_problem.Models;

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

            // algorithms

            // end algorithm
            var board = nQueensProblem.GetResultBoard();
            board.CheckIfProblemSolved();

            return View(board);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
