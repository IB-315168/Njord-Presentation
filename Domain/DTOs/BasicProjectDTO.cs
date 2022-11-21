namespace Domain.DTOs;

public class BasicProjectDTO
{
    public int Id { get; }
    public string ProjectName { get; }
    public string TeamName { get; }

    public BasicProjectDTO(int id, string projectName, string teamName)
    {
        this.Id = id;
        this.ProjectName = projectName;
        this.TeamName = teamName;
    }
}