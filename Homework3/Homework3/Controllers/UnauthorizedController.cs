using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class UnauthorizedController : Controller
    {
        // GET: Unauthorized
        public HttpStatusCodeResult Index()
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");

        }
    }
}