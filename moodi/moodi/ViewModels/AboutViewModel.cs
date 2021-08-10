using Xamarin.Essentials;
using Xamarin.Forms;
using moodi.Views;

namespace moodi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string _appAboutTitle = string.Empty;
        public string AppAboutTitle
        {
            get { return _appAboutTitle; }
            set { SetProperty(ref _appAboutTitle, value); }
        }
        public Command OpenGitHubRepo { get; }
        public Command OpenLicense { get; }
        public Command OpenThirdPartyPage { get; }

        public AboutViewModel()
        {
            Title = "About";
            AppAboutTitle = "moodi v" + VersionTracking.CurrentVersion;

            OpenGitHubRepo = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi"));
            OpenLicense = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi/blob/master/LICENSE"));
            OpenThirdPartyPage = new Command(async () => await Shell.Current.GoToAsync(nameof(ThirdPartyPage)));
        }
    }
}
