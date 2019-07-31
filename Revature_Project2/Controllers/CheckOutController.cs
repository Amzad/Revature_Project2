using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Revature_Project2.Controllers
{
    public class CheckOutController : Controller
    {
        public static List<Order> CustomerOrder = new List<Order>();
        private readonly IHttpClientFactory _clientFactory;

        public CheckOutController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Authorize]
        public void AddToList(Pizza Item)
        {
            int custID = int.Parse(User.FindFirst("customerID").Value);
            bool hasCust = CustomerOrder.Exists(c => c.CustomerID == custID);
            if (hasCust)
            {
                Order order = CustomerOrder.Find(c => c.CustomerID == custID);
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
                CustomerOrder.Add(order);
            }
            
        }
        [Authorize]
        [HttpPost]
        public void AddSpecialized([FromBody] string pizza)
        {

            Pizza pie = new Pizza();
            if (pizza == "DeepDish")
            {
                pie.PizzaType = "Deep Dish";
                pie.PizzaPrice = 15;
            }
            if (pizza == "Neapolitan")
            {
                pie.PizzaType = "Neapolitan";
                pie.PizzaPrice = 12;
            }
            if (pizza == "Sicilian")
            {
                pie.PizzaType = "Sicilian";
                pie.PizzaPrice = 10;
            }
            if (pizza == "StLouis")
            {
                pie.PizzaType = "St. Louis";
                pie.PizzaPrice = 12;
            }

            pie.Toppings = new List<Topping>();




            int custID = int.Parse(User.FindFirst("customerID").Value);
            bool hasCust = CustomerOrder.Exists(c => c.CustomerID == custID);
            if (hasCust)
            {
                Order order = CustomerOrder.Find(c => c.CustomerID == custID);
                order.Pizzas.Add(pie);
                order.OrderPrice += pie.PizzaPrice;
            }
            else
            {
                Order order = new Order()
                {
                    CustomerID = int.Parse(User.FindFirst("customerID").Value)
                };
                order.Pizzas = new List<Pizza>();
                order.Drinks = new List<Drink>();
                order.Pizzas.Add(pie);
                order.OrderPrice = pie.PizzaPrice;
                CustomerOrder.Add(order);
            }

        }

        [Authorize]
        [HttpPost]      
        public void AddDrink([FromBody] string drink)
        {

            Drink pie = new Drink();
            if (drink == "Cola")
            {
                pie.DrinkType = "Cola Cola ";
                pie.Price = 2;
            }
            if (drink == "Sprite")
            {
                pie.DrinkType = "Sprite";
                pie.Price = 2;
            }
            if (drink == "Fanta")
            {
                pie.DrinkType = "Fanta";
                pie.Price = 2;
            }
            if (drink == "Ramune")
            {
                pie.DrinkType = "Ramune";
                pie.Price = 4;
            }


            int custID = int.Parse(User.FindFirst("customerID").Value);
            bool hasCust = CustomerOrder.Exists(c => c.CustomerID == custID);
            if (hasCust)
            {
                Order order = CustomerOrder.Find(c => c.CustomerID == custID);
                order.Drinks.Add(pie);
                order.OrderPrice += pie.Price;
            }
            else
            {
                Order order = new Order()
                {
                    CustomerID = int.Parse(User.FindFirst("customerID").Value)
                };
                order.Pizzas = new List<Pizza>();
                order.Drinks = new List<Drink>();
                order.Drinks.Add(pie);
                order.OrderPrice = pie.Price;
                CustomerOrder.Add(order);
            }

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            int custID = int.Parse(User.FindFirst("customerID").Value);
            var httpClient = _clientFactory.CreateClient("API");

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/customers/" + custID);
            request.Headers.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Customer cust = await response.Content.ReadAsAsync<Customer>();
                Order order = CustomerOrder.Find(c => c.CustomerID == custID);
                cust.Orders = new List<Order>();
                cust.Orders.Add(order);

                return View(cust);
            }
            else
            {
                return View(string.Empty, "User not found");
            }

        }

        // GET: CheckOut
        [Authorize]
        public async Task<ActionResult> Index()
        {
            int custID = int.Parse(User.FindFirst("customerID").Value);
            var httpClient = _clientFactory.CreateClient("API");

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/customers/" + custID);
            // Must include these headers for GET
            request.Headers.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Customer cust = await response.Content.ReadAsAsync<Customer>();
                if (cust.CreditCardNumber == null)
                {
                    return RedirectToAction("UpdateCreditCard", "Account");
                } else
                {
                    return RedirectToAction("Checkout", "CheckOut");
                }



                return View();
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult Finalize()
        //{
        //    return View();
        //}

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Finalize(int? test)
        {
            int custID = int.Parse(User.FindFirst("customerID").Value);
            Order order = CustomerOrder.Find(c => c.CustomerID == custID);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            string var2 = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(var2, Encoding.UTF8, "application/json");
            string url = "https://localhost:44376/api/Orders/";
            var response = await client.PostAsync(url, httpContent);


            if (response.IsSuccessStatusCode)
            {
                CustomerOrder.Remove(order);
                return View();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DAMN"); ;
            }

            return View();

        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToOrder(string PizzaBread, bool PizzaCheese, string PizzaSize, string PizzaSauce, int[] TypeTopping)
        {
            System.Diagnostics.Debug.WriteLine("TEST");
            /*Order order = new Order()
            {
                CustomerID = int.Parse(User.FindFirst("customerID").Value)
            };*/
            Pizza pizza = new Pizza()
            {
                PizzaBread = PizzaBread,
                PizzaCheese = PizzaCheese,
                PizzaSize = PizzaSize,
                PizzaSauce = PizzaSauce
            };

            pizza.Toppings = new List<Topping>();
            if (TypeTopping.Length != 0)
            {
                for (int i = 0; i < TypeTopping.Length; i++)
                {
                    if (TypeTopping[i] == 1)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Pepperoni",
                            ToppingPrice = 3,
                            ToppingType = "Meat"
                        });

                    }
                    else
                        if (TypeTopping[i] == 2)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Sausage",
                            ToppingPrice = 3,
                            ToppingType = "Meat"
                        });
                    }
                    else
                        if (TypeTopping[i] == 3)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Ham",
                            ToppingPrice = 2,
                            ToppingType = "Meat"
                        });
                    }
                    else
                        if (TypeTopping[i] == 4)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Bacon",
                            ToppingPrice = 4,
                            ToppingType = "Meat"
                        });
                    }
                    else if (TypeTopping[i] == 5)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Beef",
                            ToppingPrice = 4,
                            ToppingType = "Meat"
                        });
                    }
                    else if (TypeTopping[i] == 6)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Pineapples",
                            ToppingPrice = 2,
                            ToppingType = "Vegetable"
                        });
                    }
                    else if (TypeTopping[i] == 7)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Spinich",
                            ToppingPrice = 1,
                            ToppingType = "Vegetable"
                        });
                    }
                    else if (TypeTopping[i] == 8)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Onions",
                            ToppingPrice = 1,
                            ToppingType = "Vegetable"
                        });
                    }
                    else if (TypeTopping[i] == 9)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Olives",
                            ToppingPrice = 2,
                            ToppingType = "Vegetable"
                        });
                    }
                    else if (TypeTopping[i] == 10)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Garlic",
                            ToppingPrice = 2,
                            ToppingType = "Vegetable"
                        });
                    }
                    else if (TypeTopping[i] == 11)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Green Pepper",
                            ToppingPrice = 2,
                            ToppingType = "Vegetable"
                        });
                    }
                    else if (TypeTopping[i] == 12)
                    {
                        pizza.Toppings.Add(new Topping()
                        {
                            ToppingName = "Sun Dried Tomatoes",
                            ToppingPrice = 3,
                            ToppingType = "Vegetable"
                        });
                    }


                }
            }
            //order.Pizzas = new List<Pizza>();
            pizza.PizzaType = "Custom";
            pizza.PizzaPrice = CalculatePrice(pizza);
            //order.Pizzas.Add(pizza);
            AddToList(pizza);


            return RedirectToAction("Menu", "Home");
            //return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ShoppingCart()
        {
            int custID = int.Parse(User.FindFirst("customerID").Value);
            Order orderList = CustomerOrder.Find(c => c.CustomerID == custID);
            return View(orderList);
        }

        [Authorize]
        public decimal CalculatePrice(Pizza pizza)
        {
            decimal price = 0;
            if (pizza.PizzaBread == "Brooklyn Style") price += 8;
            else if (pizza.PizzaBread == "Hand Tossed") price += 6;
            else if (pizza.PizzaBread == "Crunchy Thin Crust") price += 10;
            else if (pizza.PizzaBread == "Handmade Pan") price += 9;

            if (pizza.PizzaSize == "Small") price += 0;
            else if (pizza.PizzaSize == "Medium") price += 2;
            else if (pizza.PizzaSize == "Large") price += 3;
            else if (pizza.PizzaSize == "X-Large") price += 5;

            if (pizza.PizzaCheese) price += 1;

            if (pizza.PizzaSauce == "BBQ Sauce") price += 1;
            else if (pizza.PizzaSauce == "Alfredo Sauce") price += 2;
            else if (pizza.PizzaSauce == "Robust Inspired Tomato Sauce") price += 1;
            else if (pizza.PizzaSauce == "Garlic Parmesan White Sauce") price += 3;
            else if (pizza.PizzaSauce == "Hearty Marinara Sauce") price += 4;
            else if (pizza.PizzaSauce == "None") price += 0;

            foreach (Topping t in pizza.Toppings) price = price + t.ToppingPrice;

            return price;
        }
    }
}