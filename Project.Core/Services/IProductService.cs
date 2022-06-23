using Project.Core.DTOs;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
    }
}
