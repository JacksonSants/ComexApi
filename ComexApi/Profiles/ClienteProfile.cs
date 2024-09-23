
using AutoMapper;
using ComexApi.Data.Dto;
using ComexApi.Models;

namespace ComexApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>().ForMember(clienteDto => clienteDto.Livros,
            opts => opts.MapFrom(cliente => cliente.Livros)
            );
    }
}
