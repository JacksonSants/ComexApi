using AutoMapper;
using Estoque.Data.Dto;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
    }
}
