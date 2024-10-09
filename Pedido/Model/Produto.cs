using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
public class Produto {
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Quantidade obrigatório")]
    public string Quantidade { get; set; }

    [Required(ErrorMessage = "Preçc obrigatório")]
    public float Preco { get; set; }
}
