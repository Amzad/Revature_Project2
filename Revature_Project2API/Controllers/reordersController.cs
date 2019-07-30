using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revature_Project2API.Data;
using Entities.Models;

namespace Revature_Project2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reordersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public reordersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/reorders
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        //{
        //    return await _context.Orders.ToListAsync();
        //}

        // GET: api/reorders/5
        [HttpGet("{id}")]
        public async Task<ICollection<Order>> GetOrder(int id)
        {

            //var order = await _context.Order.FindAsync(id);
            string custid = id.ToString();
            var order = await _context.Orders.Where(x => x.Customer.CustomerID == id).ToListAsync();
            if (order == null)
            {
                return null;
            }

            return order;
        }


        [HttpGet("Detail/{id}")]
        public async Task<Order> PizzaDetail(int id)
        {

            //var order = await _context.Order.FindAsync(id);
            //string custid = id.ToString();
            Order item = new Order();
            item.Pizzas = await _context.Pizzas.Where(o => o.OrderID == id).Include(o => o.Toppings).ToListAsync();
            item.Drinks = await _context.Drinks.Where(d => d.OrderID == id).ToListAsync();
            //.ThenInclude(c => c.Toppings)
            if (item == null)
            {
                return null;
            }

            return item;
        }

        // PUT: api/reorders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/reorders
        //[HttpPost]
        //public async Task<ActionResult<Order>> PostOrder(Order order)
        //{
        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        //}

        // DELETE: api/reorders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Order>> DeleteOrder(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return order;
        //}

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
