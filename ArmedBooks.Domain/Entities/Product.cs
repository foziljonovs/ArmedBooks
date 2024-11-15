using ArmedBooks.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? Count { get; set; }
    public Status Status { get; set; }
    public string ImagePath { get; set; }
}
