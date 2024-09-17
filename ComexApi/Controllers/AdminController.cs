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

    [HttpPost]
    [Route("cadastro")]
    public async Task<IActionResult> RegisterAdmin([FromBody] CreateAdminDto adminDto)
    {
        await _service.RegisterAdmin(adminDto);
        return Ok("User created successfully.");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAdmin([FromBody] CreateAdminDto adminDto)
    {
        await _service.RegisterAdmin(adminDto);
        return Ok("Login sucessfull.");
    }
}
