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
    public class RoleListsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public RoleListsController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoleLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleList>>> GetRoleLists()
        {
            return await _context.RoleLists.ToListAsync();
        }

        // GET: api/RoleLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleList>> GetRoleList(short id)
        {
            var roleList = await _context.RoleLists.FindAsync(id);

            if (roleList == null)
            {
                return NotFound();
            }

            return roleList;
        }

        // PUT: api/RoleLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleList(short id, RoleList roleList)
        {
            if (id != roleList.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleListExists(id))
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

        // POST: api/RoleLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleList>> PostRoleList(RoleList roleList)
        {
            _context.RoleLists.Add(roleList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleListExists(roleList.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoleList", new { id = roleList.RoleId }, roleList);
        }

        // DELETE: api/RoleLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleList(short id)
        {
            var roleList = await _context.RoleLists.FindAsync(id);
            if (roleList == null)
            {
                return NotFound();
            }

            _context.RoleLists.Remove(roleList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleListExists(short id)
        {
            return _context.RoleLists.Any(e => e.RoleId == id);
        }
    }
}
