using GameSpy.DTOs;
using GameSpy.Models;

namespace GameSpy.Service.GameS
{
    public interface IGameService
    {
        Task<Game> GetGameById(int id);
        Task<List<Game>> GetAllGames();
        Task<List<GameDTO>> GetUsersGames(string userId);

        Task<ICollection<Achievement>> GetUsersIngameAchievement(string userId, int id);
        Task UpdateGame(int id, Game newGame);
        Task DeleteGame(int id);
        Task AddGame(Game game);

        Task UpdateRecentTime(int id);
    }
}
