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
public class ClienteController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Admin> _userManager;
    private BibliotecaContext _bibliotecaContext;

    public ClienteController(IMapper mapper, UserManager<Admin> userManager, BibliotecaContext bibliotecaContext)
    {
        _mapper = mapper;
        _userManager = userManager;
        _bibliotecaContext = bibliotecaContext;
    }

    [HttpPost]
    [Authorize(Policy = "IdadeMinima")]
    public ActionResult CreateCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _bibliotecaContext.Cliente.Add(cliente);
        _bibliotecaContext.SaveChanges();
        return Ok(cliente);
    }

    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public IEnumerable<ReadClienteDto> GetClientes()
    {

        return _mapper.Map<List<ReadClienteDto>>(_bibliotecaContext.Cliente.ToList());
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult GetLivrosForId(int id)
    {
        var currentCliente = _bibliotecaContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (currentCliente == null)
        {
            return NotFound();
        }

        return Ok(currentCliente);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult UpdateClienteForId(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        var currentCliente = _bibliotecaContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (currentCliente == null)
        {
            return NotFound();
        }

        _mapper.Map(currentCliente, clienteDto);
        _bibliotecaContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult DeleteClienteForI(int id, [FromBody] JsonPatchDocument<UpdateClienteDto> patch)
    {
        var cliente = _bibliotecaContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        _bibliotecaContext.Cliente.Remove(cliente);

        _bibliotecaContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult UpdateClientePartialForI(int id)
    {
        var cliente = _bibliotecaContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        _bibliotecaContext.Cliente.Remove(cliente);
        _bibliotecaContext.SaveChanges();
        return NoContent();
    }

}
