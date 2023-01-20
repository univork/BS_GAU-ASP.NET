using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz1.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Smartphones
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetCategory(int id,string name="phone")
        {
            ViewBag.Message = id;
            ViewBag.name =name;
            return View();
        }
    }
}