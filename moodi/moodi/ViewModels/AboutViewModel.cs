using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace moodi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command OpenGitHubRepo { get; }
        public Command OpenLicense { get; }

        public AboutViewModel()
        {
            Title = "About";

            OpenGitHubRepo = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi"));
            OpenLicense = new Command(async () => await Browser.OpenAsync("https://github.com/braem/moodi/blob/master/LICENSE"));
        }
    }
}
