using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Validations;

namespace WebApplication1.Models;

public class Shirt
{
    public int ShirtId { get; set; }
    
    [Required]
    public string? Brand { get; set; }
    
    [Required]
    public double Price { get; set; }
    
    [Required]
    public string? Color { get; set; }
    
    [Shirt_EnsureCorrectSizing]
    public int? Size { get; set; }
    
    public string? Gender { get; set; }
}