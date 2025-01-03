using SaveUpApp.ViewModels;
using SaveUpApp.Models;

namespace SaveUpApp.Views;

public partial class ListPage : ContentPage
{
    private ListViewModel _viewModel;

    public ListPage()
    {
        InitializeComponent();
        _viewModel = new ListViewModel(AppShell.SharedProducts);
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateSumLabel();
    }

    private void OnRemoveSingleClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Product product)
        {
            _viewModel.RemoveProduct(product);
            UpdateSumLabel();
        }
    }

    private void OnClearAllClicked(object sender, EventArgs e)
    {
        _viewModel.ClearAll();
        UpdateSumLabel();
    }

    private void UpdateSumLabel()
    {
        SumLabel.Text = $"Aktuelle Summe: CHF {_viewModel.TotalPrice:F2}";
    }
}
