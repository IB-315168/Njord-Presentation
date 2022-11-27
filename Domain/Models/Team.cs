namespace Domain.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Member TeamLeader { get; set; }
    public ICollection<Member> members { get; set; }

}