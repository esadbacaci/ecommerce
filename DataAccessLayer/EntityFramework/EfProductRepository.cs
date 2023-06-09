﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository :GenericRepository<Product>,IProductDal
    {
        public List<Product> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).ToList();
            }

        }
        public List<Product> GetListWithByClient(int id)
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).Where(x => x.ProductID == id).ToList();
            }
        }

     
    }
}
