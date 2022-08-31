using asp.netcoreTelerikGrid.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.netcoreTelerikGrid.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ProductViewModel> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductViewModel>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
