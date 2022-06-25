using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.WEBUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public async Task<IActionResult>  Index()
        {

            IEnumerable<Category> categories = await _categoryService.GetAllAsync();

            var categoriesList = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return View(categoriesList);
        }

        //public async Task<IActionResult> Save()
        //{


        //    return View();
        //}
    }
}
