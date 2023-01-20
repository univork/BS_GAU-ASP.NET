using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework3.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public FileResult Index()
        {
            byte[] file = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/file.txt"));
            return File(file, "txt/plain");

        }
    }
}