using Microsoft.AspNetCore.Mvc;
using Pedido.Model;
using System.ComponentModel.DataAnnotations;
namespace ComexApi.Model;
public class ItemPedido {
    [Key]
    [Required]
    public int Id { get; set; }
    public string Nome { get; set; }
    public int PedidoId { get; set; }
    public virtual Pedidos Pedido { get; set; }
}
