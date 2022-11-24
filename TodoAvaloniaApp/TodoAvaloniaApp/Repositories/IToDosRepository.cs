using Avalonia.Platform.Storage;
using Avalonia.VisualTree;

namespace TodoAvaloniaApp.Repositories;

public interface IToDosRepository : IDisposable
{
    void Insert(ToDo toDo);
    IEnumerable<ToDo> ListAll(); 
}

public class ToDosRepository : IToDosRepository
{
    private readonly ILiteDatabase _liteDb;
    private readonly ILiteCollection<ToDo> _todos;
    public ToDosRepository()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var path = System.IO.Path.Combine(folder, "TodoAvaloniaApp.db");
        _liteDb = new LiteDatabase(path);
        _todos = _liteDb.GetCollection<ToDo>();
    }

    public void Dispose() => _liteDb.Dispose();
    public void Insert(ToDo toDo) => _todos.Insert(toDo);
    public IEnumerable<ToDo> ListAll() => _todos.FindAll();
}