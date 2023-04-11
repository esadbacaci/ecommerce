using E_Commerce.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                                                                                   //cookie hatırla ve 5 kez yanlışta ban
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
            
        }

		[HttpGet]
		public IActionResult UserLogin()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserSignInViewModel p)
		{
			if (ModelState.IsValid)
			{
				//cookie hatırla ve 5 kez yanlışta ban
				var result = await _signInManager.PasswordSignInAsync(p.username, p.password, true, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					TempData["ErrorMessage"] = "Kullanıcı adı veya şifre yanlış";
					return RedirectToAction("UserLogin", "Login");
				}
			}
			return View();

		}
		public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public  IActionResult AccessDenied()
        {
            return View();  
        }

    }
}
