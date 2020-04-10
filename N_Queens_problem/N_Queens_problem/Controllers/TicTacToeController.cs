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

            ticTacToe.ClearBoard();
            ticTacToe.IsFinsihed = false;

            TicTacToeBot bot = TicTacToeBot.Instance;
            TicTacToeUser user = TicTacToeUser.Instance;
            bot.SetTicTacToe(ticTacToe);
            user.SetTicTacToe(ticTacToe);

            // switch starting
            if(ticTacToe.IsPlayerStarting == true)
            {
                ticTacToe.IsPlayerStarting = false;
                // bot first move
                Random random = new Random();
                int x = random.Next(3);
                int y = random.Next(3);

                while (!bot.MakeMove(x, y))
                {
                    x = random.Next(3);
                    y = random.Next(3);
                }
            }
            else
            {
                ticTacToe.IsPlayerStarting = true;
            }

            return View(ticTacToe);
        }

        [HttpPost]
        public IActionResult NextMove(IFormCollection formCollection)
        {
            TicTacToe ticTacToe = TicTacToe.Instance;
            TicTacToeBot bot = TicTacToeBot.Instance;
            TicTacToeUser user = TicTacToeUser.Instance;

            ticTacToe.Level = int.Parse(formCollection["Level"]);
            string place = formCollection["Button"];
            int userX = int.Parse(place[0].ToString());
            int userY = int.Parse(place[1].ToString());

            // user
            user.MakeMove(userX, userY);
            if (ticTacToe.CheckIfSymbolWon(user.Symbol))
            {
                ticTacToe.IsFinsihed = true;
                ticTacToe.UserScore++;
            }
            else
            {
                // bot
                Random random = new Random();
                int x = random.Next(3);
                int y = random.Next(3);

                while (!bot.MakeMove(x, y))
                {
                    x = random.Next(3);
                    y = random.Next(3);
                }

                if (ticTacToe.CheckIfSymbolWon(bot.Symbol))
                {
                    ticTacToe.IsFinsihed = true;
                    ticTacToe.BotScore++;
                }
                else
                {
                    ticTacToe.CheckIfFinished();
                    if (ticTacToe.IsFinsihed)
                        ticTacToe.TieScore++;
                }
            }

            return View("Index", ticTacToe);
        }
    }
}
