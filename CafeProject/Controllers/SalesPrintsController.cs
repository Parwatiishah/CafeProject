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
    public class SalesPrintsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public SalesPrintsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesPrints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesPrint>>> GetSalesPrints()
        {
            return await _context.SalesPrints.ToListAsync();
        }

        // GET: api/SalesPrints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesPrint>> GetSalesPrint(long id)
        {
            var salesPrint = await _context.SalesPrints.FindAsync(id);

            if (salesPrint == null)
            {
                return NotFound();
            }

            return salesPrint;
        }

        // PUT: api/SalesPrints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesPrint(long id, SalesPrint salesPrint)
        {
            if (id != salesPrint.SalesId)
            {
                return BadRequest();
            }

            _context.Entry(salesPrint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesPrintExists(id))
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

        // POST: api/SalesPrints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesPrint>> PostSalesPrint(SalesPrint salesPrint)
        {
            _context.SalesPrints.Add(salesPrint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesPrintExists(salesPrint.SalesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesPrint", new { id = salesPrint.SalesId }, salesPrint);
        }

        // DELETE: api/SalesPrints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesPrint(long id)
        {
            var salesPrint = await _context.SalesPrints.FindAsync(id);
            if (salesPrint == null)
            {
                return NotFound();
            }

            _context.SalesPrints.Remove(salesPrint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesPrintExists(long id)
        {
            return _context.SalesPrints.Any(e => e.SalesId == id);
        }
    }
}
