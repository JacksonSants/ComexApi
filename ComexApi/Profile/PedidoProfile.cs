using AutoMapper;
using ComexApi.Data.Dto.Pedido;
using ComexApi.Model;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDto, Pedido>();
        CreateMap<UpdatePedidoDto, Pedido>();
        CreateMap<Pedido, ReadPedidoDto>().ForMember(pedidoDto => pedidoDto.ItemPedido,
            opt => opt.MapFrom(pedido => pedido.ItemPedido));
    }
}
