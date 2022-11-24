namespace TodoAvaloniaApp.Models;

public partial class FilterItem : ObservableObject
{
    [ObservableProperty]
    private int? _count = null;
    public FilterType FilterType { get; set; }
    public ObservableCollection<ToDo> ToDos { get; set; }

    public FilterItem(FilterType filterType, ObservableCollection<ToDo> toDos)
    {
        FilterType = filterType;
        ToDos = toDos;
        Count = toDos.Count > 0 ? toDos.Count : null;
    }
}