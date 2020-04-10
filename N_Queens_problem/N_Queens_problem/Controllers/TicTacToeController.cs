using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtificialIntelligence.Models.TicTacToe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtificialIntelligence.Controllers
{
    public class TicTacToeController : Controller
    {
        public IActionResult Index()
        {
            TicTacToe ticTacToe = new TicTacToe(5);
            TicTacToeBot bot = new TicTacToeBot(ticTacToe);
            TicTacToeUser user = new TicTacToeUser(ticTacToe);
            ticTacToe.SetWhoStarts(user);



            return View(ticTacToe);
        }

        [HttpPost]
        public IActionResult NextMove(IFormCollection formCollection)
        {
            int level = int.Parse(formCollection["Level"]);

            TicTacToe ticTacToe = new TicTacToe(level);
            TicTacToeBot bot = new TicTacToeBot(ticTacToe);
            TicTacToeUser user = new TicTacToeUser(ticTacToe);
            ticTacToe.SetWhoStarts(user);

            bot.MakeMove(0, 0);

            ticTacToe.BotWon();

            return View("Index", ticTacToe);
        }
    }
}
