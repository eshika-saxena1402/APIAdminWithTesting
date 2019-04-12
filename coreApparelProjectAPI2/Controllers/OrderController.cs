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
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/order").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<Order> data = JsonConvert.DeserializeObject<List<Order>>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(order);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/order", contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/order/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Order data = JsonConvert.DeserializeObject<Order>(stringData);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/order/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Order data = JsonConvert.DeserializeObject<Order>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(order);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("/api/order/" +order.OrderId, contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            HttpResponseMessage response = client.GetAsync("/api/order/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Order data = JsonConvert.DeserializeObject<Order>(stringData);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54638");
            string stringData = JsonConvert.SerializeObject(order);
            HttpResponseMessage response = client.DeleteAsync("/api/order/" + id).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}