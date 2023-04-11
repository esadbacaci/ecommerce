using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
