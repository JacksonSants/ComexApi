using ComexApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComexApi.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Produto>()
                .HasOne(produto => produto.Categoria)
                .WithMany(categoria => categoria.Produtos)
                .OnDelete(DeleteBehavior.Restrict); 
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Cliente { get; set; }

    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

}
