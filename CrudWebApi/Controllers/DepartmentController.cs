using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly CollageDbContext _collageDbContext;
        public DepartmentController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var Emp = await _collageDbContext.Departments.ToListAsync();
            return Ok(Emp);

        }

        [HttpPost]
        public async Task<IActionResult> AddDepartments([FromBody] Department department)
        {
            department.Id = Guid.NewGuid();
            await _collageDbContext.Departments.AddAsync(department);
            await _collageDbContext.SaveChangesAsync();
            return Ok(department);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] Guid id, Department department)
        {
            var dep = await _collageDbContext.Departments.FindAsync(id);
            if (dep == null)
            {
                return NotFound();
            }
            _collageDbContext.Entry(dep).CurrentValues.SetValues(department);
            await _collageDbContext.SaveChangesAsync();


            return Ok(department);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDepartment([FromRoute] Guid id)
        {
            var department = await _collageDbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployees([FromRoute] Guid id)
        {
            var deprt = await _collageDbContext.Departments.FindAsync(id);
            if (deprt == null)
            {
                return NotFound();
            }
            _collageDbContext.Departments.Remove(deprt);
            await _collageDbContext.SaveChangesAsync();
            Console.WriteLine(deprt);
            return Ok(deprt.Id);

        }

    }
}
