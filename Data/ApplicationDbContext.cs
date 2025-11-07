using Microsoft.EntityFrameworkCore;
using MyExpenditure.Model;

namespace MyExpenditure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expenditure> Expenditures { get; set; }
    }
}
