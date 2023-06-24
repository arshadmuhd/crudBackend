using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly CollageDbContext _collageDbContext;
        public UserController( CollageDbContext collageDbContext)
        {
            _collageDbContext=collageDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _collageDbContext.Users.ToListAsync();
            return Ok(users);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await _collageDbContext.Users.AddAsync(user);
            await _collageDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _collageDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _collageDbContext.Users.Remove(user);
            await _collageDbContext.SaveChangesAsync();
            Console.WriteLine(user);
            return Ok(user.Id);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _collageDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUsers([FromRoute] Guid id, User user)
        {
            var usr = await _collageDbContext.Users.FindAsync(id);
            if (usr == null)
            {
                return NotFound();
            }
            _collageDbContext.Entry(usr).CurrentValues.SetValues(user);
            await _collageDbContext.SaveChangesAsync();


            return Ok(user);
        }



    }
}
