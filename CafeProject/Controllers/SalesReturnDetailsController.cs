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
    public class SalesReturnDetailsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public SalesReturnDetailsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesReturnDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesReturnDetail>>> GetSalesReturnDetails()
        {
            return await _context.SalesReturnDetails.ToListAsync();
        }

        // GET: api/SalesReturnDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesReturnDetail>> GetSalesReturnDetail(long id)
        {
            var salesReturnDetail = await _context.SalesReturnDetails.FindAsync(id);

            if (salesReturnDetail == null)
            {
                return NotFound();
            }

            return salesReturnDetail;
        }

        // PUT: api/SalesReturnDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesReturnDetail(long id, SalesReturnDetail salesReturnDetail)
        {
            if (id != salesReturnDetail.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(salesReturnDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesReturnDetailExists(id))
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

        // POST: api/SalesReturnDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesReturnDetail>> PostSalesReturnDetail(SalesReturnDetail salesReturnDetail)
        {
            _context.SalesReturnDetails.Add(salesReturnDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesReturnDetailExists(salesReturnDetail.ReturnId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesReturnDetail", new { id = salesReturnDetail.ReturnId }, salesReturnDetail);
        }
        /*

        // DELETE: api/SalesReturnDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesReturnDetail(long id)
        {
            var salesReturnDetail = await _context.SalesReturnDetails.FindAsync(id);
            if (salesReturnDetail == null)
            {
                return NotFound();
            }

            _context.SalesReturnDetails.Remove(salesReturnDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
        private bool SalesReturnDetailExists(long id)
        {
            return _context.SalesReturnDetails.Any(e => e.ReturnId == id);
        }
    }
}
