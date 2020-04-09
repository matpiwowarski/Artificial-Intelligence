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
            TicTacToeBot bot = new TicTacToeBot(ticTacToe, 5);
            TicTacToeUser user = new TicTacToeUser(ticTacToe);
            ticTacToe.SetWhoStarts(user);

            user.MakeMove(2, 2);
            bot.MakeMove(1, 2);

            ticTacToe.BotWon();

            return View(ticTacToe);
        }
    }
}
