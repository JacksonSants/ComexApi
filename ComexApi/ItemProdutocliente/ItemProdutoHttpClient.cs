using static ComexApi.ItemProdutocliente.IItemProdutoHttpClient;
using System.Text;
using ComexApi.Data.Dto.ItemPedido;
using System.Text.Json;

namespace ComexApi.ItemProdutocliente;

public class ItemProdutoHttpClient
{
    public class ItemServiceHttpClient : IItemProdutoHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async void EnviaPedidoParaItemProduto(ReadItemPedido readDto)
        {
            var conteudoHttp = new StringContent
                (
                    JsonSerializer.Serialize(readDto),
                    Encoding.UTF8,
                    "application/json"
                );

            await _client.PostAsync(_configuration["ItemService"], conteudoHttp);
        }
    }
}
