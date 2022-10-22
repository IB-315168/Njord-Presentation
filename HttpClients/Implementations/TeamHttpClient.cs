using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClients.Implementations
{
    public class TeamHttpClient : ITeamService
    {
        private readonly HttpClient client;
        private readonly IStorageService storageService;

        public TeamHttpClient(HttpClient client, IStorageService storageService)
        {
            this.client = client;
            this.storageService = storageService;
        }

        public async Task<Team> CreateAsync(TeamCreateDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/teams", dto);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            Team team = JsonSerializer.Deserialize<Team>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return team;
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/teams/{id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            Team team = JsonSerializer.Deserialize<Team>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return team;
        }
    }
}
