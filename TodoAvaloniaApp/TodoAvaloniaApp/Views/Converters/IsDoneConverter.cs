namespace TodoAvaloniaApp.Views.Converters;

public class IsDoneConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isDone && isDone == true)
            return TextDecorations.Strikethrough;
        else
            return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}
