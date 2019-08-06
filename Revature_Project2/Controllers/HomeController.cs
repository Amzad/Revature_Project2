using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Revature_Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

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
        public IActionResult Menu()
        {
            //Test
            int custID = int.Parse(User.FindFirst("customerID").Value);
            Order orderList = CheckOutController.CustomerOrder.Find(c => c.CustomerID == custID);
            return View(orderList);
        }

        [Authorize]
        public IActionResult Payment()
        {
            return View();
        }

        public async Task<IActionResult> P1()
        {
            // Sample GET Request
            var request = new HttpRequestMessage(HttpMethod.Get,
                Program.API + "customers");
            // Must include these headers for GET
            //request.Headers.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            //request.Headers.Add("accept-encoding", "gzip, deflate");
            //request.Headers.Add("content-type", "application/json");
            //request.Headers.Add("user-agent",
            // "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var order = await response.Content.ReadAsAsync<IEnumerable<Customer>>();


                //System.Diagnostics.Debug.WriteLine(x.OrderDetailPrice);

                /* Branches = await response.Content
                     .ReadAsAsync<IEnumerable<Customer>>();*/
                return View(order);
            }
            else
            {
                //GetBranchesError = true;
                System.Diagnostics.Debug.WriteLine("DAMN");
                //Branches = Array.Empty<Customer>();
            }





            return View();
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            // Create fake order
            Order fakeOrder = new Order();
            fakeOrder.Pizzas = new List<Pizza>();
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
            fPizza.PizzaPrice = 90;
            fPizza.PizzaSize = "M";
            fPizza.PizzaCheese = false;
            fakeOrder.OrderPrice = 100;
            fakeOrder.Pizzas.Add(fPizza);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            string var2 = JsonConvert.SerializeObject(fakeOrder);
            var httpContent = new StringContent(var2, Encoding.UTF8, "application/json");
            string id = User.FindFirstValue("customerID");
            var response = await client.PutAsync(Program.API + "Orders/1", httpContent);


            if (response.IsSuccessStatusCode)
            {
                //Branches = await response.Content
                //    .ReadAsAsync<IEnumerable<Customer>>();
                return View();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DAMN"); ;
            }

            return View();

        }

    }
}
