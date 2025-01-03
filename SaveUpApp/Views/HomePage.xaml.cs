using SaveUpApp.ViewModels;

namespace SaveUpApp.Views;

public partial class HomePage : ContentPage
{
    private HomeViewModel _viewModel;

    public HomePage()
    {
        InitializeComponent();
        _viewModel = new HomeViewModel();
        BindingContext = _viewModel;
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddProductPage));
    }

    private async void OnShowListClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ListPage));
    }
}
