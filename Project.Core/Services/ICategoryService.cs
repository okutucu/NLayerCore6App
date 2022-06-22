using Project.Core.DTOs;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
         public Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId);

    }
}
