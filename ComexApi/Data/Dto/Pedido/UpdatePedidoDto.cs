using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dto.Pedido;

public class UpdatePedidoDto
{
    [Required(ErrorMessage = "NomeClente obrigatório")]
    public string NomeCliente { get; set; }

    [Required(ErrorMessage = "Cpf obrigatório")]
    [StringLength(11, ErrorMessage = "Cpf inválido")]
    public string Cpf { get; set; }
}
