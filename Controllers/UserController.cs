using Microsoft.AspNetCore.Mvc;

namespace GameSpy.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserPage()
        {
            return View();
        }
    }
}
