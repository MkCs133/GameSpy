using GameSpy.Models;
using GameSpy.Service.GameS;
using GameSpy.Service.UserS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GameSpy.DTOs;
using Microsoft.AspNetCore.Http;

namespace GameSpy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHost;


        public UserController(IUserService userService, UserManager<AppUser> userManager, IGameService gameService, IMapper mapper, IWebHostEnvironment webHost)
        {
            this._mapper = mapper;
            this._userService = userService;
            this._userManager = userManager;
            this._gameService = gameService;
            this._webHost = webHost;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> UserPage()
        {
            
            var user = await _userManager.GetUserAsync(User);
 
            user.Achievements = await _userService.GetAchievements(user.Id);

            var modelUser = _mapper.Map<UserDTO>(user);
            modelUser.Games = await _gameService.GetUsersGames(user.Id);
            modelUser.NumberOfGames = modelUser.Games.Count();
            modelUser.NumberOfAchievements = user.Achievements.Count();

            

            foreach (GameDTO game in modelUser.Games)
            {
                modelUser.RecentGames.Add(game);
            }

            modelUser.RecentGames.Sort((x,y) => x.RecentTime.CompareTo(y.RecentTime));
            modelUser.RecentGames.Reverse();

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
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBalance(string id, AppUser viewModel)
        {
            var user = await _userService.GetUserById(id);
            user.Balance += viewModel.Balance;

            await _userService.UpdateUser(id, user);
            return RedirectToAction("UserPage");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUsername(string id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }
       
        [HttpPost]
        public async Task<IActionResult> UpdateUsername(string id, AppUser viewModel)
        {
            var user = await _userService.GetUserById(id);
            user.UserName = viewModel.UserName;
            await _userService.UpdateUser(id, user);

            return RedirectToAction("UserPage");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePassword(string id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(string id, AppUser viewModel)
        {
            var user = await _userService.GetUserById(id);
            user.PasswordHash = viewModel.PasswordHash;
            await _userService.UpdateUser(id, user);

            return RedirectToAction("UserPage");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmail(string id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmail(string id, AppUser viewModel)
        {
            var user = await _userService.GetUserById(id);
            user.Email = viewModel.Email;
            await _userService.UpdateUser(id, user);

            return RedirectToAction("UserPage");
        }

        [HttpPost]

        public async Task<IActionResult> ChangeUserImage(IFormFile file, string id)
        {

            var user = await _userService.GetUserById(id);
            string uploadFolder = Path.Combine(_webHost.WebRootPath, "assets/profilePictures");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string fileName = Path.GetFileName(file.FileName);
            string fileSaveFile = Path.Combine(uploadFolder, fileName);

            user.ProfilePicture = fileName;
            await _userService.UpdateUser(id, user);


            using (FileStream stream = new FileStream(fileSaveFile, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

                return RedirectToAction("UserPage");
        }

        [HttpGet]

        public IActionResult UserHelp()
        {
            return View();
        }


        [HttpGet]

        public IActionResult UserPrivacy()
        {
            return View();
        }
    }
}
