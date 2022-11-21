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
    public class ProjectHttpClient : IProjectService
    {
        private readonly HttpClient client;

        public ProjectHttpClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<Project> CreateAsync(ProjectCreateDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/projects", dto);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            Project project = JsonSerializer.Deserialize<Project>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return project;
        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/api/projects/{id}");

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/projects/{id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            Project project = JsonSerializer.Deserialize<Project>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return project;
        }

        public async Task<ICollection<BasicProjectDTO>> GetByUserIdAsync(int userId)
        {
            HttpResponseMessage response = await client.GetAsync("/api/projects?userId=" + userId);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<BasicProjectDTO> projects = JsonSerializer.Deserialize<ICollection<BasicProjectDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return projects;
        }

        public async Task UpdateAsync(ProjectUpdateDTO dto)
        {
            string dtoAsJson = JsonSerializer.Serialize(dto);
            StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync("/api/projects", body);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
    }
}
