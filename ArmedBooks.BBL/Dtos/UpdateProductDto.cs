﻿namespace ArmedBooks.BBL.Dtos;

public class UpdateProductDto
{
    public string Brand { get; set; }
    public string? About { get; set; }
    public int Price { get; set; }
    public int? Count { get; set; }
    public string ImagePath { get; set; }
}
