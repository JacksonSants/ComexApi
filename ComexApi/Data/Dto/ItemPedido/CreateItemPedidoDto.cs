using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dto.ItemPedido;

public class CreateItemPedidoDto
{
    [Required]
    public int PedidoId { get; set; }
}
