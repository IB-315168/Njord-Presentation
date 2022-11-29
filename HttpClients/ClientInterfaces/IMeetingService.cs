using Domain.DTOs.Meeting;
using Domain.DTOs.Project;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IMeetingService
    {
        Task<MeetingEntity> CreateAsync(MeetingCreateDTO dto);
        Task UpdateAsync(MeetingUpdateDTO dto);
        Task<MeetingEntity> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<ICollection<MeetingEntity>> GetByProjectIdAsync(int id);
    }
}
