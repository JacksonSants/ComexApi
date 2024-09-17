using ComexApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComexApi.Data;

public class BibliotecaContext : IdentityDbContext<Admin>
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> opts) : base(opts) { } 
}
