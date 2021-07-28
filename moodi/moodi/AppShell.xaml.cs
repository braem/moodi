using moodi.Views;
using System;
using Xamarin.Forms;

namespace moodi
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MoodEntryDetailPage), typeof(MoodEntryDetailPage));
            Routing.RegisterRoute(nameof(NewMoodEntryPage), typeof(NewMoodEntryPage));
            //SetNavBarIsVisible(this, false);
        }
    }
}
