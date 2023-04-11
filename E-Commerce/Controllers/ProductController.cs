using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var values = pm.GetList();
            return View(values);

        }
        [HttpGet]
        public IActionResult AddProduct()
        {
			List<SelectListItem> categoryvalues = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
			ViewBag.cv = categoryvalues;
			return View();
		}
        
        [HttpPost]
        public IActionResult AddProduct(Product p ,IFormFile ProductImage) 
        {
			if (ProductImage != null && ProductImage.Length > 0)
			{
				// dosya adı ve uzantısı
				var fileName = Path.GetFileName(ProductImage.FileName);
				var fileExtension = Path.GetExtension(fileName);

				// dosya adı değiştirme
				var newFileName = Guid.NewGuid() + fileExtension;

				// dosya kaydedilme yolu
				var location = Directory.GetCurrentDirectory();
				var path = Path.Combine(location, "wwwroot/productimages/", newFileName);

				// dosyayı kaydetme
				using (var stream = new FileStream(path, FileMode.Create))
				{
					ProductImage.CopyTo(stream);
				}

				// veritabanına kaydetme
				p.ProductImage = "/productimages/" + newFileName;
			}

            p.ProductStatus = true;
			p.ProductCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());

			pm.TAdd(p);
			return RedirectToAction("Index","Product"); 
        }

		public IActionResult DeleteProduct(int id)
		{
			var productvalue = pm.TGetById(id);
			pm.TDelete(productvalue);
			return RedirectToAction("Index");
		}

    }
}
