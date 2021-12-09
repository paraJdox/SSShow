using Microsoft.AspNetCore.Mvc;

namespace SSShow.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SignUp()
        {
            return PartialView("_UserModalPartial");
        }
    }
}
