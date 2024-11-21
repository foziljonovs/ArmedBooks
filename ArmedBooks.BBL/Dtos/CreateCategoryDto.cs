using System.ComponentModel.DataAnnotations;

namespace ArmedBooks.BBL.Dtos;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
}
