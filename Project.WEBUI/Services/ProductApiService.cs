using Project.Core.DTOs;

namespace Project.WEBUI.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            CustomResponseDto<ProductDto> response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");


            return response.Data;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            CustomResponseDto<List<ProductWithCategoryDto>> response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("product/GetProductWithCategory");


            return response.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto newProduct)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            CustomResponseDto<ProductDto> responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();

            return responseBody.Data;

        }


        public async Task<bool> UpdateAsync(ProductDto newProduct)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("products", newProduct);

            return response.IsSuccessStatusCode;

        }


        public async Task<bool> RemoveAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;

        }




  
    } 
}
