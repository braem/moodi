using moodi.Services;
using Xamarin.Forms;

namespace moodi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MoodEntriesDataStore>();
            DependencyService.Register<MoodImagesDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
