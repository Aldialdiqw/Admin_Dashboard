using System.Collections.Generic;
using System.Threading.Tasks;
using AdminDashboard.Models;

namespace Admin_Dashboard.Services
{
    public class OrderService
    {
        private readonly ApiService _apiService;

        public OrderService()
        {
            _apiService = new ApiService();
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            return await _apiService.GetAsync<List<OrderDto>>("Orders");
        }

        public async Task<OrderDto> GetOrderAsync(int id)
        {
            return await _apiService.GetAsync<OrderDto>($"Orders/{id}");
        }

        public async Task<List<OrderDto>> GetOrdersByUserAsync(int userId)
        {
            return await _apiService.GetAsync<List<OrderDto>>($"Orders/user/{userId}");
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            return await _apiService.PostAsync<OrderDto>("Orders", createOrderDto);
        }

        public async Task UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            await _apiService.PutAsync<object>($"Orders/{id}", updateOrderDto);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _apiService.DeleteAsync($"Orders/{id}");
        }
    }
}