using GameSpy.Models;
using GameSpy.Service.UserS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameSpy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserService service, UserManager<AppUser> userManager)
        {
            this._service = service;
            this._userManager = userManager;
        }
        public async Task<IActionResult> UserPageAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}
