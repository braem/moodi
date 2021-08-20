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
        public Command OpenIssues { get; }

        public Command OpenXamarinFormsRepo { get; }
        public Command OpenXamarinCommToolkitRepo { get; }
        public Command OpenFFImageLoadingRepo { get; }
        public Command OpenCoreUIRepo { get; }
        public Command OpenComfortaaLink { get; }
        public Command OpenSQLiteNetRepo { get; }
        public Command OpenSkiasharpRepo { get; }

        public AboutViewModel()
        {
            Title = "About";
            Author = "Brae Stoltz";
            CurrentVersion = VersionTracking.CurrentVersion + " Alpha";
            License = "MIT License";

            OpenGHProfile = new Command(async () => await Browser.OpenAsync("https://github.com/braem"));
            OpenTwitterProfile = new Command(async () => await Browser.OpenAsync("https://twitter.com/braemie"));
            OpenIssues = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi/issues/new/choose"));
            OpenGitHubRepo = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi"));

            OpenXamarinFormsRepo = new Command(async () => await Browser.OpenAsync("https://github.com/xamarin/Xamarin.Forms"));
            OpenXamarinCommToolkitRepo = new Command(async () => await Browser.OpenAsync("https://github.com/xamarin/XamarinCommunityToolkit"));
            OpenFFImageLoadingRepo = new Command(async () => await Browser.OpenAsync("https://github.com/luberda-molinet/FFImageLoading"));
            OpenCoreUIRepo = new Command(async () => await Browser.OpenAsync("https://github.com/coreui/coreui-icons"));
            OpenComfortaaLink = new Command(async () => await Browser.OpenAsync("https://www.fontsquirrel.com/fonts/Comfortaa"));
            OpenSQLiteNetRepo = new Command(async () => await Browser.OpenAsync("https://github.com/oysteinkrog/SQLite.Net-PCL"));
            OpenSkiasharpRepo = new Command(async () => await Browser.OpenAsync("https://github.com/mono/SkiaSharp"));
        }
    }
}
