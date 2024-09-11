using AutoMapper;
using ComexApi.Data.Dtos;
using ComexApi.Models;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<UpdateCategoriaDto, Categoria>();
        CreateMap<Categoria, ReadCategoriaDto>().ForMember(produtoDto => produtoDto.Produtos,
            opt => opt.MapFrom(produto => produto.Produtos));
    }
}
