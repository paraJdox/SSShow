using Microsoft.AspNetCore.Mvc;

namespace SSShow.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            ViewData["Message"] = "Sign Up";
            return PartialView("_UserModalPartial");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            ViewData["Message"] = "Sign In";
            return PartialView("_UserModalPartial");
        }
    }
}
