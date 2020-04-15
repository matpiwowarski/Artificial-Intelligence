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

            // setting level
            ticTacToe.Level = int.Parse(formCollection["Level"]);
            
            string place = formCollection["Button"];
            int userX = int.Parse(place[0].ToString());
            int userY = int.Parse(place[1].ToString());

            // user
            user.MakeMove(userX, userY);
            //
            ticTacToe.CheckGameStatus();

            if(ticTacToe.GameStatus == GameStatus.InProgress)
            {
                // bot
                MiniMax miniMax = new MiniMax(ticTacToe.ticTacToeBoard);
                Tuple<int, int> xy = miniMax.GetBotMove(ticTacToe.Level);
                bot.MakeMove(xy.Item1, xy.Item2);
                //
                ticTacToe.CheckGameStatus();

                if (ticTacToe.GameStatus != GameStatus.InProgress)
                {
                    ticTacToe.CheckGameStatusAndGivePoint();
                }
            }
            else
            {
                ticTacToe.CheckGameStatusAndGivePoint();
            }

            return View("Index", ticTacToe);
        }
    }
}
