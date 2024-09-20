using Microsoft.AspNetCore.Identity;

namespace ComexApi.Data.Dto;

public class CreateLivroDto : IdentityUser
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Descricao { get; set; }
    public string ISBN { get; set; }
    DateTime DatePublicacao { get; set; }
    public bool Emprestado { get; set; }
}
