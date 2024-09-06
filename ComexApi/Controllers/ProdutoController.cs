using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dtos;
using ComexApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public ProdutoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um produto ao banco de dados.
    /// </summary>
    /// <param name="produtoDto">Objetos necessários para a criação de um produto.</param>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public void CadastrarProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    /// <summary>
    /// Recupera os produtos do banco de dados.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadProdutoDto> ConsultarProdutos()
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos);
    }

    /*[HttpGet("{id}")]
    public IActionResult ConsultarProdutos(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
    }*/

    /// <summary>
    /// Atualiza os dados de um produto do  banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">Objetos necessários para a atualização de um produto.</param>
    /// <response code="204">Caso a atualização seja feita com sucesso.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizarProduto(int id, [FromBody]  UpdateProdutoDto produtoDto)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Remove um produto do banco de dados através de um parâmtro {id}.
    /// </summary>
    /// <param name="produtoDto"></param>
    /// <response code="200">Caso a remoção seja feita com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RemoverProduto(int id)
    {
        var produtoExistente = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produtoExistente == null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produtoExistente);
        _context.SaveChanges();
        return Ok();
    }

}
