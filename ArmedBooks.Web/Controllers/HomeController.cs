using ArmedBooks.BBL.Dtos;
using ArmedBooks.BBL.Services;
using ArmedBooks.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArmedBooks.Web.Controllers
{
    public class HomeController(
        IProductService productService,
        IImageService imageService,
        ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProductService _productService = productService;
        private readonly IImageService _imageService = imageService;

        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return View(products);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet("admin/create")]
        public IActionResult Create()
            => View();

        [HttpPost("admin/create")]
        public async Task<IActionResult> Create(CreateProductDto dto, List<IFormFile> files)
        {
            try
            {
                if(files != null && files.Any())
                {
                    var imageFilePath = await _imageService.SaveImageAsync(files);
                    dto.Images = imageFilePath;
                }

                await _productService.AddAsync(dto);

                return RedirectToAction("Products", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if(product == null)
                return RedirectToAction("Error", "Home");

            return View(product);
        }

        public async Task<IActionResult> Products()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return View(products);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Contact()
            => View();

        public IActionResult About()
            => View();

        public IActionResult Error()
            => View();
    }
}
