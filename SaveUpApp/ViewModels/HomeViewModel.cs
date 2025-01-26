using System.ComponentModel;
using System.Runtime.CompilerServices;
using SaveUpApp.Services;

namespace SaveUpApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Beispiel: Texte aus den .resx-Ressourcen
        public string WelcomeText => LocalizationResourceManager.Instance["HomeWelcome"];
        public string DescriptionText => LocalizationResourceManager.Instance["HomeDescription"];

        public HomeViewModel()
        {
            // Damit bei Sprache-Wechsel => UI updatet
            LocalizationResourceManager.Instance.PropertyChanged += OnLocalizationChanged;
        }

        private void OnLocalizationChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(WelcomeText));
            OnPropertyChanged(nameof(DescriptionText));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
