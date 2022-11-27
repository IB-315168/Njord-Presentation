using Domain.Models;

namespace Domain.DTOs;

public class TeamUpdateDTO
{
    public int Id { get;  }
    public string Name { get; set; }
    public Member TeamLeader { get; set; }
    public ICollection<Member> members { get; set; }

    public TeamUpdateDTO(int id)
    {
        this.Id = id;
    }
}