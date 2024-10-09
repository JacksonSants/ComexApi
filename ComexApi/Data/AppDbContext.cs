using ComexApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Model;
using System;

namespace Pedido.AppContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    DbSet<Pedidos> Pedido { get; set; }
    DbSet<ItemPedido> Items { get; set; }
}
