using AutoMapper;
using ComexApi.Data.Dto;
using ComexApi.Models;

namespace ComexApi.Profiles;

public class Adminprofile : Profile
{
    public Adminprofile()
    {
        CreateMap<CreateAdminDto, Admin>();
    }
}
