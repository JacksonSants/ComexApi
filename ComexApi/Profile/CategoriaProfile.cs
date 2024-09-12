using AutoMapper;
using ComexApi.Data;
using ComexApi.Data.Dtos;
using ComexApi.Models;

public class Categoriaprofile : Profile
{
    public Categoriaprofile()
    {
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<Categoria, ReadCategoriaDto>().ForMember(categoriaDto => categoriaDto.Produtos,
            opt => opt.MapFrom(categoria => categoria.Produtos));
    }
}
