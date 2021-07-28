using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace moodi.Models
{
    [Table("MoodEntry")]
    public class MoodEntry
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
    }
}
