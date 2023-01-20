using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult GetUserName(int name = 0)
        {
            ViewBag.Message = name;
            return View();
        }
    }
}