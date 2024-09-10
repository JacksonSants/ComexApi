using AutoMapper;
using ComexApi.Data.Dtos;
using ComexApi.Models;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, UpdateEnderecoDto>();
        CreateMap<Endereco, ReadEnderecoDto>();
    }
}
