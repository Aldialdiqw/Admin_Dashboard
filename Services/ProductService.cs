using System.Collections.Generic;
using System.Threading.Tasks;
using AdminDashboard.Models;

namespace Admin_Dashboard.Services
{
    public class ProductService
    {
        private readonly ApiService _apiService;

        public ProductService()
        {
            _apiService = new ApiService();
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            return await _apiService.GetAsync<List<ProductDto>>("Products");
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            return await _apiService.GetAsync<ProductDto>($"Products/{id}");
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(string category)
        {
            return await _apiService.GetAsync<List<ProductDto>>($"Products/category/{category}");
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            return await _apiService.PostAsync<ProductDto>("Products", createProductDto);
        }

        public async Task UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            await _apiService.PutAsync<object>($"Products/{id}", updateProductDto);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _apiService.DeleteAsync($"Products/{id}");
        }
    }
}