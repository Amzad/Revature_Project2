using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Revature_Project2.Controllers
{
    public class CheckOutController : Controller
    {
        public static List<Order> CustomerOrder = new List<Order>();

        public void AddToList(Order Item)
        {
            CustomerOrder.Add(Item);
        }
        public void CheckOut(Order Item)
        {
            CustomerOrder.RemoveAll(s => s.CustomerID == Item.CustomerID);
        }
        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckOut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckOut/Create
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

        // GET: CheckOut/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckOut/Edit/5
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

        // GET: CheckOut/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckOut/Delete/5
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

        [HttpPost]
        public async Task<IActionResult> AddToOrder(string PizzaBread, bool PizzaCheese, string PizzaSize, string PizzaSauce, int[] TypeTopping)
        {
            System.Diagnostics.Debug.WriteLine("TEST");
            Order order = new Order()
            {
                CustomerID = int.Parse(User.FindFirst("customerID").Value)
            };
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
            order.Pizzas = new List<Pizza>();
            order.Pizzas.Add(pizza);
            AddToList(order);
            


            return View();
        }
    }
}