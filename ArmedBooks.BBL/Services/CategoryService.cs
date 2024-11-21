using ArmedBooks.BBL.Dtos;
using ArmedBooks.DAL.Data.Contexts;
using ArmedBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArmedBooks.BBL.Services;

public class CategoryService(AppDbContext dbContext) : ICategoryService
{
    private readonly AppDbContext _dbContext = dbContext;
    public async Task<bool> AddCategoryAsync(CreateCategoryDto newCategory)
    {
        try
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = newCategory.Name,
                CreatedAt = DateTime.UtcNow.AddHours(5)
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while added category.");
        }
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        try
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return false;

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while deleted category.");
        }
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        try
        {
            var categories = await _dbContext.Categories.ToListAsync();

            var categoryDtos = categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                CreateDate = x.CreatedAt
            });

            return categoryDtos;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while getting categories.");
        }
    }

    public async Task<CategoryDto> GetByIdAsync(Guid id)
    {
        try
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                throw new Exception("Category not found.");

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CreateDate = category.CreatedAt
            };

            return categoryDto;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while getting category by id.");
        }
    }
}
