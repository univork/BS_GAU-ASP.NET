using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMEntity;
using PMRepository;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PMApp.Controllers
{
    public class BookController : BaseController
    {
        private BookRepository repo = new BookRepository();
        private UserRepository userRepo = new UserRepository();
        string baseUrl = "https://localhost:44393";

        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            { 
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Book");
                List<Book> books = new List<Book>();

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<List<Book>>(EmpResponse);
                }

                return View(books);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book b, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0) {
                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
                    file.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "/uploads/" + newpath;
                    b.ImagePath = imagepath;
                } else b.ImagePath = null;

                if (this.repo.Insert(b)) return RedirectToAction("Index");
                else
                {
                    ViewBag.errorMessage = "This item (name) already exists !!";
                    return View(b);
                }
                
            } else return View(b);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Book b = this.repo.Get(id);
            return View(b);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(Book b, HttpPostedFileBase file, string image)
        {
            bool warning = false;

            if (ModelState.IsValid) {
                if (file != null && file.ContentLength > 0) {
                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
                    file.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "/uploads/" + newpath;
                    b.ImagePath = imagepath;
                } else warning = true;

                if (this.repo.Update(b, warning)) return RedirectToAction("Index");
                else {
                    ViewBag.errorMessage = "This item (name) already exists !!";
                    b.ImagePath = image;
                    return View(b);
                }
                
            } else {
                b.ImagePath = image;
                return View(b);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Logout(string logout)
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult TopUser()
        {
            return View(this.userRepo.ReturnTopUsers());
        }

        [HttpPost]
        public ActionResult ViewUserTransaction()
        {
            return View(this.userRepo.ReturnUserTransaction());
        }
    }
}
