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
/*
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _collageDbContext.Users.ToListAsync();
            return Ok(users);

        }
/**/
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await _collageDbContext.Users.AddAsync(user);
            await _collageDbContext.SaveChangesAsync();
            return Ok(user);
        }


    }
}
