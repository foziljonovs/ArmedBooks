using System.ComponentModel.DataAnnotations;

namespace ArmedBooks.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
