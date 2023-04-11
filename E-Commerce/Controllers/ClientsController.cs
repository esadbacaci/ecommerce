using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ClientsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //rolü sadece client olanları getirmek için bunları kullandım
            var users = await _userManager.Users.ToListAsync();
            var clients = new List<AppUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Client"))
                {
                    clients.Add(user);
                }
            }

            return View(clients);
        }
    }
}
