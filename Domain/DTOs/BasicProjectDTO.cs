namespace Domain.DTOs;

public class BasicProjectDTO
{
    private int id { get; }
    private string projectName { get; }
    private string teamName { get; }

    public BasicProjectDTO(int id, string projectName, string teamName)
    {
        this.id = id;
        this.projectName = projectName;
        this.teamName = teamName;
    }
}