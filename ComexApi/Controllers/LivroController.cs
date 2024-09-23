using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dto;
using ComexApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Admin> _userManager;
    private BibliotecaContext _bibliotecaContext;

    public LivroController(IMapper mapper, UserManager<Admin> userManager, BibliotecaContext bibliotecaContext)
    {
        _mapper = mapper;
        _userManager = userManager;
        _bibliotecaContext = bibliotecaContext;
    }

    [HttpPost]
    [Authorize(Policy = "IdadeMinima")]
    public ActionResult CreateLivro([FromBody] CreateLivroDto livroDto)
    {
        Livro livro = _mapper.Map<Livro>(livroDto);
        _bibliotecaContext.Livro.Add(livro);
        _bibliotecaContext.SaveChanges();
        return Ok(livro);
    }

    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public IEnumerable<ReadLivroDto> ConsultarLivros()
    {
        return _mapper.Map<List<ReadLivroDto>>(_bibliotecaContext.Livro.ToList());
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult ConsultarLivros(int id)
    {
        var currentLivro = _bibliotecaContext.Livro.FirstOrDefault(livro => livro.Id == id);

        if (currentLivro == null)
        {
            return NotFound();
        }

        return Ok(currentLivro);
    }
    

    [HttpPut("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult ConsultarLivros(int id, [FromBody] Livro livro)
    {
        var currentLivro = _bibliotecaContext.Livro.FirstOrDefault(livro => livro.Id == id);

        if (currentLivro == null)
        {
            return NotFound();
        }

        _mapper.Map(currentLivro, livro);
        _bibliotecaContext.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult ConsultarLivrosParcil(int id, [FromBody] JsonPatchDocument<UpdateLivroDto> patch)
    {
        var livro = _bibliotecaContext.Livro.FirstOrDefault(livro => livro.Id == id);

        if (livro == null)
        {
            return NotFound();
        }

        var currentLivro = _mapper.Map<UpdateLivroDto>(livro);
        patch.ApplyTo(currentLivro, ModelState);
        if (!TryValidateModel(currentLivro)) 
        {
            return ValidationProblem();
        }
        _bibliotecaContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult RemoveLivros(int id)
    {
        var currentLivro = _bibliotecaContext.Livro.FirstOrDefault(livro => livro.Id == id);

        if (currentLivro == null)
        {
            return NotFound();
        }

        _bibliotecaContext.Livro.Remove(currentLivro);
        _bibliotecaContext.SaveChanges();
        return NoContent();
    }

}
