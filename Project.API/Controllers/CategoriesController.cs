using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        //api/categories/GetSingleCategoryByIdWithProducts/2

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }

        // GET api/categories

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllAsync();

            List<CategoryDto> categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));

        }


        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));
        }


        // GET api/categories
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            Category category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            CategoryDto categorysDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categorysDto));

        }

        // PUT api/categories
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // DELETE api/categories/5

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(category);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}
