using ComexApi.Data;
using ComexApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private BibliotecaContext _biblioteca;
    private UserManager<Cliente> _userManager;
    private LivroController _livroController;

    public ClienteController(BibliotecaContext biblioteca, UserManager<Cliente> userManager)
    {
        _biblioteca = biblioteca;
        _userManager = userManager;
    }

    private static List<Livro> livrosCliente = new List<Livro>();

    [HttpPost]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult RegisterCliente([FromBody] Livro livro)
    {
        return Ok(livro);
    }
}
