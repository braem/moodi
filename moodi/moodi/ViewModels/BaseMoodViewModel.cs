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
        public List<MoodImage> MoodImages { get; set; }

        public BaseMoodViewModel()
        {
            MoodImages = new List<MoodImage>();
            LoadMoodImages();
        }

        virtual public void OnAppearing()
        {
            IsBusy = true;
        }

        private void LoadMoodImages()
        {
            IsBusy = true;
            try
            {
                MoodImages.Clear();
                var moodImages = MoodImageDataStore.GetItemsAsync(true);
                moodImages.Wait();

                foreach (var moodImage in moodImages.Result)
                {
                    MoodImages.Add(moodImage);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
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
