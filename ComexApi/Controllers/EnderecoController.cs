using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dtos;
using ComexApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public EnderecoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Endereco.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ConsultarEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> ConsultarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 4)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Endereco.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarEnderecoPorId(int id)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            NotFound();
        }

        return Ok(endereco);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            NotFound();
        }

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarEnderecoParcial(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            NotFound();
        }

        var enderecoParaAtualizar = _mapper.Map<UpdateEnderecoDto>(endereco);
        patch.ApplyTo(enderecoParaAtualizar, ModelState);
        if (!TryValidateModel(enderecoParaAtualizar))
        {
            ValidationProblem();
        }
        _mapper.Map(enderecoParaAtualizar, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverEndereco(int id)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            NotFound();
        }

        _context.Endereco.Remove(endereco);
        _context.SaveChanges();

        return NoContent();
    }
}
