using Domain.Models;

namespace Domain.DTOs.Task;

public class TaskCreateDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public char Status = 'T';
    public DateTime CreationDate { get; set; }
}