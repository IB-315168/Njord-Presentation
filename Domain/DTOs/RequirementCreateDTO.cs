namespace Domain.DTOs;

public class RequirementCreateDTO
{
    public int idproject { get; }
    public String content { get;  }

    public RequirementCreateDTO(int idproject, String content)
    {
        this.idproject = idproject;
        this.content = content;
    }
}