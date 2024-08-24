using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebService.DataAccess.Data.Seeder;
using WebService.DataAccess.Entities;

namespace WebService.DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataSeeder.Seed(modelBuilder);
        }

        //---------------[ Set Here ]----------------
        public DbSet<Book> Books { get; set; }
        //-------------------------------------------
    }
}
