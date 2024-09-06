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

    [HttpPost]
    public void CadastrarProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    [HttpGet]
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

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
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
