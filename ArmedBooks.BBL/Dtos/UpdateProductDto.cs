namespace ArmedBooks.BBL.Dtos;

public class UpdateProductDto
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string? About { get; set; }
    public int Price { get; set; }
    public int? Count { get; set; }
}
