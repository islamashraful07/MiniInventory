using Microsoft.EntityFrameworkCore;

namespace MiniInventory.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {
        }
        public DbSet<Models.Entities.Product> Products { get; set; }
        
    }
}
