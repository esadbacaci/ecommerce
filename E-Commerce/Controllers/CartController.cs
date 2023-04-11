
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using E_Commerce.Models;
using MessagePack.Resolvers;

namespace E_Commerce.Controllers
{
	public class CartController : Controller
	{
		Context c = new Context();
		public IActionResult Index()
		{
			var model = GetCart(HttpContext);
			// olabil
            return View(model);
		}
	public IActionResult AddToCart(int Id)
{
    var product = c.Products.FirstOrDefault(i => i.ProductID == Id);
    if (product != null)
    {
        GetCart(HttpContext).AddProduct(product, 1);
    }
    return RedirectToAction("Index");
}
// 
		public IActionResult DeleteFromCart(int Id)
		{
			var product = c.Products.FirstOrDefault(i => i.ProductID == Id);
			if (product != null)
			{
				GetCart(HttpContext).DeleteProduct(product);
			}
			return RedirectToAction("Index");
		}


		public Cart GetCart(HttpContext httpContext)
		{
			var cart = httpContext.Session.GetString("Cart");
			if (cart == null)
			{
				cart = JsonSerializer.Serialize(new Cart());
				httpContext.Session.SetString("Cart", cart);
			}

			return JsonSerializer.Deserialize<Cart>(cart);
		}
      
		//knk projen core 6 da mı  kaydediypm böyle silcem zaten dimi ay
    }
}
