using moodi.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace moodi.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        public Command OpenAboutPage { get; }

        public SettingsViewModel()
        {
            Title = "Settings";

            OpenAboutPage = new Command(async () => await Shell.Current.GoToAsync(nameof(AboutPage)));
        }
    }
}
