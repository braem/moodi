using System.Collections.Generic;
using moodi.Models;

namespace moodi.Services
{
    public static class MoodImageStore
    {
        private static List<MoodImage> _moodImages;
        public static List<MoodImage> MoodImages { get { return _moodImages; } }

        public static void Init()
        {
            // TODO: Allow for 5 mood vs. 7 mood preset in user preferences
            _moodImages = new List<MoodImage>();
            MoodImages.Add(new MoodImage { SvgPath = "verygood.svg", SvgHexColor = "#a1ef7a" });
            MoodImages.Add(new MoodImage { SvgPath = "good.svg", SvgHexColor = "#b0ef8e" });
            MoodImages.Add(new MoodImage { SvgPath = "smile.svg", SvgHexColor = "#baf19c" });
            MoodImages.Add(new MoodImage { SvgPath = "meh.svg", SvgHexColor = "#dce9fc" });
            MoodImages.Add(new MoodImage { SvgPath = "sad.svg", SvgHexColor = "#bbdef9" });
            MoodImages.Add(new MoodImage { SvgPath = "bad.svg", SvgHexColor = "#9cd2f7" });
            MoodImages.Add(new MoodImage { SvgPath = "facedead.svg", SvgHexColor = "#78c6f7" });
        }
    }
}
