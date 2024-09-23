using ComexApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComexApi.Data;

public class BibliotecaContext : IdentityDbContext<Admin>
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> opts) : base(opts) { 
    } 

    public DbSet<Admin> Admin { get; set; }
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
}

