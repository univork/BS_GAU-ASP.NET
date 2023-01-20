using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Computers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProduct(int id)
        {
            ViewBag.Message = id;
            return View();
        }
    }
}