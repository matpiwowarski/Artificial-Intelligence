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

        public IActionResult LocalSearchAlgorithms()
        {
            NQueensProblem nQueensProblem = new NQueensProblem();

            // TEST
            nQueensProblem.GetResultBoard().Board[0, 1] = ChessPiece.Queen; // BOARD [ ROW , COLUMN]
            nQueensProblem.GetResultBoard().Board[1, 3] = ChessPiece.Queen; // BOARD [ ROW , COLUMN]
            //

            ViewBag.ChessBoard = nQueensProblem.GetResultBoard();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
