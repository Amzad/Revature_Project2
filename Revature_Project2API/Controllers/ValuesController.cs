using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revature_Project2API.Data;
using Revature_Project2API.Models;

namespace Revature_Project2API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ApplicationDbContext _context;
        public ValuesController(ApplicationDbContext context)
        {
            System.Diagnostics.Debug.WriteLine("ValuesController Constructor");
            _context = context;
            if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(new Customer { CustomerID = 1, CustomerFirstName = "Amzad", CustomerLastName = "Chowdhury" ,Username = "MangoTea", Password = "Test1234" });
                _context.SaveChanges();
            }
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}