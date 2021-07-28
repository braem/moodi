using Xamarin.Forms;
using moodi.ViewModels;

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
