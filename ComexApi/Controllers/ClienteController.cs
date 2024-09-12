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

    /// <summary>
    /// Adiciona um cliente ao banco de dados.
    /// </summary>
    /// <param name="produtoDto">Objetos necessário para a criação de um cliente.</param>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    public IActionResult CadastrarCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Cliente.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ConsultarClientePorId), new { id = cliente.Id }, cliente);
    }

    /// <summary>
    /// Recupera os clientes do banco de dados.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
    [HttpGet]
    public IEnumerable<ReadClienteDto> ConsultarClientes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Cliente.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Recupera um cliente do banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
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

    /// <summary>
    /// Atualiza os dados de um cliente do  banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">Objetos necessários para a atualização de um cliente.</param>
    /// <response code="204">Caso a atualização seja feita com sucesso.</response>
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

    /// <summary>
    /// Atualiza o campo de um registro do cliente através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto"></param>
    /// <response code="204">Caso a Atualização do campo seja feita com sucesso.</response>
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

    /// <summary>
    /// Remove um cliente do banco de dados através de um parâmtro {id}.
    /// </summary>
    /// <param name="produtoDto"></param>
    /// <response code="204">Caso a remoção seja feita com sucesso.</response>
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
