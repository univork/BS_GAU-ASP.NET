using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class EmptyController : Controller
    {
        // GET: Empty
        public EmptyResult Index()
        {
            return new EmptyResult();
        }
    }
}