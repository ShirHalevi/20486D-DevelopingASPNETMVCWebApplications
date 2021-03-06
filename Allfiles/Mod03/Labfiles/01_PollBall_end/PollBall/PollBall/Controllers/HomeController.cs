﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollBall.Services;
using System.Text;

namespace PollBall.Controllers
{
    public class HomeController : Controller
    {
        IPollResultsService _pollResults;

        public HomeController(IPollResultsService pollResults)
        {
            _pollResults = pollResults;
        }

        public IActionResult Index()
        {
            StringBuilder results = new StringBuilder();
            SortedDictionary<SelectedGame, int> voteLista = _pollResults.GetVoteResult();

            foreach (var gameVotes in voteLista)
            {
                results.Append($"Game name: {gameVotes.Key}, Votes: {gameVotes.Value}{Environment.NewLine}");
            }

            return Content(results.ToString());
        }
    }
}
