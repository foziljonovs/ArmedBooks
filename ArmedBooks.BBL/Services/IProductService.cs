using ArmedBooks.BBL.Dtos;

namespace ArmedBooks.BBL.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(Guid id);
    Task<bool> AddAsync(CreateProductDto productDto);
    Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto productDto);
    Task<bool> DeleteAsync(Guid id);
}
