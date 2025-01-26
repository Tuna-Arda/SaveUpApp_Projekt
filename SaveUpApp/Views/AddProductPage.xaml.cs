using SaveUpApp.ViewModels;

namespace SaveUpApp.Views;

public partial class AddProductPage : ContentPage
{
    private AddProductViewModel _viewModel;

    public AddProductPage()
    {
        InitializeComponent();
        // Gemeinsame Liste aus AppShell
        var list = AppShell.SharedProducts;
        _viewModel = new AddProductViewModel(list);
        BindingContext = _viewModel;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        bool success = _viewModel.SaveProduct();
        if (!success)
        {
            await DisplayAlert("Fehler", "Bitte gültige Daten eingeben!", "OK");
            return;
        }

        await DisplayAlert("Gespeichert", "Produkt hinzugefügt!", "OK");
        await Shell.Current.GoToAsync(".."); // Zurück
    }
}
