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
    public class SalesDetailsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public SalesDetailsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDetail>>> GetSalesDetails()
        {
            return await _context.SalesDetails.ToListAsync();
        }

        // GET: api/SalesDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDetail>> GetSalesDetail(long id)
        {
            var salesDetail = await _context.SalesDetails.FindAsync(id);

            if (salesDetail == null)
            {
                return NotFound();
            }

            return salesDetail;
        }

        // PUT: api/SalesDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesDetail(long id, SalesDetail salesDetail)
        {
            if (id != salesDetail.SalesId)
            {
                return BadRequest();
            }

            _context.Entry(salesDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDetailExists(id))
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

        // POST: api/SalesDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesDetail>> PostSalesDetail(SalesDetail salesDetail)
        {
            _context.SalesDetails.Add(salesDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesDetailExists(salesDetail.SalesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesDetail", new { id = salesDetail.SalesId }, salesDetail);
        }

        // DELETE: api/SalesDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesDetail(long id)
        {
            var salesDetail = await _context.SalesDetails.FindAsync(id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            _context.SalesDetails.Remove(salesDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesDetailExists(long id)
        {
            return _context.SalesDetails.Any(e => e.SalesId == id);
        }
    }
}
