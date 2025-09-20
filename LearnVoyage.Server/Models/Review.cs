using LearnVoyage.Server.Enums;

public class Review
{
    // primary key
    public int ReviewId { get; private set; }

    // foregin key
    public int TaskId { get; private set; }

    public ReviewState ReviewState { get; private set; } = ReviewState.NotStarted;

    // 復習予定日
    public DateTime ScheduledAt { get; private set; }

    // 復習日
    public DateTime? ReviewedAt { get; private set; }
}