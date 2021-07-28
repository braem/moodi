using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using Xamarin.Forms;

namespace FFImageLoading.Forms
{
    // This is a work around for not being able to bind the color of images via a TintTransform
    public class TintedCachedImage : CachedImage
    {
        public static BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TintedCachedImage), Color.Transparent, propertyChanged: UpdateColor);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        private static void UpdateColor(BindableObject bindable, object oldColor, object newColor)
        {
            var oldcolor = (Color)oldColor;
            var newcolor = (Color)newColor;

            if (oldcolor.Equals(newcolor))
                return;

            var view = (TintedCachedImage)bindable;
            view.Transformations.Clear();
            var transformations = new System.Collections.Generic.List<ITransformation>() {
                new TintTransformation(newcolor.ToHex()) { EnableSolidColor = true }
            };
            view.Transformations = transformations;
            view.ReloadImage();
        }

        // To Support SVG
        public static BindableProperty SvgSourceProperty = BindableProperty.Create(nameof(TintColor), typeof(string), typeof(TintedCachedImage), null, propertyChanged: UpdateSvg);
        public string SvgSource
        {
            get { return (string)GetValue(SvgSourceProperty); }
            set { SetValue(SvgSourceProperty, value); }
        }

        private static void UpdateSvg(BindableObject bindable, object oldVal, object newVal)
        {
            var _instance = bindable as TintedCachedImage;
            _instance.Source = SvgImageSource.FromFile((string)newVal);
        }
    }
}
