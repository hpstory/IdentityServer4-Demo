using Microsoft.AspNetCore.Mvc;

namespace HybirdMvcClient.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
