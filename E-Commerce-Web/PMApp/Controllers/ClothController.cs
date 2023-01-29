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
    public class ClothController : BaseController
    {
        private ClothRepository repo = new ClothRepository();
        string baseUrl = "https://localhost:44393";

        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            { 
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Cloth");
                List<Cloth> clothes = new List<Cloth>();

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    clothes = JsonConvert.DeserializeObject<List<Cloth>>(EmpResponse);
                }

                return View(clothes);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cloth c, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
                    file.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "/uploads/" + newpath;
                    c.ImagePath = imagepath;
                }
                else
                {
                    c.ImagePath = null;
                }

                bool success = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync("/api/Cloth", c);

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
                    return View(c);
                }

            }
            else
            {
                return View(c);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            { 
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"/api/Cloth/{id}");

                Cloth c = null;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    c = JsonConvert.DeserializeObject<Cloth>(EmpResponse);
                }

                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cloth c = this.repo.Get(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Cloth c, HttpPostedFileBase file, string image)
        {
            bool warning = false;

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
                    file.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "/uploads/" + newpath;
                    c.ImagePath = imagepath;
                }
                else
                {
                    warning = true;
                }

                //query
                if (this.repo.Update(c, warning)) //positive result
                {
                    return RedirectToAction("Index");
                }
                else //negative result
                {
                    ViewBag.errorMessage = "This item (name) already exists !!";
                    c.ImagePath = image;
                    return View(c);
                }

            }
            else
            {
                c.ImagePath = image;
                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Cloth c = this.repo.Get(id);
            return View(c);
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
    }
}
