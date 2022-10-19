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
    public class UserHttpClient : IUserService
    {
        private readonly HttpClient client;
        private readonly IStorageService storageService;
        
        public User? User { get; private set; }

        public UserHttpClient(HttpClient client, IStorageService storageService)
        {
            this.client = client;
            this.storageService = storageService;
        }

        public async Task InitializeAsync()
        {
            User = await storageService.GetUser("logged");
        }

        public async Task<User> CreateAsync(UserCreationDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/users", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return user;
        }

        public async Task<UserBasicDTO> GetByIdAsync(int id)
        {

            HttpResponseMessage response = await client.GetAsync($"/api/users/{id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            UserBasicDTO profile = JsonSerializer.Deserialize<UserBasicDTO>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return profile;
        }

        public async Task LoginAsync(UserLoginDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/users/authenticate", dto);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            User = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            await storageService.SetUser("logged", User);
        }

        public async Task LogoutAsync()
        {
            User = null;
            await storageService.DeleteUser("logged");
        }
    }
}
