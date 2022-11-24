namespace TodoAvaloniaApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var toDosRepository = new ToDosRepository();
        var filterService = new ToDoService(toDosRepository);
        var viewModel = new MainViewModel(filterService);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = viewModel
            };
            desktop.Exit += (sender, e) => toDosRepository.Dispose();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = viewModel
            };
            singleViewPlatform.MainView.Unloaded += (sender, e) => toDosRepository.Dispose();
        }

        base.OnFrameworkInitializationCompleted();
    }
}