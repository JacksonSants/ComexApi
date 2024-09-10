using AutoMapper;
using ComexApi.Data.Dtos;
using ComexApi.Models;

namespace ComexApi;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
        CreateMap<Cliente, ReadClienteDto>();

    }
}
