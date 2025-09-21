using LearnVoyage.Server.Enums;

namespace LearnVoyage.Server.Models;

public class Task
{
    // primary key
    public int TaskId { get; private set; }

    //foreign key
    public int UserId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    // db上の管理で親のタスクを明確にする 最上位の階層のrootTaskは参照がnull
    public int? ParentTaskId { get; private set; } = null;

    // to do listのようにタスクの中にサブタスクを埋め込んで階層構造で管理できる　ListNode的な方がいいのか？
    public List<Task> SubTasks { get; private set; } = new(); //空で初期化

    public TaskState TaskState { get; private set; } = TaskState.NotStarted;

    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}