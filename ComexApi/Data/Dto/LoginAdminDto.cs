using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dto;

public class LoginAdminDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
