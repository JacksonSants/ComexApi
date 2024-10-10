using Pedido.Model;
using System.ComponentModel.DataAnnotations;

namespace Pedido.Data.Dto.ItemPedido;

public class CreateItemsPedido
{
    [Required]
    public int PedidoId { get; set; }
}
