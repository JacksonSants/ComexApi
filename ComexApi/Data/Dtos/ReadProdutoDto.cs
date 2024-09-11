using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dtos;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public string Descricao { get; set; }

    public double PrecoUnitario { get; set; }

    public int Quantidade { get; set; }

    public DateTime HoraConsulta { get; set; } = DateTime.Now;

    public string Categoria { get; set; }

}
