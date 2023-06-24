using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly CollageDbContext _collageDbContext;

        public PaymentController(CollageDbContext collageDbContext)
        {
            _collageDbContext = collageDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var Payments = await _collageDbContext.PaymentHistories.Include(x => x.Student)
            .ThenInclude(s => s.User)
        .Include(x => x.Student)
            .ThenInclude(s => s.Department)
        .ToListAsync();

            //await _collageDbContext.Users.FindAsync(students.FirstOrDefault().UserId);
            //await _collageDbContext.Departments.FindAsync(students.FirstOrDefault().DepartmentId);


            return Ok(Payments);

        }



        [HttpPost]
        public async Task<IActionResult> AddPayments([FromBody] PaymentHistory paymentHistory)
        {
            paymentHistory.Id = Guid.NewGuid();
            await _collageDbContext.PaymentHistories.AddAsync(paymentHistory);
            await _collageDbContext.SaveChangesAsync();
            return Ok(paymentHistory);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetPayment([FromRoute] Guid id)
        {

            var payment = await _collageDbContext.PaymentHistories
        .Include(x => x.Student)
            .ThenInclude(s => s.User)
        .Include(x => x.Student)
            .ThenInclude(s => s.Department)
        .FirstOrDefaultAsync(x => x.StudentId == id);


            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePayment([FromRoute] Guid id, PaymentHistory payment)
        {
            var pay = await _collageDbContext.PaymentHistories.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }
            _collageDbContext.Entry(pay).CurrentValues.SetValues(payment);
            await _collageDbContext.SaveChangesAsync();


            return Ok(payment);
        }
    }
}
