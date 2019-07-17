using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            _db.Orders.Add(
                new Order()
                {
                    CustomerID = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    OrderDateTime = DateTime.Now,
                    OrderPrice = 10
                }); ;

            _db.SaveChanges();
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
