using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Data
{
    public class CollageDbContext : DbContext
    {
        public CollageDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    /*    public DbSet<DepartmentHead> DepartmentHeads { get; set; }*/
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }







    }
}
