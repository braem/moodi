﻿using moodi.ViewModels;
using Xamarin.Forms;

namespace moodi.Views
{
    public partial class MoodEntriesPage : ContentPage
    {
        MoodEntriesViewModel _viewModel;

        public MoodEntriesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MoodEntriesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            var aa = MoodEntriesListView.ItemsLayout;
            foreach (var moodEntry in MoodEntriesListView.ItemsSource)
            {
                var item = moodEntry;
            }
        }
    }
}
