using ComexApi.Data.Dto.ItemPedido;

namespace ComexApi.Data.Dto.Pedido;

public class ReadPedidoDto
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string Cpf { get; set; }
    public virtual ReadItemPedido ItemPedido { get; set; }
}
