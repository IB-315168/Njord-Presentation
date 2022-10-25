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

        public async Task<IEnumerable<TeamBasicDTO>> GetByUserIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/teams/?userId={id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            IEnumerable<TeamBasicDTO> team = JsonSerializer.Deserialize<IEnumerable<TeamBasicDTO>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return team;
        }

        public async Task UpdateAsync(TeamUpdateDTO dto)
        {
            string dtoAsJson = JsonSerializer.Serialize(dto);
            StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync("/api/teams", body);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }


        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/api/teams/{id}");

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
    }
}
