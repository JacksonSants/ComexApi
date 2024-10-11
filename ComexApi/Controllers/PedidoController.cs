using AutoMapper;
using ComexApi.Data.Dto.Pedido;
using ComexApi.Data;
using ComexApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;
[ApiController]
[Route("v1/[controller]")]
public class PedidoController : ControllerBase
{
    private IMapper _mapper;
    private AppDbContext _context;

    public PedidoController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    // GET: v1/Pedido
    [HttpGet]
    public ActionResult<IEnumerable<ReadPedidoDto>> ReadAllPedido()
    {
        return _mapper.Map<List<ReadPedidoDto>>(_context.Pedido.ToList());
    }

    // GET: v1/Pedido/{id}
    [HttpGet("{id}")]
    public ActionResult PedidoDetails(int id)
    {
        var currentPedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
        if (currentPedido == null)
        {
            NotFound();
        }
        return Ok(currentPedido);
    }

    // POST: v1/Pedido
    [HttpPost]
    public ActionResult CreatePedido([FromBody] CreatePedidoDto pedidoDto)
    {
        try
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            _context.Pedido.Add(pedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(PedidoDetails), new { id = pedido.Id }, pedido);
        }
        catch
        {
            throw new ApplicationException("Erro ao cadastrar pedido.");
        }
    }


    // PUT: v1/Pedido/{id}
    [HttpPut("{id}")]
    public ActionResult EdiPedido(int id, [FromBody] UpdatePedidoDto updateDto)
    {
        try
        {
            var currentPedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
            if (currentPedido == null)
            {
                NotFound();
            }

            _mapper.Map(updateDto, currentPedido);
            _context.SaveChanges();

            return NoContent();
        }
        catch
        {
            throw new ApplicationException("Erro ao cadastrar pedido.");
        }
    }

    // PATCH: v1/Pedido/{id}
    [HttpPatch]
    public ActionResult EditPartialPedido(int id, JsonPatchDocument<UpdatePedidoDto> patch)
    {
        try
        {
            var pedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
            if (pedido == null)
            {
                NotFound();
            }

            var currentPedido = _mapper.Map<UpdatePedidoDto>(pedido);
            patch.ApplyTo(currentPedido);
            if (!TryValidateModel(currentPedido))
            {
                return ValidationProblem();
            }

            _mapper.Map(currentPedido, pedido);
            _context.SaveChanges();

            return NoContent();
        }
        catch
        {
            return Ok();
        }
    }

    // DELETE: Pedido/{id}
    [HttpDelete]
    public ActionResult DeletePedido(int id)
    {
        var currentPedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
        if (currentPedido == null)
        {
            NotFound();
        }

        _context.Pedido.Remove(currentPedido);
        _context.SaveChanges();
        return NoContent();
    }
}
