using ArmedBooks.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArmedBooks.Domain.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    [Required, MinLength(3)]
    public string Brand { get; set; }
    [MaxLength(512)]
    public string? About { get; set; }
    [Required]
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? Count { get; set; }
    public Status Status { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    [Required]
    public List<string> ImagePath { get; set; } = new List<string>();
}
