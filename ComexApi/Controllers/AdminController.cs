using ComexApi.Data.Dto;
using ComexApi.Models;
using ComexApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private RegisterServices _service;

    public AdminController(RegisterServices service)
    {
        _service = service;
    }
    /// <summary>
    /// Adiciona um cliente ao banco de dados.
    /// </summary>
    /// <param name="produtoDto">Objetos necessário para a criação de um cliente.</param>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost("cadastro")]
    public async Task<IActionResult> RegisterAdmin([FromBody] CreateAdminDto adminDto)
    {
        await _service.RegisterAdmin(adminDto);
        return Ok("User created successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAdmin(LoginAdminDto loginAdmin)
    {
        var token = await _service.Login(loginAdmin);
        return Ok(token);
    }
}
