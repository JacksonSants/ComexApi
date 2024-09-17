using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dto;

public class CreateAdminDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    [MaxLength(11, ErrorMessage = "Invalid CPF. The CPF must have 11 characters.")]
    public string Cpf { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

}
