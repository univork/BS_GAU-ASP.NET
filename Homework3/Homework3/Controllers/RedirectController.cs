using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Redirect
        public RedirectResult Index()
        {
            return Redirect("https://www.w3schools.com/");
        }
    }
}