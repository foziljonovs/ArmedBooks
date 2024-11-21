using ArmedBooks.BBL.Dtos;
using ArmedBooks.DAL.Data.Contexts;
using ArmedBooks.Domain.Entities;
using ArmedBooks.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArmedBooks.BBL.Services;

public class ProductService(AppDbContext dbContext) : IProductService
{
    private readonly AppDbContext _dbContext = dbContext;
    public async Task<bool> AddAsync(CreateProductDto productDto)
    {
        try
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Brand = productDto.Brand,
                About = productDto.About,
                Price = productDto.Price,
                ImagePath = productDto.Images,
                Count = productDto.Count,
                CreatedAt = DateTime.UtcNow.AddHours(5),
                Status = Domain.Enums.Status.Active
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while added product.");
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while deleted by id product.");
        }
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        try
        {
            var products = await _dbContext.Products
                .Where(x => x.Status == Status.Active)
                .ToListAsync();

            var results = products.Select(product => new ProductDto
            {
                Id = product.Id,
                Brand = product.Brand,
                About = product.About,
                Price = product.Price,
                CreatedAt = product.CreatedAt,
                Count = product.Count,
                Status = Status.Active,
                ImagePaths = product.ImagePath
            });

            return results;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while getting products.");
        }
    }

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        try
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                throw new Exception("Product not found.");

            var result = new ProductDto
            {
                Id = product.Id,
                Brand = product.Brand,
                About = product.About,
                Price = product.Price,
                CreatedAt = product.CreatedAt,
                Count = product.Count,
                Status = Status.Active,
                ImagePaths = product.ImagePath
            };

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while getting by id product.");
        }
    }

    public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto productDto)
    {
        try
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
                throw new Exception("Product not found.");

            product.Brand = productDto.Brand;
            product.About = productDto.About;
            product.Price = productDto.Price;
            product.Count = productDto.Count;
            product.ImagePath = productDto.Images;
            product.UpdatedAt = DateTime.UtcNow.AddHours(5);

            await _dbContext.SaveChangesAsync();

            var updatedProductDto = new ProductDto
            {
                Id = product.Id,
                Brand = product.Brand,
                About = product.About,
                Price = product.Price,
                Status = product.Status,
                CreatedAt = product.CreatedAt,
                Count = product.Count,
                ImagePaths = product.ImagePath
            };

            return updatedProductDto;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while updated product.");
        }
    }
}
