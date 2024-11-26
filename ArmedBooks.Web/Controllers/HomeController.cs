using ArmedBooks.BBL.Dtos;
using ArmedBooks.BBL.Services;
using ArmedBooks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmedBooks.Web.Controllers
{
    public class HomeController(
        IProductService productService,
        IImageService imageService,
        ILogger<HomeController> logger,
        ICategoryService categoryService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProductService _productService = productService;
        private readonly IImageService _imageService = imageService;
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return View(products);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Mahsulotlarni chiqarishda hatolik yuz berdi.");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("admin/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                var categoryList = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                ViewBag.CategoryList = categoryList;
                return View();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Mahsulot yaratish page yukashda hatolik yuz berdi!");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost("admin/create")]
        public async Task<IActionResult> Create(CreateProductDto dto, List<IFormFile> files)
        {
            try
            {
                if (files != null && files.Any())
                {
                    var imageFilePath = await _imageService.SaveImageAsync(files);
                    dto.Images = imageFilePath;
                }

                await _productService.AddAsync(dto);

                return RedirectToAction("Products", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mahsulot yaratishda xato yuz berdi.");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("detail")]
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if(product == null)
                return RedirectToAction("Error", "Home");

            return View(product);
        }

        [HttpGet("products")]
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

        [HttpGet("/products/category/{id}")]
        public async Task<IActionResult> Products(Guid id)
        {
            try
            {
                var products = await _productService.GetAllByCategoryIdAsync(id);
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategoriya bo'yicha mahsulotlarni chiqarishda xatolik yuz berdi.");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("contact")]
        public IActionResult Contact()
            => View();

        [HttpGet("about")]
        public IActionResult About()
            => View();

        [HttpGet("error")]
        public IActionResult Error()
            => View();
    }
}
