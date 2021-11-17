using CustomerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApp.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Customer customer)
        {
            int response;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var customerjson = JsonConvert.SerializeObject(customer);
            HttpResponseMessage res = await client.PostAsync("api/Customer", new StringContent(customerjson,Encoding.UTF8, "application/json"));
            if (res.IsSuccessStatusCode)
            {
                var customerresponse = res.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<int>(customerresponse);
            }
            return RedirectToAction("CustomerList");
        }
        public async Task<IActionResult> CustomerList()
        {
            List<Customer> customers = new List<Customer>();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await client.GetAsync("api/Customer");
            if (res.IsSuccessStatusCode)
            {
                var customerresponse = res.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(customerresponse);
            }
            return View(customers);
        }
    }
}
