using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IUserService
    {
        User User { get; }
        Task InitializeAsync();
        Task<User> CreateAsync(UserCreationDTO dto);
        Task<UserBasicDTO> GetByIdAsync(int id);
        Task LoginAsync(UserLoginDTO dto);
        Task LogoutAsync();
    }
}
