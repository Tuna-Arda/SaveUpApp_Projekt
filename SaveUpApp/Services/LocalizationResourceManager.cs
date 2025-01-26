using System.ComponentModel;
using System.Globalization;
using System.Resources;
// NAMESPACE anpassen, falls dein .resx woanders liegt
using SaveUpApp.Resources.Strings;

namespace SaveUpApp.Services
{
    /// <summary>
    /// Zentraler Service für Sprachumschaltung.
    /// </summary>
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        private static LocalizationResourceManager? _instance;
        public static LocalizationResourceManager Instance
            => _instance ??= new LocalizationResourceManager();

        private ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public event PropertyChangedEventHandler? PropertyChanged;

        // Indexer, z.B. loc["HomeWelcome"]
        public string this[string text] => GetValue(text);

        private LocalizationResourceManager()
        {
            _resourceManager = AppResources.ResourceManager;
            _currentCulture = CultureInfo.CurrentUICulture;
        }

        public string GetValue(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return _resourceManager.GetString(text, _currentCulture) ?? text;
        }

        public void SetCulture(CultureInfo culture)
        {
            _currentCulture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
