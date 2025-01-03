using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using SaveUpApp.Models;
using SaveUpApp.Services;

namespace SaveUpApp;

public partial class AppShell : Shell
{
    // Gemeinsame Liste für alle Seiten
    public static ObservableCollection<Product> SharedProducts { get; } = new();

    public AppShell()
    {
        InitializeComponent();

        // Routen für Navigation per GoToAsync()
        Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
        Routing.RegisterRoute(nameof(Views.AddProductPage), typeof(Views.AddProductPage));
        Routing.RegisterRoute(nameof(Views.ListPage), typeof(Views.ListPage));

        // Beim Start vorhandene Daten laden
        var loaded = DataService.Load();
        foreach (var p in loaded)
        {
            SharedProducts.Add(p);
        }
    }
}
