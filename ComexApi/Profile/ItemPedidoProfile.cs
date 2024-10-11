using AutoMapper;
using ComexApi.Data.Dto.ItemPedido;
using ComexApi.Model;

public class ItemPedidoProfile : Profile
{
    public ItemPedidoProfile()
    {
        CreateMap<CreateItemPedidoDto, ItemPedido>();
        CreateMap<ItemPedido, ReadItemPedido>();
    }
}
