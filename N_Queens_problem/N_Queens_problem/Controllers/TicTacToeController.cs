using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtificialIntelligence.Models.TicTacToe;
using ArtificialIntelligence.Models.TicTacToe.Algorithm;
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
                AlphaBetaPruning alphaBetaPruning = new AlphaBetaPruning(ticTacToe.ticTacToeBoard, ticTacToe.Level);
                Tuple<int, int> xy = alphaBetaPruning.BestMove();
                bot.MakeMove(xy.Item1, xy.Item2);
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
            TicTacToeChecker ticTacToeChecker = new TicTacToeChecker();
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
            ticTacToeChecker.CheckGameStatus(ticTacToe);

            if(ticTacToe.GameStatus == GameStatus.InProgress)
            {
                // bot
                AlphaBetaPruning alphaBetaPruning = new AlphaBetaPruning(ticTacToe.ticTacToeBoard, ticTacToe.Level);
                Tuple<int, int> xy = alphaBetaPruning.BestMove();
                bot.MakeMove(xy.Item1, xy.Item2);
                //
                ticTacToeChecker.CheckGameStatus(ticTacToe);

                if (ticTacToe.GameStatus != GameStatus.InProgress)
                {
                    ticTacToeChecker.CheckGameStatusAndGivePoint(ticTacToe);
                }
            }
            else
            {
                ticTacToeChecker.CheckGameStatusAndGivePoint(ticTacToe);
            }

            return View("Index", ticTacToe);
        }
    }
}
