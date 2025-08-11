using Microsoft.EntityFrameworkCore;
using ReportingDashboard.Models;

namespace ReportingDashboard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }

        public DbSet<Products> Products { get; set; }

    }
}
