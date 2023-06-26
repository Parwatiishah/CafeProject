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
    public class PaymentPrintsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public PaymentPrintsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PaymentPrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentPrint>>> GetPaymentPrints()
        {
            return await _context.PaymentPrints.ToListAsync();
        }

        // GET: api/PaymentPrints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentPrint>> GetPaymentPrint(long id)
        {
            var paymentPrint = await _context.PaymentPrints.FindAsync(id);

            if (paymentPrint == null)
            {
                return NotFound();
            }

            return paymentPrint;
        }

        // PUT: api/PaymentPrints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentPrint(long id, PaymentPrint paymentPrint)
        {
            if (id != paymentPrint.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(paymentPrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentPrintExists(id))
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

        // POST: api/PaymentPrints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentPrint>> PostPaymentPrint(PaymentPrint paymentPrint)
        {
            _context.PaymentPrints.Add(paymentPrint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentPrintExists(paymentPrint.PaymentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymentPrint", new { id = paymentPrint.PaymentId }, paymentPrint);
        }

        // DELETE: api/PaymentPrints/5
        /*

          [HttpDelete("{id}")]
         public async Task<IActionResult> DeletePaymentPrint(long id)
         {
             var paymentPrint = await _context.PaymentPrints.FindAsync(id);
             if (paymentPrint == null)
             {
                 return NotFound();
             }

             _context.PaymentPrints.Remove(paymentPrint);
             await _context.SaveChangesAsync();

             return NoContent();
         }
         */

        private bool PaymentPrintExists(long id)
        {
            return _context.PaymentPrints.Any(e => e.PaymentId == id);
        }
    }
}
