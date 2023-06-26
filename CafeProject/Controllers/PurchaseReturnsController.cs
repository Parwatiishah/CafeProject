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
    public class PurchaseReturnsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public PurchaseReturnsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseReturn>>> GetPurchaseReturns()
        {
            return await _context.PurchaseReturns.ToListAsync();
        }

        // GET: api/PurchaseReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseReturn>> GetPurchaseReturn(long id)
        {
            var purchaseReturn = await _context.PurchaseReturns.FindAsync(id);

            if (purchaseReturn == null)
            {
                return NotFound();
            }

            return purchaseReturn;
        }

        // PUT: api/PurchaseReturns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseReturn(long id, PurchaseReturn purchaseReturn)
        {
            if (id != purchaseReturn.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseReturnExists(id))
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

        // POST: api/PurchaseReturns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseReturn>> PostPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            _context.PurchaseReturns.Add(purchaseReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseReturn", new { id = purchaseReturn.ReturnId }, purchaseReturn);
        }
        /*
        // DELETE: api/PurchaseReturns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseReturn(long id)
        {
            var purchaseReturn = await _context.PurchaseReturns.FindAsync(id);
            if (purchaseReturn == null)
            {
                return NotFound();
            }

            _context.PurchaseReturns.Remove(purchaseReturn);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<PurchaseDetail> patchdoc)
        {
            PurchaseDetail? purchaseDetail = _context.PurchaseDetails.Where(u => u.PurchaseId == id).FirstOrDefault();

            if (purchaseDetail != null)
            {
                patchdoc.ApplyTo(purchaseDetail, ModelState);
                return Ok(purchaseDetail);
            }
            return NotFound();

        }

        private bool PurchaseReturnExists(long id)
        {
            return _context.PurchaseReturns.Any(e => e.ReturnId == id);
        }
    }
}
