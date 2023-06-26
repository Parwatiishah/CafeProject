using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CafeProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CafeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public CustomerOrdersController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrder>>> GetCustomerOrders()
        {
            return await _context.CustomerOrders.ToListAsync();
        }

        // GET: api/CustomerOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOrder>> GetCustomerOrder(long id)
        {
            var customerOrder = await _context.CustomerOrders.FindAsync(id);

            if (customerOrder == null)
            {
                return NotFound();
            }

            return customerOrder;
        }

        // PUT: api/CustomerOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerOrder(long id, CustomerOrder customerOrder)
        {
            if (id != customerOrder.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(customerOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerOrderExists(id))
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

        // POST: api/CustomerOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerOrder>> PostCustomerOrder(CustomerOrder customerOrder)
        {
            _context.CustomerOrders.Add(customerOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerOrderExists(customerOrder.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerOrder", new { id = customerOrder.OrderId }, customerOrder);
        }
        /*
        // DELETE: api/CustomerOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerOrder(long id)
        {
            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            _context.CustomerOrders.Remove(customerOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<CustomerOrder> patchdoc)
        {
            CustomerOrder? customerOrder = _context.CustomerOrders.Where(u => u.OrderId == id).FirstOrDefault();

            if (customerOrder != null)
            {
                patchdoc.ApplyTo(customerOrder, ModelState);
                return Ok(customerOrder);
            }
            return NotFound();

        }
        private bool CustomerOrderExists(long id)
        {
            return _context.CustomerOrders.Any(e => e.OrderId == id);
        }
    }
}
