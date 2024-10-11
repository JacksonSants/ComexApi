using ComexApi.Data.Dto.ItemPedido;
using ComexApi.Data.Dto.Pedido;

namespace ComexApi.ItemProdutocliente;

public class IItemProdutoHttpClient
{
    public interface IItemServiceHttpClient
    {
        public void EnviaPedidoParaItemProduto(ReadItemPedido readDto);
    }

}
