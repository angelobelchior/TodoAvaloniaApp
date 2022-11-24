namespace TodoAvaloniaApp.Models;

public partial class ToDo : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private bool _isDone = false;

    [ObservableProperty]
    private bool _isImportant = false;

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    public ToDo()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public ToDo(string title, bool isDone, DateTime? startedAt = null) : this()
    {
        Title = title;
        IsDone = isDone;
        StartedAt = startedAt;
    }
}
