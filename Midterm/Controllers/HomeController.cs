using Midterm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Midterm.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (TodoModel db = new TodoModel())
            {
                List<Todo> todos = db.Todoes.ToList();
                ViewBag.Todos = todos;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            using (TodoModel db = new TodoModel())
            {
                //db.Configuration.LazyLoadingEnabled = false;

                Todo todo = db.Todoes.FirstOrDefault(t => t.Id == id);
                if (todo == null) {
                    return RedirectToRoute("404-PageNotFound");
                }
                ViewBag.Todo = todo;
                ViewBag.Notes = todo.Notes.ToList();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            using (TodoModel db = new TodoModel())
            {
                db.Todoes.Add(todo);
                db.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (TodoModel db = new TodoModel())
            {
                Todo todo = db.Todoes.FirstOrDefault(t => t.Id == id);
                db.Todoes.Remove(todo);
                db.SaveChanges();
            }
            return Json(new { Status = "ok" });
        }
    }
}