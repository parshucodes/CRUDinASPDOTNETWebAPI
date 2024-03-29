using Microsoft.EntityFrameworkCore;

namespace Practice.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {
            
        }
        public DbSet<Charger> Chargers { get; set; }
    }
}
