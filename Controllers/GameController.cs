﻿using GameSpy.Models;
using GameSpy.Service.GameS;
using Microsoft.AspNetCore.Mvc;

namespace GameSpy.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }

        [HttpGet]
        public async Task<List<Game>> GetAllGames()
        {
            var games = await _gameService.GetAllGames();
            Console.WriteLine(games);
            return games;
        }
    }
}
