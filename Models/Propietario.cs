using System.ComponentModel.DataAnnotations;

namespace InmobiliariaCC.Models;

public class Propietario
{
    [Key]
    public int IdPropietario { get; set; }

    [Required]
    public string NombreCompleto { get; set; } = "";

    [Required]
    public string DNI { get; set; } = "";

    [Required]
    public string Telefono { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
}