using ComexApi.Model;
using Microsoft.EntityFrameworkCore;
using Pedido.Model;

namespace Pedido.AppContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<Pedidos> Pedido { get; set; }
    public DbSet<ItemPedido> ItemsPedido { get; set; }
}
