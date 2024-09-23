namespace ComexApi.Data.Dto;

public class ReadLivroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Descricao { get; set; }
    public string ISBN { get; set; }
    DateTime DatePublicacao { get; set; }
    public bool Emprestado { get; set; }
}
