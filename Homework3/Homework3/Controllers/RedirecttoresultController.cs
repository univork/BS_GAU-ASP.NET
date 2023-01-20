using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class RedirecttoresultController : Controller
    {
        // GET: Redirecttoresult
        public RedirectToRouteResult Index()
        {
            return RedirectToRoute(new { action = "Index", controller = "ViewResult", area = "" });
        }
    }
}