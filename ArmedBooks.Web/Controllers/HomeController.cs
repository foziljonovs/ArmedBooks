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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
            => View();

        public IActionResult Contact()
            => View();

        public IActionResult About()
            => View();
    }
}
