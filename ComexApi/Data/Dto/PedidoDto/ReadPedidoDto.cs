using System.ComponentModel.DataAnnotations;

namespace Pedido.Data.Dto.PedidoDto;

public class ReadPedidoDto
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string Cpf { get; set; }
    public virtual ReadPedidoDto ItemPedido { get; set; }
}
