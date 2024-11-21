using ArmedBooks.Domain.Entities;
using ArmedBooks.Domain.Enums;

namespace ArmedBooks.BBL.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string? About { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public int? Count { get; set; }
    public Status Status { get; set; }
    public List<string> ImagePaths { get; set; }
}
