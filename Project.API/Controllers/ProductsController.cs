using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Filters;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;


        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        // GET api/products//GetProductsWithCategory

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }


        // GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<Product> products = await _productService.GetAllAsync();
            List<ProductDto> productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product product = await _productService.GetByIdAsync(id);

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        // POST api/products/

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            Product product = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            ProductDto productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }


        // PUT api/products
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // DELETE api/products/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _productService.GetByIdAsync(id);

            await _productService.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }




    }
}
