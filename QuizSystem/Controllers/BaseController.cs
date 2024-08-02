using Microsoft.AspNetCore.Mvc;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("Username"));
        }

        protected int GetLoggedInUserId()
        {
            return int.Parse(HttpContext.Session.GetString("UserId"));
        }

        protected string GetLoggedInUsername()
        {
            return HttpContext.Session.GetString("Username");
        }

        protected string GetLoggedInUserRole()
        {
            return HttpContext.Session.GetString("Role");
        }
    }
}
