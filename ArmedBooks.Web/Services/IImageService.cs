namespace ArmedBooks.Web.Services;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile imageFile);
}
