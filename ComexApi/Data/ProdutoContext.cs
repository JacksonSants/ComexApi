using ComexApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComexApi.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
    {
        
    }

    public DbSet<Produto> Produtos { get; set; }

}
