using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dtos;
using ComexApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public ClienteController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Cliente.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ConsultarClientePorId), new { id = cliente.Id }, cliente);
    }

    [HttpGet]
    public IEnumerable<ReadClienteDto> ConsultarClientes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Cliente.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarClientePorId(int id)
    {
        var cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCliente(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        var cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        _mapper.Map(clienteDto, cliente);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarClienteParcial(int id, [FromBody] JsonPatchDocument<UpdateClienteDto> patch)
    {
        var cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        var clienteParaAtualizar = _mapper.Map<UpdateClienteDto>(cliente);
        patch.ApplyTo(clienteParaAtualizar);
        if (!TryValidateModel(clienteParaAtualizar))
        {
            return ValidationProblem();
        }
        _mapper.Map(clienteParaAtualizar, cliente);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverCliente(int id)
    {
        var cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
        {
            return NotFound();
        }

        _context.Cliente.Remove(cliente);
        _context.SaveChanges();

        return Ok();
    }
}
