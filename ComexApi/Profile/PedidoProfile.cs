using AutoMapper;
using ComexApi.Data.Dto.Pedido;
using ComexApi.Model;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDto, Pedido>();
        CreateMap<UpdatePedidoDto, Pedido>();
        CreateMap<ReadPedidoDto, Pedido>();
    }
}
