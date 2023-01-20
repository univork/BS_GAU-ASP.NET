using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class StatusCodeController : Controller
    {
        // GET: StatusCode
        public HttpStatusCodeResult Index()
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound, "Not Found");
        }
    }
}