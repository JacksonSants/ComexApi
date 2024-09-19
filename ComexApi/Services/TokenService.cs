using ComexApi.Data.Dto;
using ComexApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ComexApi.Services;

public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(Admin admin)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", admin.UserName),
            new Claim("id", admin.Id),
            new Claim(ClaimTypes.DateOfBirth, admin.DataNascimento.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

        var sigIngCrentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(10),
            claims: claims,
            signingCredentials: sigIngCrentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
