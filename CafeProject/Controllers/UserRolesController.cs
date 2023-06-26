﻿using System;
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
    public class UserRolesController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;

        public UserRolesController(CafeteriaDatabaseContext context)
        {
            _context = context;
        }

        /*// GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }*/

        // GET: api/UserRoles/5
        //[HttpGet("{id}")]
        /*public async Task<ActionResult<List<UserRoleView>>> GetUserRole(int id)
        {
            var userRole = await _context.UserRoleViews.Where(u => u.UserId == id).ToListAsync();

            if (userRole == null)
            {
                return NotFound();
            }


            return userRole;
        }*/
        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsersRoleSelectView>>> GetUserRoles(int id)
        {
            var userRole = await _context.UsersRoleSelectViews.Where(u => u.UserId == id).ToListAsync();

            if (userRole == null)
            {
                return NotFound();
            }


            return userRole;
        }
        // PUT: api/UserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(long id, UserRole userRole)
        {
            if (id != userRole.Rn)
            {
                return BadRequest();
            }

            _context.Entry(userRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
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

        // POST: api/UserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRoleExists(userRole.Rn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRole", new { id = userRole.Rn }, userRole);
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(long id)
        {
            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRoleExists(long id)
        {
            return _context.UserRoles.Any(e => e.Rn == id);
        }
    }
}