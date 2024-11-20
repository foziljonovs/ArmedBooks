namespace ArmedBooks.Web.Services;

public interface IImageService
{
    Task<List<string>> SaveImageAsync(IEnumerable<IFormFile> imageFiles);
}
