using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using coreApparelProjectAPI2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace coreApparelProjectAPI2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/category").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Category> data = JsonConvert.DeserializeObject<List<Category>>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(category);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/category", contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/category/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Category data = JsonConvert.DeserializeObject<Category>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/category/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Category data = JsonConvert.DeserializeObject<Category>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(category);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("/api/category/" + category.CategoryId, contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/category/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Category data = JsonConvert.DeserializeObject<Category>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(category);
            HttpResponseMessage response = client.DeleteAsync("/api/category/" + id).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

    }
}