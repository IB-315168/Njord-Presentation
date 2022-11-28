using Domain.DTOs;
using Domain.DTOs.Team;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface ITeamService
    {
        Task<TeamEntity> CreateAsync(TeamCreateDTO dto);
        Task<TeamEntity> GetByIdAsync(int id);
        Task<IEnumerable<TeamBasicDTO>> GetByUserIdAsync(int id);
        Task UpdateAsync(TeamUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
