using ComexApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dtos;

public class ReadCategoriaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<ReadProdutoDto> Produtos  { get; set; }
}
