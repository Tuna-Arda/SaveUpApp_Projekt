using System.Collections.ObjectModel;
using System.Text.Json;
using SaveUpApp.Models;

namespace SaveUpApp.Services
{
    public static class DataService
    {
        // Wähle deinen Pfad:
        private static readonly string customDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "SaveUpAppData");
        private static readonly string filePath = Path.Combine(customDirectory, "saveup_data.json");

        static DataService()
        {
            if (!Directory.Exists(customDirectory))
            {
                Directory.CreateDirectory(customDirectory);
            }
        }

        public static void Save(ObservableCollection<Product> products)
        {
            try
            {
                var json = JsonSerializer.Serialize(products);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Daten gespeichert unter: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
            }
        }

        public static ObservableCollection<Product> Load()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Keine vorhandene Datei zum Laden gefunden.");
                    return new ObservableCollection<Product>();
                }

                var json = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<ObservableCollection<Product>>(json);
                Console.WriteLine($"Daten geladen von: {filePath}");
                return result ?? new ObservableCollection<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden: {ex.Message}");
                return new ObservableCollection<Product>();
            }
        }
    }
}
