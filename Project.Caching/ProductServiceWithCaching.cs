using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Repositories;
using Project.Core.Services;
using Project.Core.UnitOfWorks;
using Project.Service.Exceptions;

namespace Project.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string cacheProductKey = "productsCache";

        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMemoryCache memoryCache, IMapper mapper, IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;


            if (!_memoryCache.TryGetValue(cacheProductKey, out _))
            {
                _memoryCache.Set(cacheProductKey, _repository.GetProductsWithCategory().Result);
            }
        }


        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(cacheProductKey));
        }

        public Task<Product> GetByIdAsync(int id)
        {
            Product product = _memoryCache.Get<List<Product>>(cacheProductKey).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException($"{typeof(Product).Name}({id}) not found");
            }
            return Task.FromResult(product);
        }

        public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            IEnumerable<Product> products = _memoryCache.Get<IEnumerable<Product>>(cacheProductKey);

            List<ProductWithCategoryDto> productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return Task.FromResult(CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsWithCategoryDto));

        }

        public async Task RemoveAsync(Product entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> exp)
        {
            return _memoryCache.Get<List<Product>>(cacheProductKey).Where(exp.Compile()).AsQueryable();
        }



        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(cacheProductKey, await _repository.GetAll().ToListAsync());
        }
    }
}
