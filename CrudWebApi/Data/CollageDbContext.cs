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



    }
}
