using Domain.DTOs;
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
        Task<Team> CreateAsync(TeamCreateDTO dto);
        Task<Team> GetByIdAsync(int id);
    }
}
