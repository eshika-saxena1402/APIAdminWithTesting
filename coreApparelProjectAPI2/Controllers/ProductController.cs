using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using coreApparelProjectAPI2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace coreApparelProjectAPI2.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/product").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Product> data = JsonConvert.DeserializeObject<List<Product>>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.category = new SelectList(context.Categories, "CategoryId", "CategoryName");
            //ViewBag.vendor = new SelectList(context.Vendors, "VendorId", "VendorName");
            //ViewBag.brand = new SelectList(context.Brands, "BrandId", "BrandName");
            return View();
          
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/product", contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/product/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Product data = JsonConvert.DeserializeObject<Product>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/product/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Product data = JsonConvert.DeserializeObject<Product>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("/api/product/" + product.ProductId, contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/product/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Product data = JsonConvert.DeserializeObject<Product>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(product);
            HttpResponseMessage response = client.DeleteAsync("/api/product/" + id).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}