using Midterm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace Midterm.Controllers
{
    [RoutePrefix("Todo/{todoId:int}")]
    public class NoteController : Controller
    {
        [Route("Note/Create"), HttpPost]
        public ActionResult Create(int todoId, Note note)
        {
            using (TodoModel db = new TodoModel())
            {
                note.TodoId = todoId;
                db.Notes.Add(note);
                db.SaveChanges();
            }
            return Json(note);
        }

        [Route("Note/Delete"), HttpDelete]
        public ActionResult Delete(int todoId,  int id)
        {
            using (TodoModel db = new TodoModel())
            {
                Note note = db.Notes.FirstOrDefault(n => n.Id == id);
                if (note == null | note.TodoId != todoId)
                {
                    return HttpNotFound("Todo not found");
                }
                db.Notes.Remove(note);
                db.SaveChanges();
            }
            Response.StatusCode = 200;
            return Json(new { Status = "ok" });

        }
    }
}