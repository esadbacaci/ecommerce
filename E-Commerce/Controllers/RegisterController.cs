using E_Commerce.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace E_Commerce.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult>Index(UserSignUpViewModel p)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                   
                    Email = p.Mail,
                    UserName=p.UserName,
                    NameSurname = p.NameSurname


                };
                var result=await _userManager.CreateAsync(user,p.Password);
                await _userManager.AddToRoleAsync(user, "Admin");
                if (result.Succeeded)
                {
                   // await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult>UserRegister(UserSignUpViewModel p)
		{
			if (ModelState.IsValid)
			{
				AppUser user = new AppUser()
				{
					Email = p.Mail,
					UserName = p.UserName,
					PhoneNumber = p.PhoneNumber,
					NameSurname = p.NameSurname
				};

				var result = await _userManager.CreateAsync(user, p.Password);
                await _userManager.AddToRoleAsync(user, "Client");
                if (result.Succeeded)
				{				
						return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(p);
		}
	}
}
