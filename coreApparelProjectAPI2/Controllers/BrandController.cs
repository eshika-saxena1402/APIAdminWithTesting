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
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/brand").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Brand> data = JsonConvert.DeserializeObject<List<Brand>>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(brand);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/brand", contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/brand/"+id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Brand data = JsonConvert.DeserializeObject<Brand>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/brand/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Brand data = JsonConvert.DeserializeObject<Brand>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(brand);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("/api/brand/" + brand.BrandId, contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/brand/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Brand data = JsonConvert.DeserializeObject<Brand>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id,Brand brand)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(brand);
            HttpResponseMessage response = client.DeleteAsync("/api/brand/" + id).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}