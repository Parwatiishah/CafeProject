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
    public class PurchaseReturnPrintsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public PurchaseReturnPrintsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseReturnPrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseReturnPrint>>> GetPurchaseReturnPrints()
        {
            return await _context.PurchaseReturnPrints.ToListAsync();
        }

        // GET: api/PurchaseReturnPrints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseReturnPrint>> GetPurchaseReturnPrint(long id)
        {
            var purchaseReturnPrint = await _context.PurchaseReturnPrints.FindAsync(id);

            if (purchaseReturnPrint == null)
            {
                return NotFound();
            }

            return purchaseReturnPrint;
        }

        // PUT: api/PurchaseReturnPrints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseReturnPrint(long id, PurchaseReturnPrint purchaseReturnPrint)
        {
            if (id != purchaseReturnPrint.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseReturnPrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseReturnPrintExists(id))
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

        // POST: api/PurchaseReturnPrints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseReturnPrint>> PostPurchaseReturnPrint(PurchaseReturnPrint purchaseReturnPrint)
        {
            _context.PurchaseReturnPrints.Add(purchaseReturnPrint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseReturnPrintExists(purchaseReturnPrint.ReturnId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseReturnPrint", new { id = purchaseReturnPrint.ReturnId }, purchaseReturnPrint);
        }

        // DELETE: api/PurchaseReturnPrints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseReturnPrint(long id)
        {
            var purchaseReturnPrint = await _context.PurchaseReturnPrints.FindAsync(id);
            if (purchaseReturnPrint == null)
            {
                return NotFound();
            }

            _context.PurchaseReturnPrints.Remove(purchaseReturnPrint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseReturnPrintExists(long id)
        {
            return _context.PurchaseReturnPrints.Any(e => e.ReturnId == id);
        }
    }
}
