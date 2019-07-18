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
        public IEnumerable<GitHubBranch> Branches { get; private set; }
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
                "https://api.github.com/repos/Amzad/Revature_Project2/branches");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Branches = await response.Content
                    .ReadAsAsync<IEnumerable<GitHubBranch>>();
                foreach (var b in Branches)
                {
                    System.Diagnostics.Debug.WriteLine(b.Name);
                }
            }
            else
            {
                //GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
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
