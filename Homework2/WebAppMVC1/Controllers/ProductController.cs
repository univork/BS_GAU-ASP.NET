using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework2.Models;

namespace Homework2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //[Route("Product/{action}/{id}/{releaseYear:(\\d{4}):range(2020,2022)}")]
        public ActionResult Product(int id = 0, int releaseYear = 0)
        {
            ViewBag.Message = "Product ID : " + id + "," + "Release Year : " + releaseYear;
            return View();
        }
        public ActionResult GetProduct(int id)
        {
            ViewBag.Message = "Get Product  ";
            return View();
        }

        //New
        public ActionResult GetProductTable()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Laptop",
                IsAvailable = true,
                TotalAmount = 15,
                EachPrice = 4000.00,
            };

            return View(product);
        }

    }
}