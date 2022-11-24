using Android.App;
using Android.Content.PM;

using Avalonia.Android;

namespace TodoAvaloniaApp.Android;

[Activity(Label = "TodoAvaloniaApp.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
public class MainActivity : AvaloniaMainActivity
{
}