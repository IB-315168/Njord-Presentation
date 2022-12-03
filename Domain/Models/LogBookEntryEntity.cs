namespace Domain.Models;

public class LogBookEntryEntity : IEquatable<LogBookEntryEntity>
{
    public int Id { get; set; }
    public int IdLogBook { get; set; }
    public int IdMeeting { get; set; }
    public string content { get; set; }

    public LogBookEntryEntity(int id, int idLogBook, int idMeeting, string content)
    {
        Id = id;
        IdLogBook = idLogBook;
        IdMeeting = idMeeting;
        this.content = content;
    }

    public bool Equals(LogBookEntryEntity? other)
    {
        if (other == null)
        {
            return false;
        }

        return Id == other.Id && IdLogBook == other.IdLogBook && IdMeeting == other.IdLogBook &&
               content.Equals(other.content);
    }
}