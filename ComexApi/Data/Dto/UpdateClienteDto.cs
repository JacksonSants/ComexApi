using ComexApi.Models;
public class UpdateClienteDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public virtual ICollection<Livro> Livros { get; set; }
    public int? ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
}
