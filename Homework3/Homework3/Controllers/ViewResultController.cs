using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class ViewResultController : Controller
    {
        // GET: ViewResult
 

        public ViewResult ViewResult()
        {
            ViewBag.Name = "view result";

            return View();
        }

        public PartialViewResult Index()
        {
            return PartialView("Index");
        }
    }
}