using Book_Api.Data;
using Book_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Api.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryContext _context;

        public UserController(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }


        [HttpGet("view/{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }
            
            existingUser.Age = user.Age;
            existingUser.Name = user.Name;
            existingUser.HasBook = user.HasBook;

            await _context.SaveChangesAsync();
            return Ok(existingUser);
        }
        
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
