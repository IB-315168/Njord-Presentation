using Domain.Models;

namespace Domain.DTOs.LogBook;

public class LogBookUpdateDTO
{
    public int Id { get; }
    public ICollection<LogBookEntryEntity> entries { get; set; }

    public LogBookUpdateDTO(int id)
    {
        Id = id;
    }
    
    
}