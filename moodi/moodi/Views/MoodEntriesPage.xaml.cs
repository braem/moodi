using Xamarin.Forms;
using moodi.ViewModels;

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
        }
    }
}
