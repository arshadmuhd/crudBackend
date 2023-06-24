/*using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentHeadController : ControllerBase
    {
        private readonly CollageDbContext _collageDbContext;

        public DepartmentHeadController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departmentHead = await _collageDbContext.DepartmentHeads.Include(x => x.Department).ToListAsync();

            //await _collageDbContext.Users.FindAsync(students.FirstOrDefault().UserId);
            //await _collageDbContext.Departments.FindAsync(students.FirstOrDefault().DepartmentId);


            return Ok(departmentHead);

        }


        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] DepartmentHead departmentHead)
        {
            departmentHead.Id = Guid.NewGuid();
            await _collageDbContext.DepartmentHeads.AddAsync(departmentHead);
            await _collageDbContext.SaveChangesAsync();
            return Ok(departmentHead);

        }
    }
}
*/