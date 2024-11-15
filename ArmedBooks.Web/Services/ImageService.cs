using ArmedBooks.BBL.Services;

namespace ArmedBooks.Web.Services;

public class ImageService : IImageService
{
    private readonly string _imageDirectory;
    public ImageService()
    {
        _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        if(!Directory.Exists(_imageDirectory))
            Directory.CreateDirectory(_imageDirectory);
    }
    public async Task<string> SaveImageAsync(IFormFile imageFile)
    {
        if(imageFile == null || imageFile.Length == 0)
            throw new ArgumentNullException("Image file is not valid.");

        var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(_imageDirectory, fileName);

        using(var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        return Path.Combine("images", fileName);
    }
}
