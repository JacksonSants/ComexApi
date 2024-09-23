using AutoMapper;
using ComexApi.Data.Dto;
using ComexApi.Models;

namespace ComexApi.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<CreateLivroDto, Livro>();
        CreateMap<Livro, UpdateLivroDto>();
        CreateMap<UpdateLivroDto, Livro>();
        CreateMap<Livro, ReadLivroDto>();
    }
}
