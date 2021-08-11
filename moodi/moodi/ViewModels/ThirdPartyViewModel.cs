using Xamarin.Essentials;
using Xamarin.Forms;

namespace moodi.ViewModels
{
    class ThirdPartyViewModel
    {
        public Command OpenXamarinFormsRepo { get; }
        public Command OpenFFImageLoadingRepo { get; }
        public Command OpenCoreUIRepo { get; }
        public Command OpenComfortaaLink { get; }
        public Command OpenSQLiteNetRepo { get; }
        public Command OpenSkiasharpRepo { get; }

        public ThirdPartyViewModel()
        {
            OpenXamarinFormsRepo = new Command(async () => await Browser.OpenAsync("https://github.com/xamarin/Xamarin.Forms"));
            OpenFFImageLoadingRepo = new Command(async () => await Browser.OpenAsync("https://github.com/luberda-molinet/FFImageLoading"));
            OpenCoreUIRepo = new Command(async () => await Browser.OpenAsync("https://github.com/coreui/coreui-icons"));
            OpenComfortaaLink = new Command(async () => await Browser.OpenAsync("https://www.fontsquirrel.com/fonts/Comfortaa"));
            OpenSQLiteNetRepo = new Command(async () => await Browser.OpenAsync("https://github.com/oysteinkrog/SQLite.Net-PCL"));
            OpenSkiasharpRepo = new Command(async () => await Browser.OpenAsync("https://github.com/mono/SkiaSharp"));
        }
    }
}
