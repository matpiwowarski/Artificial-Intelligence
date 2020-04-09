using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtificialIntelligence.Models.TicTacToe;
using Microsoft.AspNetCore.Mvc;

namespace ArtificialIntelligence.Controllers
{
    public class TicTacToeController : Controller
    {
        public IActionResult Index()
        {
            TicTacToe ticTacToe = new TicTacToe();
            TicTacToeBot bot = new TicTacToeBot(ticTacToe);
            TicTacToeUser user = new TicTacToeUser(ticTacToe);
            ticTacToe.SetWhoStarts(user);


            ticTacToe.PutCircle(1, 2);
            ticTacToe.PutCross(2, 0);

            return View(ticTacToe);
        }
    }
}
