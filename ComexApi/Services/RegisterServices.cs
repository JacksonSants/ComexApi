using AutoMapper;
using ComexApi.Data.Dto;
using ComexApi.Models;
using Microsoft.AspNetCore.Identity;

namespace ComexApi.Services;

public class RegisterServices
{
    private UserManager<Admin> _userManager;
    private IMapper _mapper;
    private TokenService _tokenService;

    public RegisterServices(UserManager<Admin> userManager, IMapper mapper, TokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task RegisterAdmin(CreateAdminDto adminDto)
    {
        Admin admin = _mapper.Map<Admin>(adminDto);
        var result = await _userManager.CreateAsync(admin, adminDto.Password);

        if (!result.Succeeded) throw new ApplicationException("Error register user.");

        _tokenService.GenerateToken(admin);
    }
}
