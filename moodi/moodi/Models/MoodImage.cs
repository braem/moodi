using System;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;

namespace moodi.Models
{
    public class MoodImage : BaseModel
    {
        public string SvgPath { get; set; }
        public string SvgHexColor { get; set; }
    }
}
