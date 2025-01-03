using Microsoft.Maui.Controls;

namespace SaveUpApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // MainPage = new AppShell(); // nicht mehr nötig, wir überschreiben CreateWindow()
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        // NICHT base.CreateWindow(...) aufrufen, um NotImplementedExceptions zu vermeiden
        return new Window(new AppShell());
    }
}
