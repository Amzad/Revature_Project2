using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revature_Project2.Data;
using Revature_Project2.Models;

namespace Revature_Project2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _db;
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<Customer> Branches { get; private set; }
        /*public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }*/

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            //Test
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            /* _db.Orders.Add(
                 new Order()
                 {
                     CustomerID = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                     OrderDateTime = DateTime.Now,
                     OrderPrice = 10
                 }); 
             _db.SaveChanges();*/

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/customers");
            //request.Headers.Add("Accept", "application/json");
            request.Headers.Add("accept-encoding", "gzip, deflate");
            request.Headers.Add("authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRhdGEiLCJzdWIiOiJkYXRhIiwianRpIjoiZTc4Y2I5YTEtNzRjNC00M2EwLWE2YzAtYjYzZGMzN2YyMzBkIiwiZXhwIjoxNTYzNTYwMTE4LCJpc3MiOiJtZSIsImF1ZCI6InlvdSJ9.DnSVJxJbGJdLlxqvTfSjXMIw3kdVYnSBqVmzgcxfKoU");
            //request.Headers.Add("content-type", "application/json");
            request.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Branches = await response.Content
                    .ReadAsAsync<IEnumerable<Customer>>();
                return View(Branches);
            }
            else
            {
                //GetBranchesError = true;
                System.Diagnostics.Debug.WriteLine("DAMN");
                Branches = Array.Empty<Customer>();
            }
            //Null

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
