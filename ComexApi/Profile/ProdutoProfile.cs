using AutoMapper;
using ComexApi.Data.Dtos;
using ComexApi.Models;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
        CreateMap<Produto, ReadProdutoDto>()
            .ForMember(produtoDto => produtoDto.Categoria,
                opt => opt.MapFrom(produto => produto.Categoria.Nome));
    }
}
