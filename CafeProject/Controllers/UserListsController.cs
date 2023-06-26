using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CafeProject.Models;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace CafeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListsController : ControllerBase
    {
        private readonly CafeteriaDatabaseContext _context;
        private readonly IMapper mapper;

        public UserListsController(CafeteriaDatabaseContext context,IMapper map)
        {
            _context = context;
            mapper = map;
        }

        // GET: api/UserLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserList>>> GetUserLists()
        {
            return await _context.UserLists.ToListAsync();
        }

        // GET: api/UserLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserList>> GetUserList(int id)
        {
            var userList = await _context.UserLists.FindAsync(id);

            if (userList == null)
            {
                return NotFound();
            }

            return userList;
        }

        // PUT: api/UserLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserList(int id, UserList userList)
        {
            if (id != userList.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserListExists(id))
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

        // POST: api/UserLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRegister>> PostUserList(UserRegister userregister)
        {
            UserList userList = mapper.Map<UserList>(userregister);
            _context.UserLists.Add(userList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserList", new { id = userList.UserId }, userList);
        }

        // DELETE: api/UserLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserList(int id)
        {
            var userList = await _context.UserLists.FindAsync(id);
            if (userList == null)
            {
                return NotFound();
            }

            _context.UserLists.Remove(userList);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult StatusChange(int id, [FromBody]JsonPatchDocument<UserList> patchdoc)
        {
            UserList? userlist = _context.UserLists.Where(u => u.UserId == id).FirstOrDefault();

            if (userlist != null)
            {
                patchdoc.ApplyTo(userlist, ModelState);
                return Ok(userlist);
            }
            return NotFound();
        }



        private bool UserListExists(int id)
        {
            return _context.UserLists.Any(e => e.UserId == id);
        }
    }
}
