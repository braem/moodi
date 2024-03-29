﻿using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;
using moodi.Models;

namespace moodi.ViewModels
{
    public static class ViewModelUtils
    {
        public static void ApplyTintTransform(SvgCachedImage svgImage, MoodImage moodImage = null)
        {
            // TODO: allow user to customize inactive color?
            string hexColor = moodImage == null ? ((Color)Application.Current.Resources["MoodInactive"]).ToHex() : moodImage.SvgHexColor;
            svgImage.Transformations.Clear();
            svgImage.Transformations.Add(new TintTransformation { HexColor = hexColor, EnableSolidColor = true });
            svgImage.ReloadImage();
        }
    }
}
