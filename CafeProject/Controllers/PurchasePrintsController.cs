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
    public class PurchasePrintsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public PurchasePrintsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchasePrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchasePrint>>> GetPurchasePrints()
        {
            return await _context.PurchasePrints.ToListAsync();
        }

        // GET: api/PurchasePrints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchasePrint>> GetPurchasePrint(long id)
        {
            var purchasePrint = await _context.PurchasePrints.FindAsync(id);

            if (purchasePrint == null)
            {
                return NotFound();
            }

            return purchasePrint;
        }

        // PUT: api/PurchasePrints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchasePrint(long id, PurchasePrint purchasePrint)
        {
            if (id != purchasePrint.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchasePrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasePrintExists(id))
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

        // POST: api/PurchasePrints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchasePrint>> PostPurchasePrint(PurchasePrint purchasePrint)
        {
            _context.PurchasePrints.Add(purchasePrint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchasePrintExists(purchasePrint.PurchaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchasePrint", new { id = purchasePrint.PurchaseId }, purchasePrint);
        }

        // DELETE: api/PurchasePrints/5
        /*

          [HttpDelete("{id}")]
         public async Task<IActionResult> DeletePurchasePrint(long id)
         {
             var purchasePrint = await _context.PurchasePrints.FindAsync(id);
             if (purchasePrint == null)
             {
                 return NotFound();
             }

             _context.PurchasePrints.Remove(purchasePrint);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         */
        private bool PurchasePrintExists(long id)
        {
            return _context.PurchasePrints.Any(e => e.PurchaseId == id);
        }
    }
}
