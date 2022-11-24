namespace TodoAvaloniaApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public IEnumerable<FilterItem> Filters { get; }

    [ObservableProperty]
    private ObservableCollection<ToDo> _toDos;

    [ObservableProperty]
    private string _newToDoTitle = string.Empty;

    [ObservableProperty]
    private bool _newToDoIsDone = false;


    private readonly IToDoService _filterService;
    public MainViewModel(IToDoService filterService)
    {
        _filterService = filterService;
        Filters = _filterService.ListAll();
        _toDos = new ObservableCollection<ToDo>();
    }

    public void ClearNewToDoFields(FilterType filterType)
    {
        NewToDoTitle = string.Empty;
        NewToDoIsDone = filterType == FilterType.Completed;
    }

    [RelayCommand]
    private void FilterToDos(FilterType filterType)
    {
        NewToDoIsDone = filterType == FilterType.Completed;
        var filter = Filters.FirstOrDefault(f => f.FilterType == filterType);
        if (filter is not null) ToDos = filter.ToDos;
    }

    [RelayCommand]
    private void AddNewTask(FilterType filterType)
    {
        if (string.IsNullOrEmpty(NewToDoTitle)) return;

        _filterService.AddToDo(filterType, NewToDoTitle, NewToDoIsDone);

        FilterToDos(filterType);
        ClearNewToDoFields(filterType);
    }

    [RelayCommand]
    private void Search(string value)
    {
        if (string.IsNullOrEmpty(value)) return;
    }
}