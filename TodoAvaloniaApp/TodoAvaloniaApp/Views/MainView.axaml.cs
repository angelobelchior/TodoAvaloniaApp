namespace TodoAvaloniaApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        filtersList.SelectionChanged += (sender, e) =>
        {
            if (filtersList.SelectedItem is FilterItem filter)
            {
                var viewModel = (DataContext as MainViewModel)!;
                viewModel.FilterToDosCommand.Execute(filter.FilterType);
            }
        };

        newToDoTitle.KeyUp += (sender, e) =>
        {
            if (e.Key == Key.Enter)
            {
                var filter = (filtersList.SelectedItem as FilterItem)!;
                var viewModel = (DataContext as MainViewModel)!;
                viewModel.AddNewTaskCommand.Execute(filter.FilterType);
            }
            else if (e.Key == Key.Escape)
            {
                var filter = (filtersList.SelectedItem as FilterItem)!;
                var viewModel = (DataContext as MainViewModel)!;
                viewModel.ClearNewToDoFields(filter.FilterType);
            }
        };

        search.KeyUp += (sender, e) =>
        {
            if (e.Key == Key.Enter)
            {
                var viewModel = (DataContext as MainViewModel)!;
                viewModel.SearchCommand.Execute(search.Text);
            }
            else if (e.Key == Key.Escape)
            {
                search.Text = string.Empty;
            }
        };
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();

        var filter = (filtersList.SelectedItem as FilterItem)!;
        var viewModel = (DataContext as MainViewModel)!;
        viewModel.FilterToDosCommand.Execute(filter.FilterType);
    }
}