using moodi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;

namespace moodi.ViewModels
{
    // Viewmodels that depend on mood svg images should extend this
    class BaseMoodViewModel : BaseViewModel
    {
        public BaseMoodViewModel()
        {
        }

        public void ApplyTintTransform(SvgCachedImage svgImage, MoodImage moodImage = null)
        {
            // TODO: allow user to customize inactive color?
            string hexColor = moodImage == null ? ((Color)Application.Current.Resources["MoodInactive"]).ToHex() : moodImage.SvgHexColor;
            svgImage.Transformations.Clear();
            svgImage.Transformations.Add(new TintTransformation { HexColor = hexColor, EnableSolidColor = true });
            svgImage.ReloadImage();
        }
    }
}
