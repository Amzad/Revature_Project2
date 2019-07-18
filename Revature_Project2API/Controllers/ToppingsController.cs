using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revature_Project2API.Data;
using Revature_Project2API.Models;

namespace Revature_Project2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToppingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topping>>> GetTopping()
        {
            return await _context.Topping.ToListAsync();
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topping>> GetTopping(int id)
        {
            var topping = await _context.Topping.FindAsync(id);

            if (topping == null)
            {
                return NotFound();
            }

            return topping;
        }

        // PUT: api/Toppings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopping(int id, Topping topping)
        {
            if (id != topping.ToppingID)
            {
                return BadRequest();
            }

            _context.Entry(topping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingExists(id))
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

        // POST: api/Toppings
        [HttpPost]
        public async Task<ActionResult<Topping>> PostTopping(Topping topping)
        {
            _context.Topping.Add(topping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopping", new { id = topping.ToppingID }, topping);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Topping>> DeleteTopping(int id)
        {
            var topping = await _context.Topping.FindAsync(id);
            if (topping == null)
            {
                return NotFound();
            }

            _context.Topping.Remove(topping);
            await _context.SaveChangesAsync();

            return topping;
        }

        private bool ToppingExists(int id)
        {
            return _context.Topping.Any(e => e.ToppingID == id);
        }
    }
}
