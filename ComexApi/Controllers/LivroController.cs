using AutoMapper;
using ComexApi.Data;
using ComexApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Admin> _userManager;

    private static List<Livro> livros = new List<Livro>();

    public LivroController(IMapper mapper, UserManager<Admin> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    [Authorize(Policy = "IdadeMinima")]
    public ActionResult CreateLivro([FromBody] Livro livro)
    {
        livros.Add(livro);
        return Ok(livro);
    }

    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public IEnumerable<Livro> ConsultarLivros()
    {
        return livros;
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult ConsultarLivros(string id)
    {
        var currentLivro = livros.FirstOrDefault(livro => livro.Id == id);

        if (currentLivro == null)
        {
            return NotFound();
        }

        return Ok(currentLivro);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult ConsultarLivros(string id, [FromBody] Livro livro)
    {
        var currentLivro = livros.FirstOrDefault(livro => livro.Id == id);

        if (currentLivro == null)
        {
            return NotFound();
        }

        currentLivro.Titulo = livro.Titulo;
        currentLivro.Autor = livro.Autor;
        currentLivro.ISBN = livro.ISBN;
        currentLivro.Descricao = livro.Descricao;
        currentLivro.Emprestado = livro.Emprestado;
        currentLivro.Id = id;

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult RemoveLivros(string id)
    {
        var currentLivro = livros.FirstOrDefault(livro => livro.Id == id);

        if (currentLivro == null)
        {
            return NotFound();
        }

        livros.Remove(currentLivro);
        return NoContent();
    }

}
