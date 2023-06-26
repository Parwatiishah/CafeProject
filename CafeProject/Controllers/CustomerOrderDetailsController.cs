using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CafeProject.Models;

namespace CafeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderDetailsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public CustomerOrderDetailsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrderDetail>>> GetCustomerOrderDetails()
        {
            return await _context.CustomerOrderDetails.ToListAsync();
        }

        // GET: api/CustomerOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOrderDetail>> GetCustomerOrderDetail(long id)
        {
            var customerOrderDetail = await _context.CustomerOrderDetails.FindAsync(id);

            if (customerOrderDetail == null)
            {
                return NotFound();
            }

            return customerOrderDetail;
        }

        // PUT: api/CustomerOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerOrderDetail(long id, CustomerOrderDetail customerOrderDetail)
        {
            if (id != customerOrderDetail.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(customerOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerOrderDetailExists(id))
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

        // POST: api/CustomerOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerOrderDetail>> PostCustomerOrderDetail(CustomerOrderDetail customerOrderDetail)
        {
            _context.CustomerOrderDetails.Add(customerOrderDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerOrderDetailExists(customerOrderDetail.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerOrderDetail", new { id = customerOrderDetail.OrderId }, customerOrderDetail);
        }

        // DELETE: api/CustomerOrderDetails/5
        /*
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteCustomerOrderDetail(long id)
         {
             var customerOrderDetail = await _context.CustomerOrderDetails.FindAsync(id);
             if (customerOrderDetail == null)
             {
                 return NotFound();
             }

             _context.CustomerOrderDetails.Remove(customerOrderDetail);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         */
        private bool CustomerOrderDetailExists(long id)
        {
            return _context.CustomerOrderDetails.Any(e => e.OrderId == id);
        }
    }
}
