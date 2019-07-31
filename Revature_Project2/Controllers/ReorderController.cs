using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Revature_Project2.Controllers
{
    [Authorize]
    public class ReorderController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public ReorderController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        // GET: Reorder
        public async Task<IActionResult> Index()
        {
            // Sample GET Request
            //var usersessionid = _userManager.GetUserId();
            int id = Convert.ToInt32(User.FindFirstValue("customerID"));
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/reorders/" + id);
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
                System.Diagnostics.Debug.WriteLine(response.Content);
                var orders = await response.Content
                    .ReadAsAsync<IEnumerable<Order>>();
                return View(orders);
            }
            else
            {
                //GetBranchesError = true;
                System.Diagnostics.Debug.WriteLine("you didn't order anythin");
                return View();
                //Branches = Array.Empty<Customer>();
            }

        }

        // GET: Reorder/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //this controller should go to reorder/detail and fetech order with the same id
            // Sample GET Request
            //var usersessionid = _userManager.GetUserId();
            //int id = Convert.ToInt32(User.FindFirstValue("customerID"));
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/reorders/Detail/" + id);
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
                System.Diagnostics.Debug.WriteLine(response.Content);
                var orders = await response.Content.ReadAsAsync<Order>();
                return View(orders);
            }
            else
            {
                //GetBranchesError = true;
                System.Diagnostics.Debug.WriteLine("you didn't order anythin");
                return View();
                //Branches = Array.Empty<Customer>();
            }
        }

            //not working error think it cuz i have the drink id and pizza id already need to remove them...
        public async Task<ActionResult> Reorder(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/reorders/Detail/" + id);
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
                //System.Diagnostics.Debug.WriteLine(response.Content);
                var item = await response.Content
                    .ReadAsAsync<Order>();
                //inporgress ask amzad for the nonlazzy loading 
                if (item.Pizzas != null)
                {
                    foreach (var x in item.Pizzas)
                    {
                        x.OrderID = 0;
                        x.PizzaID = 0;
                        //Pizz.PizzaBrsead = x.PizzaBread;
                        //Pizz.PizzaCheese = x.PizzaCheese;
                        //Pizz.PizzaSauce = x.PizzaSauce;
                        //var Top = new List<Topping>();

                        AddToList(x);
                    }
                }
                if (item.Drinks != null)
                {
                    foreach (var y in item.Drinks)
                    {
                        y.DrinkID = 0;
                        y.OrderID = 0; 
                        AddDrink(y);
                    }
                }
            }
            return RedirectToAction("Menu", "Home");
        }

        public async Task<ActionResult> AddComponentPizza( int OrderID, int PizzaID)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/reorders/Detail/" + OrderID);
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
                //System.Diagnostics.Debug.WriteLine(response.Content);
                var item = await response.Content
                    .ReadAsAsync<Order>();
                //inporgress ask amzad for the nonlazzy loading 
                if (item.Pizzas != null)
                {
                    foreach (var x in item.Pizzas)
                    {
                        if(x.PizzaID == PizzaID)
                        {
                            x.OrderID = 0;
                            x.PizzaID = 0;
                            AddToList(x);
                        }
                    }
                }
            }
            return RedirectToAction("Menu", "Home");
        }
        public async Task<ActionResult> AddComponentDrink(int OrderID, int DrinkID)
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
               "https://localhost:44376/api/reorders/Detail/" + OrderID);
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
                //System.Diagnostics.Debug.WriteLine(response.Content);
                var item = await response.Content
                    .ReadAsAsync<Order>();
                //inporgress ask amzad for the nonlazzy loading 
                if (item.Drinks != null)
                {
                    foreach (var x in item.Drinks)
                    {
                        if (x.DrinkID == DrinkID)
                        {
                            x.OrderID = 0;
                            x.DrinkID = 0;
                            AddDrink(x);
                        }
                    }
                }
            }
            return RedirectToAction("Menu","Home");

        }

        [Authorize]
        public void AddToList(Pizza Item)
        {
            int custID = int.Parse(User.FindFirst("customerID").Value);
            bool hasCust = CheckOutController.CustomerOrder.Exists(c => c.CustomerID == custID);
            if (hasCust)
            {
                Order order = CheckOutController.CustomerOrder.Find(c => c.CustomerID == custID);
                order.Pizzas.Add(Item);
                order.OrderPrice += Item.PizzaPrice;

            }
            else
            {
                Order order = new Order()
                {
                    CustomerID = int.Parse(User.FindFirst("customerID").Value)
                };
                order.Pizzas = new List<Pizza>();
                order.Drinks = new List<Drink>();
                order.Pizzas.Add(Item);
                order.OrderPrice = Item.PizzaPrice;
                CheckOutController.CustomerOrder.Add(order);
            }

        }

        public void AddDrink(Drink Item)
        {


            int custID = int.Parse(User.FindFirst("customerID").Value);
            bool hasCust = CheckOutController.CustomerOrder.Exists(c => c.CustomerID == custID);
            if (hasCust)
            {
                Order order = CheckOutController.CustomerOrder.Find(c => c.CustomerID == custID);
                order.Drinks.Add(Item);
                order.OrderPrice += Item.Price;
            }
            else
            {
                Order order = new Order()
                {
                    CustomerID = int.Parse(User.FindFirst("customerID").Value)
                };
                order.Pizzas = new List<Pizza>();
                order.Drinks = new List<Drink>();
                order.Drinks.Add(Item);
                order.OrderPrice = Item.Price;
                CheckOutController.CustomerOrder.Add(order);
            }

        }

        // POST: Reorder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reorder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reorder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reorder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reorder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}