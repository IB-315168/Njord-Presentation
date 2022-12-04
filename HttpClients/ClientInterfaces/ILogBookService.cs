using Domain.DTOs.LogBook;
using Domain.DTOs.Project;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ILogBookService
{
    Task<LogBookEntity> CreateAsync(LogBookCreateDTO dto);
    Task UpdateAsync(LogBookUpdateDTO dto);
    Task<LogBookEntity> GetByIdAsync(int id);
    Task<LogBookEntity> GetByProjectIdAsync(int id);
}