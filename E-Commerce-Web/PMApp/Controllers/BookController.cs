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
        public async Task<ActionResult> Create(Book b, HttpPostedFileBase file)
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

                bool success = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync("/api/Book", b);

                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        success = JsonConvert.DeserializeObject<bool>(EmpResponse);
                    } 
                }
                if (success) return RedirectToAction("Index");
                else
                {
                    ViewBag.errorMessage = "This item (name) already exists !!";
                    return View(b);
                }
                
            } else return View(b);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            { 
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"/api/Book/{id}");

                Book b = null;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    b = JsonConvert.DeserializeObject<Book>(EmpResponse);
                }

                return View(b);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book b = this.repo.Get(id);
            return View(b);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Book b, HttpPostedFileBase file, string image)
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

                //if (this.repo.Update(b, warning)) return RedirectToAction("Index");

                bool success = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PutAsJsonAsync($"/api/Book?warning={warning}", b);

                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        success = JsonConvert.DeserializeObject<bool>(EmpResponse);
                    } 
                }
                if (success) return RedirectToAction("Index");
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
