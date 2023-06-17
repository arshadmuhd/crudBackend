using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly CollageDbContext _collageDbContext;

        public StudentController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _collageDbContext.Students.ToListAsync();
            return Ok(students);

        }



        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            student.Id = Guid.NewGuid();
          
            await _collageDbContext.Students.AddAsync(student);
            await _collageDbContext.SaveChangesAsync();
            return Ok(student);
        }


    }
}
