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
    public class CustomerReceiptsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public CustomerReceiptsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerReceipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReceiptView>>> GetCustomerReceipts()
        {
            return await _context.CustomerReceiptViews.ToListAsync();
        }

        // GET: api/CustomerReceipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReceipt>> GetCustomerReceipt(long id)
        {
            var customerReceipt = await _context.CustomerReceipts.FindAsync(id);

            if (customerReceipt == null)
            {
                return NotFound();
            }

            return customerReceipt;
        }

        // PUT: api/CustomerReceipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerReceipt(long id,[FromForm] CustomerReceiptEdit customerReceiptEdit)
        {

            CustomerReceipt customerReceipt = new CustomerReceipt()
            {
                                
                TotalAmount = customerReceiptEdit.TotalAmount,
                DiscountAmount = customerReceiptEdit.DiscountAmount,
                FiscalYear = customerReceiptEdit.FiscalYear,
                

            };
            _context.Entry(customerReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerReceiptExists(id))
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

        // POST: api/CustomerReceipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public async Task<ActionResult<CustomerReceiptView>> PostCustomerReceipt(CustomerReceiptEdit customerReceiptEdit)
        {
            customerReceiptEdit.ReceiptDate = DateTime.Today;
            customerReceiptEdit.ReceiptTime = DateTime.UtcNow.AddMinutes(345).ToShortTimeString();
            CustomerReceipt customerReceipt = new CustomerReceipt()
            {
                CustomerId = customerReceiptEdit.CustomerId,
                ModeId = customerReceiptEdit.ModeId,
                ReceiptDate = customerReceiptEdit.ReceiptDate,
                ReceiptTime = customerReceiptEdit.ReceiptTime,
                TotalAmount = customerReceiptEdit.TotalAmount,
                DiscountAmount = customerReceiptEdit.DiscountAmount,
                FiscalYear = customerReceiptEdit.FiscalYear,
                EntryUserId = customerReceiptEdit.EntryUserId

            };
            _context.CustomerReceipts.Add(customerReceipt);
            await _context.SaveChangesAsync();
            ReceiptPrint receiptPrint = new ReceiptPrint
            {
                ReceiptId = customerReceipt.ReceiptId,
                PrintUserId = customerReceipt.EntryUserId,
                PrintDate = customerReceipt.ReceiptDate,
                PrintTime = customerReceipt.ReceiptTime

            };
            _context.ReceiptPrints.Add(receiptPrint);
            await _context.SaveChangesAsync();
             return Ok(_context.ReceiptPrintViews.Where(x=>x.PrintId==receiptPrint.PrintId).FirstOrDefault());
            // return CreatedAtAction("GetCustomerReceipt", new { id = customerReceipt.ReceiptId }, customerReceipt);
        }




        // DELETE: api/CustomerReceipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerReceipt(long id)
        {
            var customerReceipt = await _context.CustomerReceipts.FindAsync(id);
            if (customerReceipt == null)
            {
                return NotFound();
            }

            _context.CustomerReceipts.Remove(customerReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<CustomerReceipt> patchdoc)
        {
            CustomerReceipt? customerReceipt = _context.CustomerReceipts.FirstOrDefault(x => x.ReceiptId == id);

            if (customerReceipt == null)
            {
                return NotFound();
            }
           
            patchdoc.ApplyTo(customerReceipt);
            _context.SaveChanges();
            return Ok();
        }
        private bool CustomerReceiptExists(long id)
        {
            return _context.CustomerReceipts.Any(e => e.ReceiptId == id);
        }
    }
}
