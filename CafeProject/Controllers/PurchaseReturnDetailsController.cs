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
    public class PurchaseReturnDetailsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public PurchaseReturnDetailsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseReturnDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseReturnDetail>>> GetPurchaseReturnDetails()
        {
            return await _context.PurchaseReturnDetails.ToListAsync();
        }

        // GET: api/PurchaseReturnDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseReturnDetail>> GetPurchaseReturnDetail(long id)
        {
            var purchaseReturnDetail = await _context.PurchaseReturnDetails.FindAsync(id);

            if (purchaseReturnDetail == null)
            {
                return NotFound();
            }

            return purchaseReturnDetail;
        }

        // PUT: api/PurchaseReturnDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseReturnDetail(long id, PurchaseReturnDetail purchaseReturnDetail)
        {
            if (id != purchaseReturnDetail.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseReturnDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseReturnDetailExists(id))
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

        // POST: api/PurchaseReturnDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseReturnDetail>> PostPurchaseReturnDetail(PurchaseReturnDetail purchaseReturnDetail)
        {
            _context.PurchaseReturnDetails.Add(purchaseReturnDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseReturnDetailExists(purchaseReturnDetail.ReturnId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseReturnDetail", new { id = purchaseReturnDetail.ReturnId }, purchaseReturnDetail);
        }

        // DELETE: api/PurchaseReturnDetails/5
        /*
         
         [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseReturnDetail(long id)
        {
            var purchaseReturnDetail = await _context.PurchaseReturnDetails.FindAsync(id);
            if (purchaseReturnDetail == null)
            {
                return NotFound();
            }

            _context.PurchaseReturnDetails.Remove(purchaseReturnDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
         */

        private bool PurchaseReturnDetailExists(long id)
        {
            return _context.PurchaseReturnDetails.Any(e => e.ReturnId == id);
        }
    }
}
