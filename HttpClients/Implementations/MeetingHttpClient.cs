using Domain.DTOs.Meeting;
using Domain.DTOs.Member;
using Domain.DTOs.Project;
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
    public class MeetingHttpClient : IMeetingService
    {
        private readonly HttpClient client;

        public MeetingHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<MeetingEntity> CreateAsync(MeetingCreateDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/meetings", dto);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            MeetingEntity meeting = JsonSerializer.Deserialize<MeetingEntity>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return meeting;
        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/api/meetings/{id}");

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }

        public async Task<MeetingEntity> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/meetings/{id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            MeetingEntity meeting = JsonSerializer.Deserialize<MeetingEntity>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return meeting;
        }

        public async Task<ICollection<BasicMeetingDTO>> GetByProjectIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync("/api/meetings?id=" + id);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<BasicMeetingDTO> meetings = JsonSerializer.Deserialize<ICollection<BasicMeetingDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return meetings;
        }

        public async Task UpdateAsync(MeetingUpdateDTO dto)
        {
            string dtoAsJson = JsonSerializer.Serialize(dto);
            StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync("/api/meetings", body);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
    }
}
