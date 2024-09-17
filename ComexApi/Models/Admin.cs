using Microsoft.AspNetCore.Identity;

namespace ComexApi.Models;

public class Admin : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public string Cpf {  get; set; }

    public Admin() : base()
    {
        
    }
}
