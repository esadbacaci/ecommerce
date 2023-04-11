using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
	
	[AllowAnonymous]
	public class HomeController : Controller
	{
		ProductManager pm = new ProductManager(new EfProductRepository());
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

        public IActionResult Index()
        {
            var values = pm.GetList().Take(8).ToList();
            return View(values);
        }


        public IActionResult Shop()
		{
            var values = pm.GetProductListWithCategory();//getproductlistwithcategory gelecek 
            var category = cm.GetList();
            var model2 = new EntityLayer.Concrete.Category();
            var viewModel = new ProductViewModel
			{
                Products = values,
                Category = model2,
                Categories = category
            };

            return View(viewModel);
        }




        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
       
    }
}