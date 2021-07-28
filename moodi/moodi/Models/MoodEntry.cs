using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace moodi.Models
{
    public class MoodEntry : BaseModel
    {
        public DateTime Date { get; set; }
        public int MoodLevel { get; set; }
        public int MaxMoodLevel { get; set; }
        public string Notes { get; set; }

        public MoodImage MoodImageInfo { get; set; }
    }
}
