using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private readonly CollageDbContext _collageDbContext;

        public StudentController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _collageDbContext.Students.Include(x=>x.User).Include(x => x.Department).ToListAsync();

            //await _collageDbContext.Users.FindAsync(students.FirstOrDefault().UserId);
            //await _collageDbContext.Departments.FindAsync(students.FirstOrDefault().DepartmentId);


            return Ok(students);

        }



        [HttpPost]
        public async Task<IActionResult> AddStudents([FromBody] Student student)
        {
            student.Id = Guid.NewGuid();
            await _collageDbContext.Students.AddAsync(student);
            await _collageDbContext.SaveChangesAsync();
            return Ok(student);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {

            var student = await _collageDbContext.Students
        .Include(x => x.User)
        .Include(x => x.Department)
        .FirstOrDefaultAsync(x => x.Id == id);
        

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] Guid id, Student student)
        {
            var stud = await _collageDbContext.Students.FindAsync(id);
            if (stud == null)
            {
                return NotFound();
            }
           _collageDbContext.Entry(stud).CurrentValues.SetValues(student);
            await _collageDbContext.SaveChangesAsync();


            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var student = await _collageDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _collageDbContext.Students.Remove(student);
            await _collageDbContext.SaveChangesAsync();
            Console.WriteLine(student);
            return Ok(student.Id);

        }



    }
}
