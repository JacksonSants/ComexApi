using ComexApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ComexApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<ItemPedido> ItemsPedido { get; set; }
}
