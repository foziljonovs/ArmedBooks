using ArmedBooks.BBL.Dtos;

namespace ArmedBooks.BBL.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(Guid id);
    Task<bool> AddCategoryAsync(CreateCategoryDto newCategory);
    Task<bool> DeleteCategoryAsync(Guid id);
}
