namespace TodoAvaloniaApp.Services;

public interface IToDoService
{
    void AddToDo(FilterType filterType, string title, bool isDone);
    IEnumerable<FilterItem> ListAll();
}

public class ToDoService : IToDoService
{
    private readonly IEnumerable<ToDo> _toDos;

    private readonly IToDosRepository _toDosRepository;
    public ToDoService(IToDosRepository toDosRepository)
    {
        _toDosRepository = toDosRepository;
        _toDos = _toDosRepository.ListAll();
    }

    private List<FilterItem>? _filters = null;
    public IEnumerable<FilterItem> ListAll()
    {
        return _filters ??= new List<FilterItem>
        {
            new(FilterType.Today, new ObservableCollection<ToDo>(_toDos.Where(t => t.StartedAt?.Date == DateTime.Now.Date || t.FinishedAt?.Date == DateTime.Now.Date))),
            new(FilterType.Important, new ObservableCollection<ToDo>(_toDos.Where(t => t.IsImportant))),
            new(FilterType.Planned, new ObservableCollection<ToDo>(_toDos.Where(t => t.FinishedAt?.Date != DateTime.Now.Date))),
            new(FilterType.Completed, new ObservableCollection<ToDo>(_toDos.Where(t => t.IsDone))),
            new(FilterType.All, new ObservableCollection<ToDo>(_toDos)),
        };
    }

    public void AddToDo(FilterType filterType, string title, bool isDone)
    {
        var allFilters = ListAll();
        var toDo = new ToDo(title, isDone, filterType == FilterType.Today ? DateTime.Now : null);
        if (filterType == FilterType.Completed) toDo.IsDone = true;

        //Insere no All, caso o filtro seja diferente de All
        if (filterType != FilterType.All)
        {
            var all = allFilters.First(f => f.FilterType == FilterType.All);
            all.ToDos.Add(toDo);
            all.Count = all.ToDos.Count;
        }

        //Insere no Filtro Selecionado
        var filters = allFilters.First(f => f.FilterType == filterType);
        filters.ToDos.Add(toDo);
        filters.Count = filters.ToDos.Count;

        //Se tiver completo e não for o filtro atual, coloca na lista dos completos também
        if (filterType != FilterType.Completed && isDone)
        {
            var completeds = allFilters.First(f => f.FilterType == FilterType.Completed);
            completeds.ToDos.Add(toDo);
            completeds.Count = completeds.ToDos.Count;
        }

        _toDosRepository.Insert(toDo);
    }
}