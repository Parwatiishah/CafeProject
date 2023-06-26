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
    public class SalesReturnPrintsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public SalesReturnPrintsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesReturnPrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesReturnPrint>>> GetSalesReturnPrints()
        {
            return await _context.SalesReturnPrints.ToListAsync();
        }

        // GET: api/SalesReturnPrints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesReturnPrint>> GetSalesReturnPrint(long id)
        {
            var salesReturnPrint = await _context.SalesReturnPrints.FindAsync(id);

            if (salesReturnPrint == null)
            {
                return NotFound();
            }

            return salesReturnPrint;
        }

        // PUT: api/SalesReturnPrints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesReturnPrint(long id, SalesReturnPrint salesReturnPrint)
        {
            if (id != salesReturnPrint.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(salesReturnPrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesReturnPrintExists(id))
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

        // POST: api/SalesReturnPrints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesReturnPrint>> PostSalesReturnPrint(SalesReturnPrint salesReturnPrint)
        {
            _context.SalesReturnPrints.Add(salesReturnPrint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesReturnPrintExists(salesReturnPrint.ReturnId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesReturnPrint", new { id = salesReturnPrint.ReturnId }, salesReturnPrint);
        }
        /*
         // DELETE: api/SalesReturnPrints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesReturnPrint(long id)
        {
            var salesReturnPrint = await _context.SalesReturnPrints.FindAsync(id);
            if (salesReturnPrint == null)
            {
                return NotFound();
            }

            _context.SalesReturnPrints.Remove(salesReturnPrint);
            await _context.SaveChangesAsync();

            return NoContent();
        }
         */


        private bool SalesReturnPrintExists(long id)
        {
            return _context.SalesReturnPrints.Any(e => e.ReturnId == id);
        }
    }
}
