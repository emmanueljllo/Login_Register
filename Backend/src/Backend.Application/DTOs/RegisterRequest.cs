using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs;

public class RegisterRequest
{
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es requerida")]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    public string Password { get; set; } = string.Empty;

    public string? FullName { get; set; }

    public string Role { get; set; } = "User";
}
