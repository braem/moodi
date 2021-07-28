using moodi.Models;
using System;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;

namespace moodi.Services
{
    class MoodImagesDataStore : BaseDataStore<MoodImage>
    {
        public MoodImagesDataStore()
        {
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "verygood.svg", SvgHexColor = "#a1ef7a" });
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "good.svg", SvgHexColor = "#b0ef8e" });
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "smile.svg", SvgHexColor = "#baf19c" });
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "meh.svg", SvgHexColor = "#dce9fc" });
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "sad.svg", SvgHexColor = "#bbdef9" });
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "bad.svg", SvgHexColor = "#9cd2f7" });
            Items.Add(new MoodImage { ID = Guid.NewGuid(), SvgPath = "facedead.svg", SvgHexColor = "#78c6f7" });
        }
    }
}
