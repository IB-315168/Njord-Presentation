using Domain.Models;

namespace Domain.DTOs;

public class ProjectUpdateDTO
{
        public int Id { get; }
        public String Name { get; set; }
        public DateTime deadline { get; set; }
        public ICollection<Requirement> requirements { get; set; }

        public ProjectUpdateDTO(int id)
        {
                this.Id = id;
        }
}