using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Revature_Project2.Data;
using Revature_Project2.Models;

namespace Revature_Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<Customer> Branches { get; private set; }

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            //Test
            return View();
        }

        public IActionResult Menu()
        {
            //Test
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            // Create fake order
            Order fakeOrder = new Order();
            fakeOrder.PizzaDetails = new List<PizzaDetail>();
            PizzaDetail fDetail = new PizzaDetail();
            fDetail.Pizzas = new List<Pizza>();
            Pizza fPizza = new Pizza();
            List<Topping> fTopping = new List<Topping>
            {
                new Topping() { ToppingName = "Harry", ToppingPrice = 15 },
                new Topping() { ToppingName = "Potter", ToppingPrice = 25 },
                new Topping() { ToppingName = "Ron", ToppingPrice = 30 }
            };
            fPizza.Toppings = fTopping;
            fPizza.PizzaBread = "Cheesy";
            fPizza.PizzaSauce = "BBQ";
            fDetail.OrderDetailPrice = 90;
            fDetail.Pizzas.Add(fPizza);
            fakeOrder.PizzaDetails.Add(fDetail);
            fakeOrder.CustomerID = User.FindFirstValue("customerID");



            // Sample POST Requestion
            
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            string var2 = JsonConvert.SerializeObject(fakeOrder);
            var httpContent = new StringContent(var2, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44376/api/Orders", httpContent);


            if (response.IsSuccessStatusCode)
            {
                //Branches = await response.Content
                //    .ReadAsAsync<IEnumerable<Customer>>();
                return View();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DAMN");;
            }




            // Sample GET Request
            /*var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/customers");
                // Must include these headers for GET
            request.Headers.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            request.Headers.Add("accept-encoding", "gzip, deflate");
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
            //Null*/

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
