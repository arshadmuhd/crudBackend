using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CollageDbContext _collageDbContext;


        public CourseController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _collageDbContext.Courses.Include(x => x.Department).ToListAsync();

            //await _collageDbContext.Users.FindAsync(students.FirstOrDefault().UserId);
            //await _collageDbContext.Departments.FindAsync(students.FirstOrDefault().DepartmentId);


            return Ok(courses);

        }


        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            course.Id = Guid.NewGuid();
            await _collageDbContext.Courses.AddAsync(course);
            await _collageDbContext.SaveChangesAsync();
            return Ok(course);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCourse([FromRoute] Guid id)
        {

            var course = await _collageDbContext.Courses
        .Include(x => x.Department)
        .FirstOrDefaultAsync(x => x.Id == id);


            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] Guid id, Course course)
        {
            var crse = await _collageDbContext.Courses.FindAsync(id);
            if (crse == null)
            {
                return NotFound();
            }
            _collageDbContext.Entry(crse).CurrentValues.SetValues(course);
            await _collageDbContext.SaveChangesAsync();


            return Ok(course);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid id)
        {
            var course = await _collageDbContext.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _collageDbContext.Courses.Remove(course);
            await _collageDbContext.SaveChangesAsync();
            Console.WriteLine(course);
            return Ok(course.Id);

        }


    }
}
