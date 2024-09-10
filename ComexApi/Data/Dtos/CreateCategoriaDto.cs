﻿using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dtos;

public class CreateCategoriaDto
{
    [Required(ErrorMessage = "O Nome da categoria é obrigatório.")]
    public string Nome { get; set; }


}
