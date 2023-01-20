using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework2.Models;

namespace Homework2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Student student = new Student
            {
                FirstName = "mari",
                LastName = "sikharulidze",
                Email = "mari@gmail.com",
                Password = "pass"
            };

            return View(student);
        }
    }
}