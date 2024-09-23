﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ComexApi.Models;

public class Livro
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Autor { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string ISBN { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime DatePublicacao { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public bool Emprestado { get; set; }
    public int? ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }

}
