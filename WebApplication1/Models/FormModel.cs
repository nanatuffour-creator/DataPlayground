using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class FormModel
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }

    public string? Message { get; set; }
}
