using AutoMapper;
using ComexApi.Data.Dto;
using ComexApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace ComexApi.Services;

public class RegisterServices
{
    private UserManager<Admin> _userManager;
    private IMapper _mapper;
    private TokenService _tokenService;
    private SignInManager<Admin> _signInManager;

    public RegisterServices(UserManager<Admin> userManager, IMapper mapper, TokenService tokenService, SignInManager<Admin> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    public async Task RegisterAdmin(CreateAdminDto adminDto)
    {
        Admin admin = _mapper.Map<Admin>(adminDto);
        var result = await _userManager.CreateAsync(admin, adminDto.Password);

        if (!result.Succeeded) throw new ApplicationException("Error register user.");
    }

    internal async Task<string> Login(LoginAdminDto adminDto)
    {
        var result = await _signInManager.PasswordSignInAsync(adminDto.Username, adminDto.Password, false, false);

        if (!result.Succeeded) throw new ApplicationException("unauthenticated user.");

        var user =  _signInManager.UserManager.Users
            .FirstOrDefault(user => user.NormalizedUserName == adminDto.Username.ToUpper());

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}
