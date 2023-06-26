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
    public class SalesReturnsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public SalesReturnsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesReturn>>> GetSalesReturns()
        {
            return await _context.SalesReturns.ToListAsync();
        }

        // GET: api/SalesReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesReturn>> GetSalesReturn(long id)
        {
            var salesReturn = await _context.SalesReturns.FindAsync(id);

            if (salesReturn == null)
            {
                return NotFound();
            }

            return salesReturn;
        }

        // PUT: api/SalesReturns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesReturn(long id, SalesReturn salesReturn)
        {
            if (id != salesReturn.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(salesReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesReturnExists(id))
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

        // POST: api/SalesReturns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesReturn>> PostSalesReturn(SalesReturn salesReturn)
        {
            _context.SalesReturns.Add(salesReturn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesReturnExists(salesReturn.ReturnId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesReturn", new { id = salesReturn.ReturnId }, salesReturn);
        }
        /*
         // DELETE: api/SalesReturns/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSalesReturn(long id)
    {
        var salesReturn = await _context.SalesReturns.FindAsync(id);
        if (salesReturn == null)
        {
            return NotFound();
        }

        _context.SalesReturns.Remove(salesReturn);
        await _context.SaveChangesAsync();

        return NoContent();
    }

         */
        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<SalesReturn> patchdoc)
        {
            SalesReturn? salesReturn = _context.SalesReturns.Where(u => u.ReturnId == id).FirstOrDefault();

            if (salesReturn != null)
            {
                patchdoc.ApplyTo(salesReturn, ModelState);
                return Ok(salesReturn);
            }
            return NotFound();

        }

        private bool SalesReturnExists(long id)
        {
            return _context.SalesReturns.Any(e => e.ReturnId == id);
        }
    }
}
