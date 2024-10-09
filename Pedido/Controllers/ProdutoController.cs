using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Model;
[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    // GET: ItemPedido
    [HttpGet]
    public ActionResult Index()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    // GET: ItemPedido/Details/5
    public ActionResult Details(int id)
    {
        return Ok();
    }

    // POST: ItemPedido/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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
