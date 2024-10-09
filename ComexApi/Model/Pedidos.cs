using System.ComponentModel.DataAnnotations;

namespace Pedido.Model;

public class Pedidos{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "NomeClente obrigatório")]
    public string NomeCliente { get; set; }

    [Required(ErrorMessage = "Cpf obrigatório")]
    [MaxLength(11, ErrorMessage = "Cpf inválido")]
    public string Cpf { get; set; }

    public virtual ItemPedidoController ItemPedido { get; set; }
}
