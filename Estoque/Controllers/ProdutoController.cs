using AutoMapper;
using Estoque.Data;
using Estoque.Data.Dto;
using Estoque.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ProdutoController : ControllerBase
{
    private IMapper _mapper;
    private AppDbContext _context;

    public ProdutoController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    // GET: v1/ItemPedido
    [HttpGet]
    public ActionResult<IEnumerable<ReadProdutoDto>> ReadAllProduto()
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produto.ToList());
    }

    [HttpGet("{id}")]
    // GET: v1/ItemPedido/{id}
    public ActionResult ProdutoDetails(int id)
    {
        var currentProduto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
        if (currentProduto == null)
        {
            NotFound();
        }
        return Ok(currentProduto);
    }

    // POST: v1/ItemPedido
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateProduto([FromBody] CreateProdutoDto podutoDto)
    {
        try
        {
            var produto = _mapper.Map<Produto>(podutoDto);
            _context.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ProdutoDetails), new { id = produto.Id }, produto);
        }
        catch
        {
            throw new ApplicationException("Erro ao cadastrar produto.");
        }
    }

    // PUT: v1/ItemPedido/{id}
    [HttpPut("{id}")]
    public ActionResult EditProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        var currentProduto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
        if (currentProduto == null)
        {
            NotFound();
        }

        _mapper.Map<Produto>(currentProduto);
        _context.SaveChanges();
        return NoContent();
    }

    // PATCH: v1/ItemPedido/{id}
    [HttpPatch]
    [ValidateAntiForgeryToken]
    public ActionResult EditPartialProduto(int id, JsonPatchDocument<UpdateProdutoDto> patch)
    {
        try
        {
            var produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
            {
                NotFound();
            }

            var currentProduto = _mapper.Map<UpdateProdutoDto>(produto);
            patch.ApplyTo(currentProduto);
            if (!TryValidateModel(currentProduto))
            {
                return ValidationProblem();
            }

            _mapper.Map(currentProduto, produto);
            _context.SaveChanges();

            return NoContent();
        }
        catch
        {
            throw new ApplicationException("Erro ao cadastrar produto.");
        }
    }

    // DELETE: v1/ItemPedido/{id}
    [HttpDelete]
    public ActionResult DeleteProduto(int id)
    {
        var currentProduto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
        if (currentProduto == null)
        {
            NotFound();
        }

        _context.Remove(currentProduto);
        _context.SaveChanges();
        return NoContent();
    }

}
