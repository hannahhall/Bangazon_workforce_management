using Microsoft.EntityFrameworkCore;
using BangazonHR.Models;

namespace BangazonHR.Data
{
    public class BangazonContext : DbContext
    {
        public BangazonContext(DbContextOptions<BangazonContext> options)
            : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }



        public DbSet<BangazonHR.Models.Department> Department { get; set; }



        public DbSet<BangazonHR.Models.Employee> Employee { get; set; }



        public DbSet<BangazonHR.Models.Computer> Computer { get; set; }



        public DbSet<BangazonHR.Models.TrainingProgram> TrainingProgram { get; set; }


    }
}