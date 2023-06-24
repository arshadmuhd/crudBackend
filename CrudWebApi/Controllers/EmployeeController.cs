using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class EmployeeController : Controller
    {
        private readonly CollageDbContext _employeeDbContext;
        public EmployeeController(CollageDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var Emp = await _employeeDbContext.Employees.ToListAsync();
            return Ok(Emp);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();
            await _employeeDbContext.Employees.AddAsync(employee);
            await _employeeDbContext.SaveChangesAsync();
            return Ok(employee);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployees([FromRoute] Guid id)
        {
            var employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployees([FromRoute] Guid id, Employee employee)
        {
            var emp = await _employeeDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Phone = employee.Phone;
            emp.Salary = employee.Salary;
            emp.Department = employee.Department;
            await _employeeDbContext.SaveChangesAsync();

            return Ok(emp);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployees([FromRoute] Guid id)
        {
            var emp = await _employeeDbContext.Employees.FindAsync(id);
            if (emp != null)
            {
                _employeeDbContext.Employees.Remove(emp);
                await _employeeDbContext.SaveChangesAsync();
                Console.WriteLine(emp);
                return Ok(emp.Id);
            }
            else
            {
                return NotFound();
            }



        }






    }
}
