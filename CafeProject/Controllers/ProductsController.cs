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
    public class ProductsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public ProductsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCatView>>> GetProducts()
        {
            return await _context.ProductCatViews.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product =  _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if(product== null)
            {
                return NotFound();
            }
            return product;
               
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct( int id, [FromForm] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product pro)
        {
            try
            {
                Product p = new Product()
                {
                    ProductId =pro.ProductId,
                    ProductName = pro.ProductName,
                    ProductCatId = pro.ProductCatId,
                    ProductCode = pro.ProductCode,
                    IsAvailable = pro.IsAvailable,
                    IsVatableItem = pro.IsVatableItem,
                    Quantity = pro.Quantity,
                    RackNumber = pro.RackNumber,
                    SellingPrice = pro.SellingPrice,
                    UnitName = pro.UnitName,
                    WaitingTime = pro.WaitingTime
                };
                _context.Products.Add(p);
                await _context.SaveChangesAsync();

                return Ok(CreatedAtAction("GetProduct", new { id = p.ProductId }, p));

            }
            catch
            {
                return NotFound();
            }

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
        [HttpPatch("{id}")]
        public IActionResult StatusChange(int id, [FromBody] JsonPatchDocument<Product> patchdoc)
        {
            Product? products = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (products == null)
            {
                return NotFound();
            }

            patchdoc.ApplyTo(products);
            _context.SaveChanges();
            return Ok();
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
