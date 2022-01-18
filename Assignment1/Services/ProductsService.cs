using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Services
{
    public class ProductsService
    {
        public List<Product> GetProducts()
        {
            using(var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using(var context = new ApplicationDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public bool CheckProductDataIsAlreadyExistOrNot(string productCode)
        {
            using (var context = new ApplicationDbContext())
            {
                var productItem = context.Products.FirstOrDefault(x=>x.ProductCode == productCode);
                if (productItem != null)
                    return true;
                return false;
            }
        }
    }
}