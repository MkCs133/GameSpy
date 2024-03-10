﻿using GameSpy.Models;

namespace GameSpy.Service.GameS
{
    public interface IGameService
    {
        Task<Game> GetGameById(int id);
        Task<List<Game>> GetAllGames();
        Task UpdateGame(int id, Game newGame);
        Task DeleteGame(int id);
        Task AddGame(Game game);
    }
}