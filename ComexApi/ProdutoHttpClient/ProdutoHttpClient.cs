using ComexApi.Data.Dto.Pedido;
using System.Text;
using System.Text.Json;

namespace ComexApi.ProdutoHttpClient;

public class ProdutoHttpClient : IProdutoHttpClient
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public ProdutoHttpClient(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    public async void EnviaPedidoParaProduto(ReadPedidoDto readDto)
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
