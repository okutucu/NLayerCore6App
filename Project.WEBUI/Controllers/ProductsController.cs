using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.WEBUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, ICategoryService categoryService, IMapper mapper)
        {
            _productService = service;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductsWithCategory());
        }


        public async Task<IActionResult> Save()
        {

            var categories = _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            ViewBag.categories = new SelectList(categoriesDto,"Id","Name");

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Save(ProductDto productDto)
        {

            if(ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }

            var categories = _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");


            return View();

        }

    }
}
