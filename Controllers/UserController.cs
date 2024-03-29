using GameSpy.Models;
using GameSpy.Service.GameS;
using GameSpy.Service.UserS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net;

namespace GameSpy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGameService _gameService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserService userService, UserManager<AppUser> userManager, IGameService gameService)
        {
            this._userService = userService;
            this._userManager = userManager;
            this._gameService = gameService;

            ServicePointManager.Ti
        }
        [HttpGet]
        public async Task<IActionResult> UserPageAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            user.Games = await _gameService.GetUsersGames(user.Id);
            return View(user);
        }

        [HttpGet]
        public IActionResult UserSettings() 
        {
            return View();
        }
    }
}
