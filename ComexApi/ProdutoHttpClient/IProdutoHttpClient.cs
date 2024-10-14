using ComexApi.Data.Dto.Pedido;

namespace ComexApi.ProdutoHttpClient;

public interface IProdutoHttpClient
{
    public void EnviaPedidoParaProduto(ReadPedidoDto readDto);
}
