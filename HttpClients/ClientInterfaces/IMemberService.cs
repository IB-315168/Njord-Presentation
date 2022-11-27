using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IMemberService
    {
        Task<Member> CreateAsync(MemberCreateDTO dto);
        Task<MemberBasicDTO> GetByIdAsync(int id);
        Task<ICollection<Member>> GetAsync(
            string? userName,
            string? email,
            string? fullName);
        Task UpdateAsync(MemberUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
