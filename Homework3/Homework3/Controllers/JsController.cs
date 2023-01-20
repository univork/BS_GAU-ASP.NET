using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class JsController : Controller
    {
        // GET: Js
        public JavaScriptResult Index()
        {
            return JavaScript("alert('This is  JS')");
        }
    }
}