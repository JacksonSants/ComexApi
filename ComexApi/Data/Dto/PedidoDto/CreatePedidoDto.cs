using System.ComponentModel.DataAnnotations;

namespace Pedido.Data.Dto.CreatePedidoDto;

public class CreatePedidoDto
{
    [Required(ErrorMessage = "NomeClente obrigatório")]
    public string NomeCliente { get; set; }

    [Required(ErrorMessage = "Cpf obrigatório")]
    [StringLength(11, ErrorMessage = "Cpf inválido")]
    public string Cpf { get; set; }
}
