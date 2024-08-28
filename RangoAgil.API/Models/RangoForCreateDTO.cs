using System.ComponentModel.DataAnnotations;

namespace RangoAgil.API.Models;

public class RangoForCreateDTO
{
    [Required]
    [MaxLength(100), MinLength(3) ]
    public required string Name { get; set; }
}
