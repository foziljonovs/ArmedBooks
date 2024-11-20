using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ArmedBooks.BBL.Dtos;

public class UpdateProductDto
{
    [Required]
    public string Brand { get; set; }
    public string? About { get; set; }
    [Required]
    public double Price { get; set; }
    public int? Count { get; set; }
    [MaxLength(4)]
    public List<string> Images { get; set; }
}
