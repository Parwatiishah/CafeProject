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
    public class PaymentModesController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public PaymentModesController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PaymentModes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMode>>> GetPaymentModes()
        {
            return await _context.PaymentModes.ToListAsync();
        }

        // GET: api/PaymentModes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMode>> GetPaymentMode(byte id)
        {
            var paymentMode = await _context.PaymentModes.FindAsync(id);

            if (paymentMode == null)
            {
                return NotFound();
            }

            return paymentMode;
        }

        // PUT: api/PaymentModes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
          [HttpPut("{id}")]
         public async Task<IActionResult> PutPaymentMode(byte id, PaymentMode paymentMode)
         {
             if (id != paymentMode.ModeId)
             {
                 return BadRequest();
             }

             _context.Entry(paymentMode).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!PaymentModeExists(id))
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
         */

        // POST: api/PaymentModes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentMode>> PostPaymentMode(PaymentMode paymentMode)
        {
            _context.PaymentModes.Add(paymentMode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentModeExists(paymentMode.ModeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymentMode", new { id = paymentMode.ModeId }, paymentMode);
        }

        // DELETE: api/PaymentModes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMode(byte id)
        {
            var paymentMode = await _context.PaymentModes.FindAsync(id);
            if (paymentMode == null)
            {
                return NotFound();
            }

            _context.PaymentModes.Remove(paymentMode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentModeExists(byte id)
        {
            return _context.PaymentModes.Any(e => e.ModeId == id);
        }
    }
}
