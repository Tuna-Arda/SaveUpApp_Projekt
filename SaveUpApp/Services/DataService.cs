using System.Collections.ObjectModel;
using System.Text.Json;
using SaveUpApp.Models;

namespace SaveUpApp.Services
{
    public static class DataService
    {
        private static readonly string filePath =
            Path.Combine(FileSystem.AppDataDirectory, "saveup_data.json");

        public static void Save(ObservableCollection<Product> products)
        {
            try
            {
                var json = JsonSerializer.Serialize(products);
                File.WriteAllText(filePath, json);
            }
            catch
            {
                // Fehlerbehandlung
            }
        }

        public static ObservableCollection<Product> Load()
        {
            try
            {
                if (!File.Exists(filePath))
                    return new ObservableCollection<Product>();

                var json = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<ObservableCollection<Product>>(json);
                return result ?? new ObservableCollection<Product>();
            }
            catch
            {
                return new ObservableCollection<Product>();
            }
        }
    }
}
