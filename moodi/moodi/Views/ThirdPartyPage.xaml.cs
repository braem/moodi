using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using moodi.ViewModels;

namespace moodi.Views
{
    public partial class ThirdPartyPage : ContentPage
    {
        public ThirdPartyPage()
        {
            InitializeComponent();
            BindingContext = new ThirdPartyViewModel();
        }
    }
}
