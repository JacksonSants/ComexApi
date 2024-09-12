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

    /// <summary>
    /// Adiciona uma categoria ao banco de dados.
    /// </summary>
    /// <param name="produtoDto">Objetos necessário para a criação de uma categoria.</param>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    public IActionResult Criarcategoria([FromBody] CreateCategoriaDto categoriaDto)
    {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
        _context.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ConsultarCategoriaporId), new { id = categoria.Id }, categoria);
    }

    /// <summary>
    /// Recupera as categorias do banco de dados.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
    [HttpGet]
    public IEnumerable<ReadCategoriaDto> ConsultarCategorias([FromQuery] int skip = 0, [FromQuery] int take = 4)
    {
        return _mapper.Map<List<ReadCategoriaDto>>(_context.Categorias.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Recupera uma categoria do banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
    [HttpGet("{id}")]
    public IActionResult ConsultarCategoriaporId(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

        if (categoria == null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    /// <summary>
    /// Atualiza os dados de uma categoria do  banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">Objetos necessários para a atualização de uma categoria.</param>
    /// <response code="204">Caso a atualização seja feita com sucesso.</response>
    [HttpPut("{id}")]
    public IActionResult Atualizarproduto(int id, [FromBody] UpdateCategoriaDto categoriaDto)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

        if (categoria == null)
        {
            return NotFound();
        }

        _mapper.Map(categoriaDto, categoria);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Remove uma categoria do banco de dados através de um parâmtro {id}.
    /// </summary>
    /// <param name="produtoDto"></param>
    /// <response code="204">Caso a remoção seja feita com sucesso.</response>
    [HttpDelete("{id}")]
    public IActionResult RemoverCategoria(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

        if (categoria == null)
        {
            return NotFound();
        }

        _context.Remove(categoria);
        _context.SaveChanges();
        return Ok();
    }

}
