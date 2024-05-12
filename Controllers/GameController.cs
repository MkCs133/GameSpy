using GameSpy.Models;
using GameSpy.Service.GameS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameSpy.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly UserManager<AppUser> _userManager;

        public GameController(IGameService gameService, UserManager<AppUser> userManager)
        {
            this._gameService = gameService;
            this._userManager = userManager;    
        }

        [HttpGet]
        public async Task<List<Game>> GetAllGames()
        {
            var games = await _gameService.GetAllGames();
            Console.WriteLine(games);
            return games;
        }

        [HttpGet]
        public async Task<IActionResult> SelectedGame(int id)
        {
            var userID = _userManager.GetUserId(User);
            var game = await _gameService.GetGameById(id);

            game.Achievements = await _gameService.GetUsersIngameAchievement(userID, id);

            await _gameService.UpdateRecentTime(id);


            return View(game);
        }
    }
}
