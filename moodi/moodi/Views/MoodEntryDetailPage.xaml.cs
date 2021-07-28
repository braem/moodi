using moodi.ViewModels;
using Xamarin.Forms;

namespace moodi.Views
{
    public partial class MoodEntryDetailPage : ContentPage
    {
        public MoodEntryDetailPage()
        {
            InitializeComponent();
            BindingContext = new MoodEntryDetailViewModel();
        }
    }
}
