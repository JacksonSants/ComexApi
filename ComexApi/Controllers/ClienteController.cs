using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dto;
using ComexApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
}
