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
    public class ReceiptPrintsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public ReceiptPrintsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ReceiptPrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptPrintView>>> GetReceiptPrints()
        {
            return await _context.ReceiptPrintViews.ToListAsync();
        }

        // GET: api/ReceiptPrints/5
        [HttpGet("{id}")]
/* changes done*/
        public ActionResult<ReceiptPrintView> GetReceiptPrint(long id)
        {
            var receiptPrint = _context.ReceiptPrintViews.Where(x => x.PrintId == id).FirstOrDefault();

            if (receiptPrint == null)
            {
                return NotFound();
            }

            return receiptPrint;
        }

        // PUT: api/ReceiptPrints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiptPrint(long id, ReceiptPrint receiptPrint)
        {
            if (id != receiptPrint.ReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(receiptPrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptPrintExists(id))
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

        // POST: api/ReceiptPrints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReceiptPrintView>> PostReceiptPrint(ReceiptPrint receiptPrint)
        {
            _context.ReceiptPrints.Add(receiptPrint);
            await _context.SaveChangesAsync();
            return Ok(_context.ReceiptPrintViews.Where(x=>x.PrintId==receiptPrint.PrintId).FirstOrDefault());

        }

        // DELETE: api/ReceiptPrints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiptPrint(long id)
        {
            var receiptPrint = await _context.ReceiptPrints.FindAsync(id);
            if (receiptPrint == null)
            {
                return NotFound();
            }

            _context.ReceiptPrints.Remove(receiptPrint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiptPrintExists(long id)
        {
            return _context.ReceiptPrints.Any(e => e.ReceiptId == id);
        }
    }
}
