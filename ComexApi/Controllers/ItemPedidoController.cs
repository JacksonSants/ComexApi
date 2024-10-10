﻿using AutoMapper;
using ComexApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Pedido.AppContext;
using Pedido.Data.Dto.CreatePedidoDto;
using Pedido.Data.Dto.PedidoDto;
using Pedido.Model;

[ApiController]
[Route("v1/[controller]")]
public class ItemPedidoController : ControllerBase
{
    private IMapper _mapper;
    private AppDbContext _context;

    public ItemPedidoController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    // GET: v1/ItemPedido
    [HttpGet]
    public ActionResult<IEnumerable<ReadPedidoDto>> ReadAllItems()
    {
        return _mapper.Map<List<ReadPedidoDto>>(_context.Pedido.ToList());
    }

    // GET: v1/ItemPedido/{id}
    [HttpGet("{id}")]
    public ActionResult ItemsPedidoDetails(int id)
    {
        var currentPedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
        if (currentPedido == null)
        {
            NotFound();
        }
        return Ok(currentPedido);
    }

    // POST: v1/ItemPedido
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateItemPedido([FromBody] CreatePedidoDto itemPedidoDto)
    {
        try
        {
            var itemPedido = _mapper.Map<ItemPedido>(itemPedidoDto);
            _context.ItemsPedido.Add(itemPedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ItemsPedidoDetails), new { id = itemPedido.Id }, itemPedido);
        }
        catch
        {
            throw new ApplicationException("Erro ao cadastrar pedido.");
        }
    }

    /*// PUT: v1/ItemPedido/{id}
    [HttpPut("{id}")]
    public ActionResult EditItemProduto(int id, [FromBody] PedidoUpdateDto updateDto)
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
    }*/

    /*// PATCH: v1/ItemPedido/{id}
    [HttpPatch]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, JsonPatchDocument<U>)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return Ok();
        }
    }*/

    // DELETE: v1/ItemPedido/{id}
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        return Ok();
    }
}
