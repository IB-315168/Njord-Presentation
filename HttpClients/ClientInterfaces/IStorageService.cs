using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace HttpClients.ClientInterfaces
{
    public interface IStorageService
    {
        Task<User> GetUser(string key);
        Task SetUser(string key, User user);
        Task DeleteUser(string key);
    }
}
