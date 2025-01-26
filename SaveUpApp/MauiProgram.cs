using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using CommunityToolkit.Maui;


namespace SaveUpApp;

public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {
        Console.WriteLine($"JSON-Speicherort: {FileSystem.AppDataDirectory}");

        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                // Optional: Fonts hier registrieren
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
            });


        return builder.Build();
    }
}
