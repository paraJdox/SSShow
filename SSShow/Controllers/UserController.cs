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
    }
}
