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


    }
}