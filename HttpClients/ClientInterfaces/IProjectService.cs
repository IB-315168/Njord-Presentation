using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IProjectService
    {
        Task<Project> CreateAsync(ProjectCreateDTO dto);
        Task UpdateAsync(ProjectUpdateDTO dto);
        Task DeleteAsync(int id);
        Task<Project> GetByIdAsync(int id);
        Task<ICollection<BasicProjectDTO>> GetByUserIdAsync(int userId);
    }
}
