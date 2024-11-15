namespace ArmedBooks.BBL.Services;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile imageFile);
}
