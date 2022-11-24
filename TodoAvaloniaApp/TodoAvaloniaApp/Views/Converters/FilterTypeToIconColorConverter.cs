using Avalonia.Media.Immutable;

namespace TodoAvaloniaApp.Views.Converters;

public class FilterTypeToIconColorConverter : IValueConverter
{
    private readonly Dictionary<FilterType, Color> _colors = new()
    {
        [FilterType.All] = Color.Parse("#E46B67"),
        [FilterType.Planned] = Color.Parse("#75AEAA"),
        [FilterType.Important] = Color.Parse("#D39EA8"),
        [FilterType.Completed] = Color.Parse("#9A4F4D"),
        [FilterType.Today] = Color.Parse("#7487D6"),
    };
    
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not FilterType filterType) return string.Empty;
        return new ImmutableSolidColorBrush(_colors[filterType]);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
     => value;
}