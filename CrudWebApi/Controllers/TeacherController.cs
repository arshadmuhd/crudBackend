using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly CollageDbContext _collageDbContext;

        public TeacherController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _collageDbContext.Teachers.Include(x => x.User).Include(x => x.Department).ToListAsync();

            //await _collageDbContext.Users.FindAsync(students.FirstOrDefault().UserId);
            //await _collageDbContext.Departments.FindAsync(students.FirstOrDefault().DepartmentId);


            return Ok(teachers);

        }

        [HttpPost]
        public async Task<IActionResult> AddTeachers([FromBody] Teacher teacher)
        {
            teacher.Id = Guid.NewGuid();
            await _collageDbContext.Teachers.AddAsync(teacher);
            await _collageDbContext.SaveChangesAsync();
            return Ok(teacher);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTeacher([FromRoute] Guid id)
        {

            var teacher = await _collageDbContext.Teachers
        .Include(x => x.User)
        .Include(x => x.Department)
        .FirstOrDefaultAsync(x => x.Id == id);


            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);

        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTeacher([FromRoute] Guid id, Teacher teacher)
        {
            var tchr = await _collageDbContext.Teachers.FindAsync(id);
            if (tchr == null)
            {
                return NotFound();
            }
            _collageDbContext.Entry(tchr).CurrentValues.SetValues(teacher);
            await _collageDbContext.SaveChangesAsync();


            return Ok(teacher);
        }






    }
}
