using System.Collections.Generic;
using System.Threading.Tasks;
using AdminDashboard.Models;

namespace Admin_Dashboard.Services
{
    public class UserService
    {
        private readonly ApiService _apiService;

        public UserService()
        {
            _apiService = new ApiService();
        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            return await _apiService.PostAsync<UserDto>("Users/login", loginDto);
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _apiService.GetAsync<List<UserDto>>("Users");
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            return await _apiService.GetAsync<UserDto>($"Users/{id}");
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            return await _apiService.PostAsync<UserDto>("Users", createUserDto);
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            await _apiService.PutAsync<object>($"Users/{id}", updateUserDto);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _apiService.DeleteAsync($"Users/{id}");
        }
    }
}