using BBsBaskets.Models;
using Microsoft.EntityFrameworkCore;

namespace BBsBaskets.Data
{
    public class BBsBasketsDbContext : DbContext
    {
        public BBsBasketsDbContext(DbContextOptions<BBsBasketsDbContext> options) : base (options)   
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
