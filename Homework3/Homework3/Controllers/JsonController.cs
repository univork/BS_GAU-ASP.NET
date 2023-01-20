using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Homework3.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public JsonResult Index()
        {
            return Json(
                new
                {
                    Name = "test",
                    mobile = "123123123",
                    age = "23"
                }, JsonRequestBehavior.AllowGet
                );
        }
    }
}