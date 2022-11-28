using Domain.DTOs;
using Domain.DTOs.Member;
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
    public class MemberHttpClient : IMemberService
    {
        private readonly HttpClient client;

        public MemberHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<MemberEntity> CreateAsync(MemberCreateDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/members", dto);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            MemberEntity user = JsonSerializer.Deserialize<MemberEntity>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return user;
        }

        public async Task<MemberBasicDTO> GetByIdAsync(int id)
        {

            HttpResponseMessage response = await client.GetAsync($"/api/members/{id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            MemberBasicDTO profile = JsonSerializer.Deserialize<MemberBasicDTO>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return profile;
        }

        public async Task<ICollection<MemberEntity>> GetAsync(string? userName, string? email, string? fullName)
        {
            string query = ConstructQuery(userName, email, fullName);

            HttpResponseMessage response = await client.GetAsync("/api/members" + query);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<MemberEntity> users = JsonSerializer.Deserialize<ICollection<MemberEntity>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return users;
        }

        private static string ConstructQuery(string? userName, string? email, string? fullName)
        {
            string query = "";
            if (!string.IsNullOrEmpty(userName))
            {
                query += $"?username={userName}";
            }

            if (!string.IsNullOrEmpty(email))
            {
                query += string.IsNullOrEmpty(query) ? "?" : "&";
                query += $"email={email}";
            }

            if (!string.IsNullOrEmpty(fullName))
            {
                query += string.IsNullOrEmpty(query) ? "?" : "&";
                query += $"fullname={fullName}";
            }

            return query; 
        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/api/members/{id}");

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }

        }

        public async Task UpdateAsync(MemberUpdateDTO dto)
        {
            string dtoAsJson = JsonSerializer.Serialize(dto);
            StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync("/api/members", body);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
    }
}
