using HttpClients.ClientInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Domain.Models;
using System.Text.Json;

namespace HttpClients.Implementations
{
    public class StorageService : IStorageService
    {
        private IJSRuntime jSRuntime;

        public StorageService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }
        public async Task<User> GetUser(string key)
        {
            string response = await jSRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if(response == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<User>(response);
        }

        public async Task SetUser(string key, User user)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(user));
        }

        public async Task DeleteUser(string key)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
