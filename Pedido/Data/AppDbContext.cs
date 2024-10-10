using Microsoft.EntityFrameworkCore;

namespace Estoque.Data;

public class AppDbContext  : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {
        
    }

    public DbSet<Produto> Produto { get; set; }
}
