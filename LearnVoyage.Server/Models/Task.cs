using LearnVoyage.Server.Enums;
namespace LearnVoyage.Server.Models;

public class Task
{

    // primary key
    public int TaskId { get; private set; }

    //foreign key
    public int UserId { get; }

    public string? Title { get; private set; }

    public string? Content { get; set; }

    public TaskState taskState { get; private set; }

    public DateTime CreatedAt { get; private set; }
}