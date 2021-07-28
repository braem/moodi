using System;
using System.Collections.Generic;
using moodi.Models;
using moodi.ViewModels;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;

namespace moodi.Views
{
    public partial class NewMoodEntryPage : ContentPage
    {
        NewMoodEntryViewModel _viewModel;

        public NewMoodEntryPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewMoodEntryViewModel();

            // This is really stupid but needed to apply tint transforms dynamically
            foreach (var grid in MoodButtonLayout.Children)
            {
                foreach (var gridChild in (grid as Grid).Children)
                {
                    _viewModel.InitMoodImage(gridChild as SvgCachedImage);
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
