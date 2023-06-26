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
    public class SalesRecordsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public SalesRecordsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesRecord>>> GetSalesRecords()
        {
            return await _context.SalesRecords.ToListAsync();
        }

        // GET: api/SalesRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesRecord>> GetSalesRecord(long id)
        {
            var salesRecord = await _context.SalesRecords.FindAsync(id);

            if (salesRecord == null)
            {
                return NotFound();
            }

            return salesRecord;
        }

        // PUT: api/SalesRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesRecord(long id, SalesRecord salesRecord)
        {
            if (id != salesRecord.SalesId)
            {
                return BadRequest();
            }

            _context.Entry(salesRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesRecordExists(id))
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

        // POST: api/SalesRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesRecord>> PostSalesRecord(SalesRecord salesRecord)
        {
            _context.SalesRecords.Add(salesRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesRecord", new { id = salesRecord.SalesId }, salesRecord);
        }
        /*
        // DELETE: api/SalesRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesRecord(long id)
        {
            var salesRecord = await _context.SalesRecords.FindAsync(id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            _context.SalesRecords.Remove(salesRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<SalesRecord> patchdoc)
        {
            SalesRecord? salesRecord = _context.SalesRecords.Where(u => u.SalesId == id).FirstOrDefault();

            if (salesRecord != null)
            {
                patchdoc.ApplyTo(salesRecord, ModelState);
                return Ok(salesRecord);
            }
            return NotFound();

        }
        private bool SalesRecordExists(long id)
        {
            return _context.SalesRecords.Any(e => e.SalesId == id);
        }
    }
}
