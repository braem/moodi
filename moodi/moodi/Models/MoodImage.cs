using System;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;
using SQLite;

namespace moodi.Models
{
    public class MoodImage
    {
        public string SvgPath { get; set; }
        public string SvgHexColor { get; set; }
    }
}
