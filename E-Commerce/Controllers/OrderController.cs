using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace E_Commerce.Controllers
{
    public class OrderController : Controller
    {		
        
        Context c = new Context();
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            return View();
        }


        //[AllowAnonymous]

        //public IActionResult Cart()
        //{
        //    var usermail = User.Identity.Name;
        //    var clientid = c.Users.Where(x => x.UserName == usermail).Select(y => y.Id).FirstOrDefault();
        //    var values = pm.GetProductListWithByClient(clientid);
        //    return View(values);
        //}
        
        //[HttpGet]
        //public IActionResult AddProduct()
        //{
        //    return View();
        //}

        //[HttpPost] 
        //public IActionResult AddProduct(Product p)
        //{
         
        //    var username = User.Identity.Name;
        //    var clientid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();

        //    p.ProductStatus = true;
        //    pm.TAdd(p);
        //    return RedirectToAction("Shop", "Home");

        //}
    }
}
