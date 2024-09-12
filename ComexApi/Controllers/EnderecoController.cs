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
    /// <summary>
    /// Adiciona um enderço ao banco de dados.
    /// </summary>
    /// <param name="produtoDto">Objetos necessário para a criação de um Endereço.</param>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Endereco.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ConsultarEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    /// <summary>
    /// Recupera os endereços do banco de dados.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IEnumerable<ReadEnderecoDto> ConsultarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 4)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Endereco.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Recupera um endereço do banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">.</param>
    /// <response code="200">Caso a recuperação seja feita com sucesso.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ConsultarEnderecoPorId(int id)
    {
        var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            NotFound();
        }

        return Ok(endereco);
    }

    /// <summary>
    /// Atualiza os dados de um endereço do  banco de dados através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto">Objetos necessários para a atualização de um endereço.</param>
    /// <response code="204">Caso a atualização seja feita com sucesso.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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

    /// <summary>
    /// Atualiza o campo de um registro do endereço através de um parâmetro {id}.
    /// </summary>
    /// <param name="produtoDto"></param>
    /// <response code="204">Caso a Atualização do campo seja feita com sucesso.</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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

    /// <summary>
    /// Remove um endereço do banco de dados através de um parâmtro {id}.
    /// </summary>
    /// <param name="produtoDto"></param>
    /// <response code="204">Caso a remoção seja feita com sucesso.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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
