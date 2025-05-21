using System.Collections.Generic;
using System.Threading.Tasks;
using AdminDashboard.Models;

namespace Admin_Dashboard.Services
{
    public class RestaurantService
    {
        private readonly ApiService _apiService;

        public RestaurantService()
        {
            _apiService = new ApiService();
        }

        public async Task<List<RestaurantDto>> GetRestaurantsAsync()
        {
            return await _apiService.GetAsync<List<RestaurantDto>>("Restaurant");
        }

        public async Task<RestaurantDto> GetRestaurantAsync(int id)
        {
            return await _apiService.GetAsync<RestaurantDto>($"Restaurant/{id}");
        }

        public async Task<RestaurantDto> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto)
        {
            return await _apiService.PostAsync<RestaurantDto>("Restaurant", createRestaurantDto);
        }

        public async Task UpdateRestaurantAsync(int id, UpdateRestaurantDto updateRestaurantDto)
        {
            await _apiService.PutAsync<object>($"Restaurant/{id}", updateRestaurantDto);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await _apiService.DeleteAsync($"Restaurant/{id}");
        }
    }
}