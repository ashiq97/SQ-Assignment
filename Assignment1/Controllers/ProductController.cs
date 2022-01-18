using Assignment1.Models;
using Assignment1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        ProductsService _productsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductList()
        {
           var productList =  _productsService.GetProducts();
           
           return PartialView("_ShowProductData", productList);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
               bool isAlreadyInDataBase =  _productsService.CheckProductDataIsAlreadyExistOrNot(product.ProductCode);
                
                if(isAlreadyInDataBase)
                    return Json(new { success = false, message = "This Prodct Code is Already in DataBase. Pleasy try another code" });
                
                _productsService.SaveProduct(product);
                return RedirectToAction("GetProductList");
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}