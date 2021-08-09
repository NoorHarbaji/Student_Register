using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Register.Models;

namespace Student_Register.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Batch> Batchs { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Staff> Staffs { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<Record> Records { set; get; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
    }
}

