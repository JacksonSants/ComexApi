using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ComexApi.Model;
public class ItemPedido {
    [Key]
    [Required]
    public int Id { get; set; }

    public int PedidoId { get; set; }
    public virtual Pedido Pedido { get; set; }
}
