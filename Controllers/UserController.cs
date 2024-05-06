using GameSpy.Models;
using GameSpy.Service.GameS;
using GameSpy.Service.UserS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net;
using AutoMapper;
using GameSpy.DTOs;

namespace GameSpy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserService userService, UserManager<AppUser> userManager, IGameService gameService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
            this._userManager = userManager;
            this._gameService = gameService;

        }
        [HttpGet]
        public async Task<IActionResult> UserPage()
        {
            var user = await _userManager.GetUserAsync(User);
            user.Games = await _gameService.GetUsersGames(user.Id);
            user.Achievements = await _userService.GetAchievements(user.Id);

            var modelUser = _mapper.Map<UserDTO>(user);
            modelUser.NumberOfGames = user.Games.Count();
            modelUser.NumberOfAchievements = user.Achievements.Count();
            return View(modelUser);
        }

        [HttpGet]
        public async Task<IActionResult> UserSettings(string id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> AddBalance(string id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBalance(string id, AppUser updatedUser)
        {
            await _userService.UpdateUser(id, updatedUser);
            return View("UserPage");
        }
    }
}
