namespace SaveUpApp;

public partial class AppShell : Shell
{
    // Gemeinsame Liste für alle Seiten
    public static System.Collections.ObjectModel.ObservableCollection<Models.Product> SharedProducts { get; } = new();

    public AppShell()
    {
        InitializeComponent();

        // Option: Nochmal Route registrieren (nicht zwingend wenn in App.xaml.cs)
        // Routing.RegisterRoute(nameof(Views.ChartPage), typeof(Views.ChartPage));

        // Beim Start vorhandene Daten laden
        var loaded = Services.DataService.Load();
        foreach (var p in loaded)
        {
            SharedProducts.Add(p);
        }
    }
}
