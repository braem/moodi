using Xamarin.Forms;
using moodi.Views;

namespace moodi
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MoodEntryDetailPage), typeof(MoodEntryDetailPage));
            Routing.RegisterRoute(nameof(NewMoodEntryPage), typeof(NewMoodEntryPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

            SetTabBarIsVisible(this, false);
        }
    }
}
