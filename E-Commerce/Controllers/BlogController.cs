﻿using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult AddBlog() 
        {
            return View();  
        }
    }
}
