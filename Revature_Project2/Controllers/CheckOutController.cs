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
        public static List<Order> TempOrder { get; set; }
        public void AddToPizza(string PizzaBread, bool PizzaCheese, string PizzaSize, string PizzaSauce, string[] TypeTopping)
        {
   
            Pizza TempPizza = new Pizza();
            List<Topping> fTopping = new List<Topping>
            {
                new Topping() { ToppingName = TypeTopping[0]},
                new Topping() { ToppingName = TypeTopping[1]},
                new Topping() { ToppingName = TypeTopping[2]}
            };
            TempPizza.Toppings = fTopping;
            TempPizza.PizzaBread = PizzaBread;
            TempPizza.PizzaSauce = PizzaSauce;
            TempPizza.PizzaPrice = 90;
            TempPizza.PizzaSize = PizzaSize;
            TempPizza.PizzaCheese = PizzaCheese;
            //TempOrder.Add();
        }
        public void CheckOut(Order Item)
        {
            TempOrder.RemoveAll(s => s.CustomerID == Item.CustomerID);
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
    }
}