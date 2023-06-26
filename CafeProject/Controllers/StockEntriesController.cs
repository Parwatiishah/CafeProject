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
    public class StockEntriesController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public StockEntriesController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StockEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockEntry>>> GetStockEntries()
        {
            return await _context.StockEntries.ToListAsync();
        }

        // GET: api/StockEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockEntry>> GetStockEntry(long id)
        {
            var stockEntry = await _context.StockEntries.FindAsync(id);

            if (stockEntry == null)
            {
                return NotFound();
            }

            return stockEntry;
        }

        // PUT: api/StockEntries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockEntry(long id, StockEntry stockEntry)
        {
            if (id != stockEntry.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(stockEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockEntryExists(id))
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

        // POST: api/StockEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockEntry>> PostStockEntry(StockEntry stockEntry)
        {
            _context.StockEntries.Add(stockEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockEntry", new { id = stockEntry.EntryId }, stockEntry);
        }

        // DELETE: api/StockEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockEntry(long id)
        {
            var stockEntry = await _context.StockEntries.FindAsync(id);
            if (stockEntry == null)
            {
                return NotFound();
            }

            _context.StockEntries.Remove(stockEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<StockEntry> patchdoc)
        {
            StockEntry? stockEntry = _context.StockEntries.Where(u => u.EntryId == id).FirstOrDefault();

            if (stockEntry != null)
            {
                patchdoc.ApplyTo(stockEntry, ModelState);
                return Ok(stockEntry);
            }
            return NotFound();

        }


        private bool StockEntryExists(long id)
        {
            return _context.StockEntries.Any(e => e.EntryId == id);
        }
    }
}
