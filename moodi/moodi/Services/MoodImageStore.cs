using System.Collections.Generic;
using Xamarin.Forms;
using moodi.Models;

namespace moodi.Services
{
    public class MoodImageStore
    {
        private List<MoodImage> _moodImages;
        public List<MoodImage> MoodImages { get { return _moodImages; } }

        public void Init()
        {
            // TODO: Allow for 5 mood vs. 7 mood preset in user preferences
            _moodImages = new List<MoodImage>();
            MoodImages.Add(new MoodImage { SvgPath = "verygood.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodVeryGoodColor"]).ToHex() });
            MoodImages.Add(new MoodImage { SvgPath = "good.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodGoodColor"]).ToHex() });
            MoodImages.Add(new MoodImage { SvgPath = "smile.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodSmileColor"]).ToHex() });
            MoodImages.Add(new MoodImage { SvgPath = "meh.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodMehColor"]).ToHex() });
            MoodImages.Add(new MoodImage { SvgPath = "sad.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodSadColor"]).ToHex() });
            MoodImages.Add(new MoodImage { SvgPath = "bad.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodBadColor"]).ToHex() });
            MoodImages.Add(new MoodImage { SvgPath = "facedead.svg", SvgHexColor = ((Color)Application.Current.Resources["MoodDeadColor"]).ToHex() });
        }
    }
}
