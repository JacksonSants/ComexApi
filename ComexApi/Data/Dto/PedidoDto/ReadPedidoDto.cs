using Pedido.Data.Dto.ItemPedido;
using System.ComponentModel.DataAnnotations;

namespace Pedido.Data.Dto.PedidoDto;

public class ReadPedidoDto
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string Cpf { get; set; }
    public virtual ReadItemPedido ItemPedido { get; set; }
}
