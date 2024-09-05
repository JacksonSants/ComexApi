using ComexApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();

    [HttpPost]
    public void CadastrarProduto([FromBody] Produto produto)
    {
        produtos.Add(produto);

    }

    [HttpGet]
    public IEnumerable<Produto> ConsultarProdutos()
    {
        return produtos;
    }

    [HttpPut("{nome}")]
    public IActionResult AtualizarProduto(string nome, [FromBody] Produto produto)
    {
        var produtoExistente = produtos.FirstOrDefault(produto => produto.Nome == nome);
        if (produtoExistente == null)
        {
            return NotFound();
        }

        produtoExistente.Nome = produto.Nome;
        produtoExistente.Descricao = produto.Descricao;
        produtoExistente.PrecoUnitario = produto.PrecoUnitario;
        produtoExistente.Quantidade = (int)produto.Quantidade;

        return Ok(produtoExistente);

    }

    [HttpDelete("{nome}")]
    public IActionResult RemoverProduto(string nome)
    {
        var produtoExistente = produtos.FirstOrDefault(produto => produto.Nome == nome);
        if (produtoExistente == null)
        {
            return NotFound();
        }

        produtos.Remove(produtoExistente);
        return Ok(nome);
    }

}
