using AutoMapper;
using Pedido.Data.Dto.CreatePedidoDto;
using Pedido.Data.Dto.PedidoDto;
using Pedido.Model;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDto, Pedidos>();
        CreateMap<ReadPedidoDto, Pedidos>();
    }
}
