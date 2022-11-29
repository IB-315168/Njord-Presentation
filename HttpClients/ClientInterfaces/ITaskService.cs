using Domain.DTOs.Task;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ITaskService
{
    Task<TaskEntity> CreateAsync(TaskCreateDTO dto);
    Task UpdateAsync(TaskUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<TaskEntity> GetByIdAsync(int id);
    Task<IEnumerable<BasicTaskDTO>> GetByProjectIdAsync(int id);
}