using SQLite;
using System;

namespace AuroraDiary.Models
{
    public class DiaryEntry
    {
        internal string? PhotoPath;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Emotion { get; set; } = string.Empty; // Added emotion field
        public string Photo { get; set; } = string.Empty; // Added photo field
    }
}
