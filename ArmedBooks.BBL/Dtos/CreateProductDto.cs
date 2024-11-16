using ArmedBooks.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArmedBooks.BBL.Dtos;

public class CreateProductDto
{
    [Required(ErrorMessage = "Brand is required.")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "About is required.")]
    public string About { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public double Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Count must be greater than 0.")]
    public int Count { get; set; }
    public string ImagePath { get; set; }
}
