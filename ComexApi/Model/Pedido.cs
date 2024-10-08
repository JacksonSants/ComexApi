using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ComexApi.Model;
public class Pedido
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "NomeClente obrigatório")]
    public string NomeCliente { get; set; }

    [Required(ErrorMessage = "Cpf obrigatório")]
    [MaxLength(11, ErrorMessage = "Cpf inválido")]
    public string Cpf { get; set; }

    public virtual ICollection<ItemPedido> Items { get; set; }


}
