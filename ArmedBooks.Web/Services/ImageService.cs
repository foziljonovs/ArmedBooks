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
    public async Task<List<string>> SaveImageAsync(IEnumerable<IFormFile> imageFiles)
    {
        if(imageFiles == null || !imageFiles.Any())
            throw new ArgumentNullException("Image files is not valid.");

        if (imageFiles.Count() > 4)
            throw new ArgumentException("Cannot upload more tha 4 images.");

        var savedPaths = new List<string>();

        foreach(var imageFile in imageFiles)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(_imageDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            savedPaths.Add(Path.Combine("images", fileName));
        }

        return savedPaths;
    }
}
