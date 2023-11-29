using Microsoft.AspNetCore.Mvc;

namespace XFood.API.Controllers
{
    public class AccountContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
