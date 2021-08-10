using Xamarin.Essentials;
using Xamarin.Forms;
using moodi.Views;

namespace moodi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string _currentVersion = string.Empty;
        private string _license = string.Empty;
        private string _author = string.Empty;

        public string CurrentVersion
        {
            get { return _currentVersion; }
            set { SetProperty(ref _currentVersion, value); }
        }
        public string License
        {
            get { return _license; }
            set { SetProperty(ref _license, value); }
        }
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        public Command OpenGHProfile { get; }
        public Command OpenTwitterProfile { get; }
        public Command OpenGitHubRepo { get; }
        public Command OpenLicense { get; }
        public Command OpenThirdPartyPage { get; }

        public AboutViewModel()
        {
            Title = "About";
            Author = "Brae Stoltz";
            CurrentVersion = VersionTracking.CurrentVersion + " Alpha";
            License = "MIT License";

            OpenGitHubRepo = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi"));
            OpenLicense = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi/blob/master/LICENSE"));
            OpenThirdPartyPage = new Command(async () => await Shell.Current.GoToAsync(nameof(ThirdPartyPage)));
            OpenGHProfile = new Command(async () => await Browser.OpenAsync("https://github.com/braem"));
            OpenTwitterProfile = new Command(async () => await Browser.OpenAsync("https://twitter.com/braemie"));
        }
    }
}
