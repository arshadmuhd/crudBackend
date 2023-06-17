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
        private readonly CollageDbContext _departmentDbContext;
        public DepartmentController(CollageDbContext departmentDbContext)
        {
            _departmentDbContext = departmentDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var Emp = await _departmentDbContext.Departments.ToListAsync();
            return Ok(Emp);

        }

        [HttpPost]
        public async Task<IActionResult> AddDepartments([FromBody] Department department)
        {
            department.Id = Guid.NewGuid();
            await _departmentDbContext.Departments.AddAsync(department);
            await _departmentDbContext.SaveChangesAsync();
            return Ok(department);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] Guid id, Department department)
        {
            var emp = await _departmentDbContext.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            emp.DepartmentName = department.DepartmentName;
            emp.DepartmentStatus = department.DepartmentStatus;
            
            await _departmentDbContext.SaveChangesAsync();

            return Ok(emp);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDepartment([FromRoute] Guid id)
        {
            var department = await _departmentDbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);

        }
    }
}
