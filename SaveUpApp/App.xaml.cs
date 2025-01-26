namespace SaveUpApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Route-Registrierungen: 
        Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
        Routing.RegisterRoute(nameof(Views.AddProductPage), typeof(Views.AddProductPage));
        Routing.RegisterRoute(nameof(Views.ListPage), typeof(Views.ListPage));
        
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        // Muss zur Basismethode passen
        return new Window(new AppShell());
    }
}
