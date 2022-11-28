using Domain.DTOs;
using Domain.DTOs.Project;
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
        Task<ProjectEntity> CreateAsync(ProjectCreateDTO dto);
        Task UpdateAsync(ProjectUpdateDTO dto);
        Task DeleteAsync(int id);
        Task<ProjectEntity> GetByIdAsync(int id);
        Task<ICollection<BasicProjectDTO>> GetByUserIdAsync(int userId);
    }
}
