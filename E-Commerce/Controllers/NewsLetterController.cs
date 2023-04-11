using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class NewsLetterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
