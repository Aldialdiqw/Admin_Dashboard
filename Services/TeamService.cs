using System.Collections.Generic;
using System.Threading.Tasks;
using AdminDashboard.Models;

namespace Admin_Dashboard.Services
{
    public class TeamService
    {
        private readonly ApiService _apiService;

        public TeamService()
        {
            _apiService = new ApiService();
        }

        public async Task<List<TeamDto>> GetTeamMembersAsync()
        {
            return await _apiService.GetAsync<List<TeamDto>>("Team");
        }

        public async Task<TeamDto> GetTeamMemberAsync(int id)
        {
            return await _apiService.GetAsync<TeamDto>($"Team/{id}");
        }

        public async Task<TeamDto> CreateTeamMemberAsync(CreateTeamDto createTeamDto)
        {
            return await _apiService.PostAsync<TeamDto>("Team", createTeamDto);
        }

        public async Task UpdateTeamMemberAsync(int id, UpdateTeamDto updateTeamDto)
        {
            await _apiService.PutAsync<object>($"Team/{id}", updateTeamDto);
        }

        public async Task DeleteTeamMemberAsync(int id)
        {
            await _apiService.DeleteAsync($"Team/{id}");
        }
    }
}