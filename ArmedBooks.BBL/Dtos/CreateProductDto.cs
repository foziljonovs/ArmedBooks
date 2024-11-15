using ArmedBooks.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArmedBooks.BBL.Dtos;

public class CreateProductDto
{
    public string Brand { get; set; }
    public string? About { get; set; }
    public int Price { get; set; }
    public int? Count { get; set; }
    public string ImagePath { get; set; }
}
