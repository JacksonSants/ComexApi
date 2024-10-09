using AutoMapper;
using ComexApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedido.AppContext;
using Pedido.Data.Dto.CreatePedidoDto;
using Pedido.Data.Dto.PedidoDto;
using Pedido.Model;
using System.Numerics;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private IMapper _mapper;
    private AppDbContext _context;

    public PedidoController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    // PUT: ItemPedido/Edit/5
    [HttpPut]
    public ActionResult Edit(int id)
    {
        return Ok();
    }

    // PATCH: ItemPedido/Edit/5
    [HttpPatch]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return Ok();
        }
    }

    // DELETE: ItemPedido/Delete/5
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        return Ok();
    }
}
