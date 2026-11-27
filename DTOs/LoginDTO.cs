using System.ComponetModel.DataAnnotations;

namespace AddisEats.Api.DTOs; 

public class LoginDTO
{
    [Required]
    [RegularExpression(@"^09\d{8}$|^07\d{8}$", ErrorMessage = "Enter a valid Ethiopian mobile number.")]
    public string Phone { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}