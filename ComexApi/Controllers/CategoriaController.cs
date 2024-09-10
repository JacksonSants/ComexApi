using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dtos;
using ComexApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public CategoriaController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Criarcategoria([FromBody] CreateCategoriaDto categoriaDto)
    {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
        _context.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ConsultarCategoriaporId), new { id = categoria.Id }, categoria);
    }

    [HttpGet]
    public IEnumerable<ReadCategoriaDto> ConsuoltarCategorias([FromQuery] int skip = 0, [FromQuery] int take = 4)
    {
        return _mapper.Map<List<ReadCategoriaDto>>(_context.Categorias.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarCategoriaporId(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

        if (categoria == null)
        {
            NotFound();
        }

        return Ok(categoria);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizarproduto(int id, [FromBody] UpdateCategoriaDto categoriaDto)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

        if (categoria == null)
        {
            NotFound();
        }

        _mapper.Map(categoriaDto, categoria);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverCategoria(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

        if (categoria == null)
        {
            NotFound();
        }

        _context.Remove(categoria);
        _context.SaveChanges();
        return Ok();
    }

}
