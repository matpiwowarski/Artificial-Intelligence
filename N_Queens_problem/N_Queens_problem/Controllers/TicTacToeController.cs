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
            TicTacToe ticTacToe = TicTacToe.Instance;
            TicTacToeBot bot = new TicTacToeBot(ticTacToe);
            TicTacToeUser user = new TicTacToeUser(ticTacToe);
            ticTacToe.SetWhoStarts(user);



            return View(ticTacToe);
        }

        [HttpPost]
        public IActionResult NextMove(IFormCollection formCollection)
        {
            TicTacToe ticTacToe = TicTacToe.Instance;
            TicTacToeBot bot = new TicTacToeBot(ticTacToe);
            TicTacToeUser user = new TicTacToeUser(ticTacToe);

            ticTacToe.Level = int.Parse(formCollection["Level"]);

            Random random = new Random();
            int x = random.Next(3);
            int y = random.Next(3);

            while(!bot.MakeMove(x, y))
            {
                x = random.Next(3);
                y = random.Next(3);
            }

            ticTacToe.BotWon();

            return View("Index", ticTacToe);
        }
    }
}
