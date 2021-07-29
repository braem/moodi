using System;
using SQLite;

namespace moodi.Models
{
    [Table("MoodEntry")]
    public class MoodEntry : IComparable
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }
        
        [Column("SVGImagePath")]
        public string MoodImageSvgPath { get; set; }

        [Column("SVGImageColor")]
        public string MoodImageSvgHexColor { get; set; }

        public int CompareTo(object other)
        {
            var otherEntry = (MoodEntry)other;
            if (otherEntry == null)
                return 1;

            if (ID == otherEntry.ID)
                return 0;

            return 1;
        }
    }
}
