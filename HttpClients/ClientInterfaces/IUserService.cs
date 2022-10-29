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
        Task<User> CreateAsync(UserCreateDTO dto);
        Task<UserBasicDTO> GetByIdAsync(int id);
        Task<ICollection<User>> GetAsync(
            string? userName,
            string? email,
            string? fullName);
        Task UpdateAsync(UserUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
